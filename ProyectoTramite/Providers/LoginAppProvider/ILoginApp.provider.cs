using ProyectoTramite.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTramite.Providers.LoginAppProvider
{
    interface ILoginAppProvider
    {
        public Task<TokenModel> LoginUsuario(object dataUsuario);
    }
}
