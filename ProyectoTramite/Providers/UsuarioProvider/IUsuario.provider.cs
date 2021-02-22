using ProyectoTramite.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTramite.Providers.UsuarioProvider
{
    interface IUsuarioProvider
    {
        public Task<ObservableCollection<UserModel>> listarUsuarios(String page);

        public Task<CreateUserModel> addUsuario(object dataUsuario);


        public Task<ObservableCollection<UsuarioFrecuenteModel>> listarUsuariosFrecuentes();


    }
}
