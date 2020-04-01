using LearningProject.API.Contracts;
using System.Collections.Generic;

namespace LearningProject.Services
{
    public interface IMemeManagerService
    {
        IEnumerable<ParsedMemeContract> GetParsedMemes(int publicId);
    }
}
