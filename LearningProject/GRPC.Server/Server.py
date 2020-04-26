import grpc
import logging
from concurrent import futures
import PyTesseract_pb2
import PyTesseract_pb2_grpc
from TextDetection import parse_image

class PyTesseractServer(PyTesseract_pb2_grpc.PyTesseract):
    def ParseImage(self, request: PyTesseract_pb2.ParseImageRequest,
            target,
            options=(),
            channel_credentials=None,
            call_credentials=None,
            compression=None,
            wait_for_ready=None,
            timeout=None,
            metadata=None):
        reply = PyTesseract_pb2.ParseImageReply()
        reply.Text = parse_image(request.ImageUri)
        return reply

def serve():
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))
    PyTesseract_pb2_grpc.add_PyTesseractServicer_to_server(PyTesseractServer(), server)
    server.add_insecure_port('[::]:50051')
    server.start()
    print('serving on port 50051')
    server.wait_for_termination()

if __name__ == '__main__':
    logging.basicConfig()
    serve()