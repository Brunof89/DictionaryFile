using DictionaryFile.Domain.Requests;
using DictionaryFile.Domain.Services;
using DictionaryFile.Infrastructure;
using NUnit.Framework;
using System.Collections.Generic;

namespace DictionaryFile.Test
{
    public class Tests
    {
        private IDictionaryFileService dictionaryFileService;
        private IFileService fileService;

        [SetUp]
        public void Setup()
        {
            this.fileService = new FileService();
            this.dictionaryFileService = new DictionaryFileService(fileService);
        }

        [Test]
        public void CheckIfFileExistsTestTrue()
        {
            var exists = this.fileService.CheckFileExists("C:/Projectos/DictionaryFile/DictionaryFile/DictionaryFile/words-english.txt");

            if (exists)
                Assert.Pass();
            else
                Assert.Fail();
        }

        [Test]
        public void CheckIfFileExistsTestFalse()
        {
            var notExists = !this.fileService.CheckFileExists("C:/Projectos/DictionaryFile/DictionaryFile/DictionaryFile/words-portuguese.txt");

            if (notExists)
                Assert.Pass();
            else
                Assert.Fail();
        }

        [Test]
        public void CheckWordLengthTestTrue()
        {
            Assert.IsTrue(this.dictionaryFileService.CheckWordLength("word", 4));
        }

        [Test]
        public void CheckWordLengthTestFalse()
        {
            Assert.IsFalse(this.dictionaryFileService.CheckWordLength("words", 4));
        }

  


        [Test]
        public void ValidateWordsTestTrue()
        {
            //var inputWords = new string[] { "rant", "rape", "rapt", "rare", "rasa", "rash", "rasp", "rata", "rate" };
            var inputWords = new string[] { "rant", "ront", "rott", "rotu"};
            var result = new string[] { "rant", "ront", "rotu"};

            this.dictionaryFileService.ProcessWords(new DictionaryFileRequest 
            {
                EndWord = "rotu",
                FileName ="input",
                ResultFileName ="output",
                StartWord= "rant"
            });
            //Assert.AreEqual(difference, result);
        }


        [Test]
        public void ValidateWordsTestFalse()
        {
            var inputWords = new string[] { "rant", "ront", "rott", "rotu" };
            var result = new string[] { "rant", "ront", "rotu" };

            this.dictionaryFileService.ProcessWords(new DictionaryFileRequest
            {
                EndWord = "rotu",
                FileName = "input",
                ResultFileName = "output",
                StartWord = "rant"
            });
            //Assert.AreNotEqual(difference, inputWords);
        }

    }
}