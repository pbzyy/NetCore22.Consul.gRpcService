﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consul.gRpcService.Hosting.Consul.Entity
{
    public class ConsulService
    {
        public string IP { get; set; }
        public int Port { get; set; }
    }
}
