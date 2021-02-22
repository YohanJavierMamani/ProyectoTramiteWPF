using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProyectoTramite.Models
{

    public class UsersModel
    {
        public UserModel[] amiibo { get; set; }
    }


    public class JsonUser
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public ObservableCollection<UserModel> data { get; set; }
        public Support support { get; set; }
    }

    public class Support
    {
        public string url { get; set; }
        public string text { get; set; }
    }

    public class UserModel
    {
        public int id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string avatar { get; set; }
    }


    public class UsuariosFrecuentesModel
    {
        public UsuarioFrecuenteModel[] Property1 { get; set; }
    }

    public class UsuarioFrecuenteModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string area { get; set; }
        public string sede { get; set; }
    }




}
