using DictionaryFile.Domain.Requests;
using DictionaryFile.Domain.Services;
using DictionaryFile.Infrastructure;
using NUnit.Framework;
using System;
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
            var inputWords = new string[] { "spin", "spit", "spat", "spot", "span" };
            var r1 = new List<string> { "spin", "spit", "spot" };
            var result = new List<List<string>> { r1 };

            var difference = this.dictionaryFileService.ProcessWords(new DictionaryFileRequest
            {
                EndWord = "spot",
                FileName = "input",
                ResultFileName = "output",
                StartWord = "spin",
                WordLength = 4
            }, inputWords);
            Assert.AreEqual(difference, result);
        }

        [Test]
        public void ValidateWordsTestFalse()
        {
            var inputWords = new string[] { "spin", "spit", "spat", "spot","span" };
            var r1 = new List<string> { "spin", "spat", "spot" };
            var result = new List<List<string>> { r1 };

            var difference = this.dictionaryFileService.ProcessWords(new DictionaryFileRequest
            {
                EndWord = "spot",
                FileName = "input",
                ResultFileName = "output",
                StartWord = "spin",
                WordLength = 4
            }, inputWords);
            Assert.AreNotEqual(difference, result);
        }

        [Test]
        public void ValidateWordsTestNullInput()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => { this.dictionaryFileService.ProcessWords(null, null); });
            Assert.AreEqual("Request is empty", exception.ParamName);

        }

        [Test]
        public void ValidateWordsTestTrueReverse()
        {
            var inputWords = new string[] { "spin", "spit", "spat", "spot", "span" };
            var r1 = new List<string> { "spot", "spit", "spin" };
            var result = new List<List<string>> { r1 };

            var difference = this.dictionaryFileService.ProcessWords(new DictionaryFileRequest
            {
                EndWord = "spin",
                FileName = "input",
                ResultFileName = "output",
                StartWord = "spot",
                WordLength = 4
            }, inputWords);
            Assert.AreEqual(difference, result);
        }

        [Test]
        public void ValidateWordsTestFalseReverse()
        {
            var inputWords = new string[] { "spin", "spit", "spat", "spot", "span" };
            var r1 = new List<string> { "spin", "spit", "spot" };
            var result = new List<List<string>> { r1 };

            var difference = this.dictionaryFileService.ProcessWords(new DictionaryFileRequest
            {
                EndWord = "spin",
                FileName = "input",
                ResultFileName = "output",
                StartWord = "spot",
                WordLength = 4
            }, inputWords);
            Assert.AreNotEqual(difference, result);
        }

    }
}