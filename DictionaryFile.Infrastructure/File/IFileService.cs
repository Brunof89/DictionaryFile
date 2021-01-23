using System;
using System.Collections.Generic;

namespace DictionaryFile.Infrastructure
{
    public interface IFileService
    {
        bool CheckFileExists(string fileName);
        void CreateOutputFile(string fileName, IEnumerable<IEnumerable<string>> resultList);
        String[] ReadFile(string fileName);
    }
}
