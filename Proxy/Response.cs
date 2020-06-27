using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAJAX_.Net.Proxy
{
    public class Response
    {
        public int Codigo { get; set; }
        public bool Estado { get; set; }
        public string Mensaje { get; set; }
        public object Resultado { get; set; }

    }
}