using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningProject.Services
{
    public interface IMemeService
    {
        Task ParsePhotosFromPublic(int publicId);
    }
}
