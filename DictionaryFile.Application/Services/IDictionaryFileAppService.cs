using DictionaryFile.Domain.Requests;

namespace DictionaryFile.Application
{
    public interface IDictionaryFileAppService
    {
        void ProcessWords(DictionaryFileRequest request);
        bool CheckWordLength(string word, int length);
    }
}