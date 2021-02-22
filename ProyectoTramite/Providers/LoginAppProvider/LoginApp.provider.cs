using ProyectoTramite.Helpers;
using ProyectoTramite.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTramite.Providers.LoginAppProvider
{
    class LoginAppProvider : ILoginAppProvider
    {
        public async Task<TokenModel> LoginUsuario(object dataUsuario)
        {
            var values = (object[])dataUsuario;
            var parameters = new Dictionary<string, string> { };
            var service = new Requester<TokenModel>();
            return await service.LoginRestServiceDataAsync("servicio-auth/auth", (string)values[0], (string)values[1]);
        }
    }
}
