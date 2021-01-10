using DictionaryFile.Domain.Requests;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace DictionaryFile.Domain.Services
{
    public class DictionaryFileService : IDictionaryFileService
    {
        public DictionaryFileService()
        {

        }

        /// <summary>
        /// Check if file exists.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool CheckFileExists(string fileName)
        {
            return File.Exists(fileName);
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
            String[] words = ReadFile(request.FileName);

            var resultList = ProcessWords(words, request);

            CreateOutputFile(request.ResultFileName, resultList);
        }

        /// <summary>
        /// Algorithim that processes list of words with the design pattern strategy or iterator and
        /// produces a output file.
        /// </summary>
        /// <param name="request"></param>
        public List<string> ProcessWords(String[]words,DictionaryFileRequest request)
        {
            //Get only short words
            var shortWords = words
                .Where(w => w.Length == 4)
                .OrderBy(w => w)
                .ToList();

            var startIndex = shortWords.IndexOf(request.StartWord);
            var endIndex = shortWords.IndexOf(request.EndWord);

            var remainingList = shortWords.Skip(startIndex).Take(endIndex - startIndex).ToList();
            int count = 0;
            List<string> resultList = new List<string>();
            List<int> changedIdxs = new List<int>();

            foreach (var word in remainingList)
            {
                if (count == 0)
                {
                    resultList.Add(word);
                }
                else
                {
                    var idx = GetStringIndexDifference(remainingList[count - 1], remainingList[count]);
                    if (changedIdxs.Intersect(changedIdxs).Count() == 0 && idx.Count() == 1)
                    {
                        changedIdxs.AddRange(idx);
                        resultList.Add(word);
                    }
                }
                count++;
            }

            return resultList;
        }

        /// <summary>
        /// Returns the index of the differente character. If Equal returns -1.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public List<int> GetStringIndexDifference(string a, string b)
        {
            List<int> idxs = new List<int>();
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    idxs.Add(i);
                }
            }

            return idxs;
        }

        /// <summary>
        /// Reads file given the file path.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public String[] ReadFile(string fileName)
        {
            return System.IO.File.ReadAllLines(fileName);
        }

        /// <summary>
        /// Creates the output file given a list os strings
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="resultList"></param>
        public void CreateOutputFile(string fileName, List<string> resultList)
        {
            System.IO.File.WriteAllLines(fileName, resultList);
        }
    }
}
