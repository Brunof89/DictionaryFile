using System;
using System.Collections.Generic;
using System.IO;

namespace DictionaryFile.Infrastructure
{
    public class FileService : IFileService
    {
        public FileService()
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
        public void CreateOutputFile(string fileName, IEnumerable<IEnumerable<string>> resultList)
        {
            List<string> output = new List<string>();
            foreach(List<string> list in resultList)
            {
                output.Add(string.Join(';', list));
            }
            System.IO.File.WriteAllLines(fileName, output);
        }
    }
}
