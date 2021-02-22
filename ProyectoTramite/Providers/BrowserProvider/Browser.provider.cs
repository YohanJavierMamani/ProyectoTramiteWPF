using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTramite.Providers.BrowserProvider
{
    class BrowserProvider : IBrowserProvider
    {
        public async Task<HttpListenerContext> openBrowser(String state, String code_challenge, String code_challenge_method, String redirectURI)
        {
            var http = new HttpListener();
            http.Prefixes.Add(redirectURI);
            output("Listening..");
            http.Start();

            string authorizationRequest = string.Format("{0}?response_type=code&scope=openid%20profile&redirect_uri={1}&client_id={2}&state={3}&code_challenge={4}&code_challenge_method={5}",
                ConfigurationManager.AppSettings.Get("authorizationEndpoint"),
                System.Uri.EscapeDataString(redirectURI),
                ConfigurationManager.AppSettings.Get("clientID"),
                state,
                code_challenge,
                code_challenge_method);

            System.Diagnostics.Process.Start(new ProcessStartInfo(authorizationRequest) { UseShellExecute = true });

            var context = await http.GetContextAsync();

            var response = context.Response;
            String pageHtml = @File.ReadAllText(@"Resources/Templates/RedirectPage.html");
            String pageCss = @File.ReadAllText(@"Resources/Static/scss/Style.scss");
            String pageJs = @File.ReadAllText(@"Resources/Static/js/JavaScript.js");
            byte[] imageArray = System.IO.File.ReadAllBytes(@"Resources/Static/img/logo-header.png");
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);
            string responseString = string.Format("<html><head><meta http-equiv='refresh' content='10;url=https://google.com'></head><body>Please return to the app.</body></html>");
            pageHtml = pageHtml.Replace("<part-style></part-style>", "<style>"+pageCss+"</style>");
            pageHtml = pageHtml.Replace("<part-javaScript></part-javaScript>", "<script <script type='text/javascript'>" + pageJs +"</script>");
            pageHtml = pageHtml.Replace("<img-base64>",base64ImageRepresentation);
            var buffer = System.Text.Encoding.UTF8.GetBytes(pageHtml);
            response.ContentLength64 = buffer.Length;
            var responseOutput = response.OutputStream;

            Task responseTask = responseOutput.WriteAsync(buffer, 0, buffer.Length).ContinueWith((task) =>
            {
                responseOutput.Close();
                http.Stop();
                Console.WriteLine("HTTP server stopped.");
            });

            return context;
        }

        public void output(string output)
        {
            //textBoxOutput.Text = textBoxOutput.Text + output + Environment.NewLine;
            Console.WriteLine(output);
        }
    }
}
