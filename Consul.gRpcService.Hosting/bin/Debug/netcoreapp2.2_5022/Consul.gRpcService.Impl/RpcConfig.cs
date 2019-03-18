﻿using System;
using System.Collections.Generic;
using System.Text;
using Consul.gRpcService.Impl.RpcService;
using Consul.GRpcService.Protocol;
using Grpc.Core;
using Microsoft.Extensions.Options;

namespace Consul.gRpcService.Impl
{
    public class RpcConfig : IRpcConfig
    {
        private static Server _server;
        static IOptions<Entity.GrpcService> GrpcSettings;

        public RpcConfig(IOptions<Entity.GrpcService> grpcSettings)
        {
            GrpcSettings = grpcSettings;
        }

        public void Start()
        {
            _server = new Server
            {
                Services = { MsgService.BindService(new MsgServiceImpl()) },
                Ports = { new ServerPort(GrpcSettings.Value.IP, GrpcSettings.Value.Port, ServerCredentials.Insecure) }
            };
            _server.Start();

            Console.WriteLine($"Grpc ServerListening On Port {GrpcSettings.Value.Port}");
        }
    }
}
