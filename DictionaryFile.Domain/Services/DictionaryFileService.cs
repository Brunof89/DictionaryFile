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
        /// Processes list of words with the design pattern strategy or iterator and
        /// produces a output file.
        /// </summary>
        /// <param name="request"></param>
        public void ProcessWords(DictionaryFileRequest request)
        {
            String[] words = System.IO.File.ReadAllLines(request.FileName);

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

            foreach (var word in remainingList)
            {
                count++;
                if (count == 1)
                {
                    resultList.Add(word);
                }
                else
                {
                    var idx = GetStringIndexDifference(remainingList[count - 1], remainingList[count]);

                }
            }
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
    }
}
