using Thrift.Protocol;
using Thrift.Transport;
using Thrift.Server;

using blackboard;
using Blackboard_Server;
using Thrift.Transport.Server;
using Thrift.Processor;
using Microsoft.Extensions.Logging.Abstractions;

BlackboardService.IAsync handler = new Handler();
ITAsyncProcessor processor = new BlackboardService.AsyncProcessor(handler);

TServerTransport serverTransport = new TServerSocketTransport(9090, new());
TProtocolFactory factory = new TBinaryProtocol.Factory();

var server = new TSimpleAsyncServer(
    itProcessorFactory: new TSingletonProcessorFactory(processor),
    serverTransport: serverTransport,
    inputTransportFactory: null,
    outputTransportFactory: null,
    inputProtocolFactory: factory,
    outputProtocolFactory: factory,
    logger: NullLogger<TSimpleAsyncServer>.Instance 
);

Console.WriteLine("Starting Thrift server on port 9090...");

await server.ServeAsync(new());