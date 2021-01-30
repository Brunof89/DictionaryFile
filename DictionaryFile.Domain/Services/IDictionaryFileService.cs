using DictionaryFile.Domain.Requests;
using System;
using System.Collections.Generic;

namespace DictionaryFile.Domain.Services
{
    public interface IDictionaryFileService
    {
        IEnumerable<IEnumerable<string>> ProcessWords(DictionaryFileRequest request, String[] words);
        bool CheckWordLength(string word, int length);
    }
}