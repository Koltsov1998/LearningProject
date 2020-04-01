using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningProject.API.Contracts
{
    public class ParsedMemeContract
    {
        public int Id { set; get; }

        public string Url { set; get; }

        public string Text { get; set; }
    }
}
