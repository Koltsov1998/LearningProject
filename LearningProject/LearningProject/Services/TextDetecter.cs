using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GRPC.Client;

namespace LearningProject.Services
{
    public class TextDetecter : ITextDetecter
    {
        public async Task<string> DetectText(string photoRef)
        {
            var grpcClient = new PyTesseractService();

            using (WebClient client = new WebClient())
            {
                client.DownloadFile(new Uri(photoRef), @"c:\temp\image.jpg");
            }
            var reply = grpcClient.ParseImage(@"c:\temp\image.jpg");

            File.Delete(@"c:\temp\image.jpg");
            return reply;
        }
    }
}
