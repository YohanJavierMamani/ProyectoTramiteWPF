using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProyectoTramite.Requester;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTramite.Helpers
{
    public class Requester<T>
    {

        HttpClient client = new HttpClient(new InterceptorHandler());

        public async Task<T> LoginRestServiceDataAsync(String serviceAddres,String usuario, String contraseña)
        {
            HttpClient clientLogin = new HttpClient();
            clientLogin.BaseAddress = new Uri(ConfigurationManager.AppSettings.Get("APILOGIN"));
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(usuario+":"+ contraseña);
            String stringbase64 = System.Convert.ToBase64String(plainTextBytes);
            clientLogin.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",stringbase64);
            clientLogin.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await clientLogin.PostAsync(serviceAddres,null).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(jsonResult);
            return result;
        }

        public async Task<T> GetRestServiceDataAsync(String serviceAddres, dynamic parameters)
        {
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings.Get("APILOGIN"));
            var response = await client.GetAsync(QueryHelpers.AddQueryString(serviceAddres, parameters));
            response.EnsureSuccessStatusCode();
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(jsonResult);
            return result;
        }


        public async Task<T> PostRestServiceDataAsync(String serviceAddres, dynamic parameters, dynamic body)
        {
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings.Get("API"));
            var response = await client.PostAsync(QueryHelpers.AddQueryString(serviceAddres, parameters), body).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(jsonResult);
            return result;
        }


    }
}
