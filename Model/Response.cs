using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http2.HPack;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Model
{
    public class Response
    {
        public object Body { get; set; }

        public bool Result { get; set; }

    }
}
