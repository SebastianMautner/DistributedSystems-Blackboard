import sys
sys.path.insert(0, "gen-py")

from thrift.transport import TSocket
from thrift.transport import TTransport
from thrift.protocol import TBinaryProtocol

from blackboard import BlackboardService

SERVER_HOST = "192.168.178.169" # Replace with the correct IP
SERVER_PORT = "9090"

def main():
    socket = TSocket.TSocket(SERVER_HOST, SERVER_PORT)
    transport = TTransport.TBufferedTransport(socket)
    protocol = TBinaryProtocol.TBinaryProtocol(transport)

    client = BlackboardService.Client(protocol)

    method = sys.argv[1].lower() if len(sys.argv) > 1 else None
    key = sys.argv[2] if len(sys.argv) > 2 else None
    value = sys.argv[3] if len(sys.argv) > 3 else None

    if method != "get" and method != "put":
        print(f"{method} is not a valid method!")
        return 

    try:
        transport.open()

        result = ""
        if method == "put":
            result = client.Put(key, value)
        else:
            result = client.Get(key)
        print(f"{result}")

    finally:
        transport.close()

if __name__ == "__main__":
    main()
