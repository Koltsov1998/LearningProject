﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningProject.Services
{
    public interface ITextDetecter
    {
        Task<string> DetectText(string photoRef);
    }
}
