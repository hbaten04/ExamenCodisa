using ExamenCodisa.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExamenCodisa.Repository
{
    public class Service : IService
    {
        private string apiBaseUrl = string.Empty;
        IConfiguration configure;

        public Service(IConfiguration _configuration)
        {
            configure = _configuration;
            apiBaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
        }

        public IEnumerable<EmpleadoHabilidad> getListaHabilidad(int pIdEmpleado)
        {

            IEnumerable<EmpleadoHabilidad> habilidad = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseUrl + "api/");
                client.DefaultRequestHeaders.Clear();


                var response = client.GetAsync("EmpleadoHabilidad/" + pIdEmpleado);
                response.Wait();

                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync().Result; //result.Content.ReadAsAsync<IList<EmpleadoHabilidad>>();


                    habilidad = JsonConvert.DeserializeObject<List<EmpleadoHabilidad>>(readTask);
                }
                else //web api sent error response 
                {
                    //log response status here..

                    habilidad = Enumerable.Empty<EmpleadoHabilidad>();

                    // ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return habilidad;
        }
    }
}
