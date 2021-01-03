using DictionaryFile.Domain.Requests;
using System.Collections.Generic;

namespace DictionaryFile.Domain.Services
{
    public interface IDictionaryFileService
    {
        bool CheckFileExists(string fileName);
        void ProcessWords(DictionaryFileRequest request);
        bool CheckWordLength(string word, int length);
        List<int> GetStringIndexDifference(string a, string b);
    }
}