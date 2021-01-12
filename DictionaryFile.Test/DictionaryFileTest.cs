using DictionaryFile.Domain.Requests;
using DictionaryFile.Domain.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace DictionaryFile.Test
{
    public class Tests
    {
        private IDictionaryFileService dictionaryFileService;

        [SetUp]
        public void Setup()
        {
            this.dictionaryFileService = new DictionaryFileService();
        }

        [Test]
        public void CheckIfFileExistsTestTrue()
        {
            var exists = this.dictionaryFileService.CheckFileExists("C:/Projectos/DictionaryFile/DictionaryFile/DictionaryFile/words-english.txt");

            if (exists)
                Assert.Pass();
            else
                Assert.Fail();
        }

        [Test]
        public void CheckIfFileExistsTestFalse()
        {
            var notExists = !this.dictionaryFileService.CheckFileExists("C:/Projectos/DictionaryFile/DictionaryFile/DictionaryFile/words-portuguese.txt");

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
        public void GetStringDifferenceTestTrue()
        {
            var difference = this.dictionaryFileService.GetStringIndexDifference("ward", "word");
            Assert.AreEqual(difference,new List<int> { 1 });
        }


        [Test]
        public void GetStringDifferenceTestFalse()
        {
            var difference = this.dictionaryFileService.GetStringIndexDifference("ward", "word");
            Assert.AreNotEqual(difference, new List<int> { 2 });
        }


        [Test]
        public void ValidateWordsTestTrue()
        {
            //var inputWords = new string[] { "rant", "rape", "rapt", "rare", "rasa", "rash", "rasp", "rata", "rate" };
            var inputWords = new string[] { "rant", "ront", "rott", "rotu"};
            var result = new string[] { "rant", "ront", "rotu"};

            var difference = this.dictionaryFileService.GetValidWords(inputWords, new DictionaryFileRequest 
            {
                EndWord = "rotu",
                FileName ="input",
                ResultFileName ="output",
                StartWord= "rant"
            });
            Assert.AreEqual(difference, result);
        }


        [Test]
        public void ValidateWordsTestFalse()
        {
            var inputWords = new string[] { "rant", "ront", "rott", "rotu" };
            var result = new string[] { "rant", "ront", "rotu" };

            var difference = this.dictionaryFileService.GetValidWords(inputWords, new DictionaryFileRequest
            {
                EndWord = "rotu",
                FileName = "input",
                ResultFileName = "output",
                StartWord = "rant"
            });
            Assert.AreNotEqual(difference, inputWords);
        }

    }
}