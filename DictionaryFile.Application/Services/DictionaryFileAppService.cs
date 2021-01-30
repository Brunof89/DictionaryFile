using DictionaryFile.Domain.Requests;
using DictionaryFile.Domain.Services;
using DictionaryFile.Infrastructure;
using System;
using System.Collections.Generic;

namespace DictionaryFile.Application
{
    public class DictionaryFileAppService: IDictionaryFileAppService
    {
        private readonly IDictionaryFileService _dictionaryFileService;
        private readonly IFileService _fileService;
        public DictionaryFileAppService(IDictionaryFileService dictionaryFileService,
            IFileService fileService)
        {
            this._dictionaryFileService = dictionaryFileService;
            this._fileService = fileService;
        }

        public bool CheckWordLength(string word, int length)
        {
            return this._dictionaryFileService.CheckWordLength(word, length);
        }

        public void ProcessWords(DictionaryFileRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("Request is empty");

            String[] words = _fileService.ReadFile(request.FileName);

            IEnumerable<IEnumerable<string>> resultList = _dictionaryFileService.ProcessWords(request, words);

            _fileService.CreateOutputFile(request.ResultFileName, resultList);
        }
    }
}
