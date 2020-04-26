using System;
using Grpc.Core;
using PyTesseract.Generated;

namespace GRPC.Client
{
    public class PyTesseractService : IDisposable
    {
        private Channel _channel;
        private PyTesseract.Generated.PyTesseract.PyTesseractClient _client;
        public PyTesseractService()
        {
            _channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
            _client = new PyTesseract.Generated.PyTesseract.PyTesseractClient(_channel);
        }

        public string ParseImage(string Uri)
        {
            return _client.ParseImage(new ParseImageRequest
            {
                ImageUri = Uri,
            }).Text;
        }

        public void Dispose()
        {
            _channel.ShutdownAsync().Wait();
        }
    }
}
