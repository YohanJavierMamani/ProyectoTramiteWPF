using ProyectoTramite.Helpers;
using ProyectoTramite.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTramite.Providers.UsuarioProvider
{
    public class UsuarioProvider : IUsuarioProvider
    {
        public async Task<CreateUserModel> addUsuario(object dataUsuario)
        {
            var values = (object[])dataUsuario;
            var formContent = new FormUrlEncodedContent(new[]
            {
            new KeyValuePair<string, string>("name", (string)values[0]),
            new KeyValuePair<string, string>("job", (string)values[1])
            });
            var parameters = new Dictionary<string, string> { };
            var service = new Requester<CreateUserModel>();
            return await service.PostRestServiceDataAsync("users", parameters, formContent);
        }

        public async Task<ObservableCollection<UserModel>>  listarUsuarios(String page)
        {
            var parameters = new Dictionary<string, string>
            {
                ["page"] = page,
            };
            var service = new Requester<JsonUser>();
            var repuestaData = await service.GetRestServiceDataAsync("users", parameters);
            return new ObservableCollection<UserModel>(repuestaData.data);
        }

        public async Task<ObservableCollection<UsuarioFrecuenteModel>> listarUsuariosFrecuentes()
        {
            var parameters = new Dictionary<string, string>
            {
                ["cantidad"] = 10.ToString()
            };
            var service = new Requester<ObservableCollection<UsuarioFrecuenteModel>>();
            var repuestaData = await service.GetRestServiceDataAsync("servicio-tramite/buzones/1/destinatariosfrecuentes", parameters);
            if (repuestaData == null)
            {
                return new ObservableCollection<UsuarioFrecuenteModel>();
            }
            return new ObservableCollection<UsuarioFrecuenteModel>(repuestaData);
        }
    }
}
