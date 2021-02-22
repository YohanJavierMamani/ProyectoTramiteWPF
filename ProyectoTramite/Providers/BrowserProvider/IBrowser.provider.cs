using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTramite.Providers.BrowserProvider
{

    interface IBrowserProvider
    {
        public Task<HttpListenerContext> openBrowser(String state, String code_challenge, String code_challenge_method,String redirectURI);
    }
}
