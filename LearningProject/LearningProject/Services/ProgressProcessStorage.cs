using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningProject.Services
{
    public class ProgressProcessStorage
    {
        public Dictionary<int, Progress> Progresses = new Dictionary<int, Progress>();
    }

    public class Progress
    {
        public Progress(int total)
        {
            Total = total;
        }

        public int Done { get; set; }

        public int Total { get; }
    }
}
