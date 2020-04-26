using System;
using System.Collections.Generic;
using System.Text;
using GRPC.Client;
using LearningProject.Services;
using NUnit.Framework;

namespace Tests
{
    public class TesseractDetectorTest
    {
        [Test] 
        public void Test1()
        {
            var grpcClient = new PyTesseractService();
            var reply = grpcClient.ParseImage("C:\\Projects\\PycharmProjects\\TestingOCR\\test_image.jpg");
            ;
        }

        [Test]
        public void Test2()
        {
            TextDetecter textDetecter = new TextDetecter();
            textDetecter.DetectText("https://i.pinimg.com/originals/8f/25/fa/8f25fad665b454c775bc84bc82fe7061.jpg");
        }
    }
}
