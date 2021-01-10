using DictionaryFile.Domain.Requests;
using System;
using System.Collections.Generic;

namespace DictionaryFile.Domain.Services
{
    public interface IDictionaryFileService
    {
        bool CheckFileExists(string fileName);
        void ProcessWords(DictionaryFileRequest request);
        bool CheckWordLength(string word, int length);
        List<int> GetStringIndexDifference(string a, string b);
        void CreateOutputFile(string fileName, List<string> resultList);
        String[] ReadFile(string fileName);
        List<string> GetValidWords(String[] words, DictionaryFileRequest request);
    }
}