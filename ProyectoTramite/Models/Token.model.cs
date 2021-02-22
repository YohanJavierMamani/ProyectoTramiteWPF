using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoTramite.Models
{
    public class TokenModel
    {
        public string status { get; set; }
        public object message { get; set; }
        public Data data { get; set; }
        public bool success { get; set; }
    }

    public class Data
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
    }

}
