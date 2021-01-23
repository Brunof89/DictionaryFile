using DictionaryFile.Domain.Requests;
using DictionaryFile.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DictionaryFile.Domain.Services
{
    public class DictionaryFileService : IDictionaryFileService
    {
        private readonly IFileService _fileService;

        public DictionaryFileService(IFileService fileService)
        {
            _fileService = fileService;
        }

        /// <summary>
        /// Check if given word meets length.
        /// </summary>
        /// <param name="word"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public bool CheckWordLength(string word, int length)
        {
            return word.Length == length;
        }

        /// <summary>
        /// Input method to process file and generate output file
        /// </summary>
        /// <param name="request"></param>
        public void ProcessWords(DictionaryFileRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("Request is empty");

            String[] words = _fileService.ReadFile(request.FileName);

            IEnumerable<IEnumerable<string>> resultList = null;

            words = words.Where(w => w.Length == request.WordLength).ToArray();

            resultList = FindLadders(request.StartWord, request.EndWord, words.ToList());

            _fileService.CreateOutputFile(request.ResultFileName, resultList);
        }

        public List<List<string>> FindLadders(string beginWord, string endWord, List<string> wordList)
        {

            Dictionary<string, HashSet<string>> graph = new Dictionary<string, HashSet<string>>();
            AddWordToGraph(beginWord, graph);
            foreach (string word in wordList)
                AddWordToGraph(word, graph);

            //Queue For BFS
            Queue<string> queue = new Queue<string>();
            //Dictionary to store shortest paths to a word
            Dictionary<string, List<List<string>>> paths = new Dictionary<string, List<List<string>>>();

            queue.Enqueue(beginWord);
            paths[beginWord] = new List<List<string>>() { new List<string>() { beginWord } };

            HashSet<string> visited = new HashSet<string>();

            while (queue.Count > 0)
            {

                string stopWord = queue.Dequeue();
                //we can terminate loop once we reached the endWord as all paths leads here already visited in previous level 
                if (stopWord.Equals(endWord))
                {
                    return paths[endWord];
                }
                else
                {
                    if (visited.Contains(stopWord))
                        continue;

                    visited.Add(stopWord);

                    //Transform word to intermidiate words and find matches
                    for (int i = 0; i < stopWord.Length; i++)
                    {

                        StringBuilder sb = new StringBuilder(stopWord);
                        sb[i] = '*';
                        string transform = sb.ToString();

                        if (graph.ContainsKey(transform))
                        {

                            //Iterating all adj words
                            foreach (var word in graph[transform])
                            {
                                if (!visited.Contains(word))
                                {
                                    //fetch all paths leads current word to generate paths to adj/child node 
                                    foreach (var path in paths[stopWord])
                                    {

                                        List<string> newPath = new List<string>(path);
                                        newPath.Add(word);

                                        if (!paths.ContainsKey(word))
                                            paths[word] = new List<List<string>>() { newPath };
                                        else if (paths[word][0].Count >= newPath.Count)// we are interested in shortest paths only
                                            paths[word].Add(newPath);
                                    }
                                    queue.Enqueue(word);
                                }
                            }
                        }
                    }
                }

            }

            return new List<List<string>>();

        }

        //For example word hit can be written as *it,h*t,hi*. 
        //This method genereates a map from each intermediate word to possible words from our wordlist
        private void AddWordToGraph(string word, Dictionary<string, HashSet<string>> graph)
        {

            for (int i = 0; i < word.Length; i++)
            {

                StringBuilder sb = new StringBuilder(word);
                sb[i] = '*';

                if (graph.ContainsKey(sb.ToString()))
                    graph[sb.ToString()].Add(word);
                else
                {
                    HashSet<string> set = new HashSet<string>();
                    set.Add(word);
                    graph[sb.ToString()] = set;
                }

            }

        }
    }
}
