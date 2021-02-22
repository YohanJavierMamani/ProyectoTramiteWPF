using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTramite.Service
{
    class WebApiService
    {
        Uri urlBase = new Uri("https://192.168.140.2");


        public async Task<T> executeRequestPost<T>(object objectParams)
        {
            String requestUri = "/direccion/direcctionapp";

            var client = new HttpClient();
            client.BaseAddress = urlBase;
            String jsonData = JsonConvert.SerializeObject(objectParams);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(requestUri, content).ConfigureAwait(false);

            if(response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(json);
            }
            else
            {
                return default(T);
            }
        }

    }
}
