using ProyectoTramite.Models;
using ProyectoTramite.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProyectoTramite.ViewModels
{
    class PersonaViewModel : BaseViewModel
    {
        WebApiService webApi = new WebApiService();

        private ObservableCollection<EmpleadoModel> listaEmpleados;

        public ObservableCollection<EmpleadoModel> ListaEmpleados
        {
            get { return listaEmpleados; }
            set
            {
                listaEmpleados = value;
                OnPropertyChanged();
            }
        }

        private string id;

        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        public ICommand ConsultaListaEmpleadosPostCommand { get; set; }


        public PersonaViewModel()
        {
            //ConsultaListaEmpleadosPostCommand = new Command(async () => await ConsultaListaEmpleadosPost());
        }

        public async Task ConsultaListaEmpleadosPost()
        {
            var paramsPost = new { IdEmpresa = Id};
            ListaEmpleados = await webApi.executeRequestPost<ObservableCollection<EmpleadoModel>>(paramsPost);
        }

    }
}
