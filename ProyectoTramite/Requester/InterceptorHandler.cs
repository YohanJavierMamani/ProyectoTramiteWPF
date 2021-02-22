using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProyectoTramite.Requester
{
    class InterceptorHandler: DelegatingHandler
    {

        public InterceptorHandler()
        {
            InnerHandler = new HttpClientHandler();
        }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("Authorization", "Bearer "+ Properties.Settings.Default.AccessToken);
            var response = await base.SendAsync(request, cancellationToken);
            return response;
        }
    }
}
