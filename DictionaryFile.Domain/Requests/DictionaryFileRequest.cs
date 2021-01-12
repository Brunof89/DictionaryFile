using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryFile.Domain.Requests
{
    public class DictionaryFileRequest
    {
        public string FileName { get; set; }
        public string StartWord { get; set; }
        public string EndWord { get; set; }
        public string ResultFileName { get; set; }
        public int WordLength { get; set; }
    }
}
