using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LearningProject.Services
{
    public class TesseractTextDetector : ITextDetecter
    {
        public async Task<string> DetectText(string photoRef)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C python.exe /p C:/Projects/PycharmProjects/TestingOCR/TextDetection.py --image C:/Projects/PycharmProjects/TestingOCR/pic.jpg >> C:/Projects/PycharmProjects/TestingOCR/test3.txt";

            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            return "";
        }
    }
}
