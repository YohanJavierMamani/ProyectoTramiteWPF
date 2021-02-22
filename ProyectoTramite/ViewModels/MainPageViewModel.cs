using ProyectoTramite.Helpers;
using ProyectoTramite.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProyectoTramite.ViewModels
{
    public class MainPageViewModel
    {
        public ObservableCollection<Amiibo> Amiibos { set; get; }

        public ICommand SearchCommand { get; set; }

        public MainPageViewModel()
        {
            //SearchCommand = new Command(async()=>{

            //});
        }

        public async Task LoadCharacters()
        {
            var url = "https://www.amiiboapi.com/api/amiibo/";
            var parameters = new Dictionary<string, string>
            {
                ["character"] = "mario",
            };
            var service = new Requester<Amiibos>();
            var amiibos = await service.GetRestServiceDataAsync(url, parameters);
            Amiibos = new ObservableCollection<Amiibo>(amiibos.amiibo);
        }
    }
}
