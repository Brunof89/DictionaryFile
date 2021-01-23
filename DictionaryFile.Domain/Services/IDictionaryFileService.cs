using DictionaryFile.Domain.Requests;
using System;
using System.Collections.Generic;

namespace DictionaryFile.Domain.Services
{
    public interface IDictionaryFileService
    {
        void ProcessWords(DictionaryFileRequest request);
        bool CheckWordLength(string word, int length);
    }
}