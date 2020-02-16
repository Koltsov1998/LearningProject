using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningProject.API.Contracts;

namespace LearningProject.Services
{
    public interface IVkPublicService
    {
        IEnumerable<VkPublicContract> GetAllVkPublics();
    }
}
