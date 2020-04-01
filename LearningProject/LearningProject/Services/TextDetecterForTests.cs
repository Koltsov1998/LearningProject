using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LearningProject.Services
{
    public class TextDetecterForTests : ITextDetecter
    {
        public async Task<string> DetectText(string photoRef)
        {
            Thread.Sleep(1000);
            return "text string";
        }
    }
}
