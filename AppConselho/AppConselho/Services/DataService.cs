using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using AppConselho.Model;

namespace AppConselho.Services
{
     class DataService
    {
        public static async Task<Conselhos> GetConselhos()
        {
            string queryString = "https://api.adviceslip.com/advice";
            dynamic resultado = await getDataFromService(queryString).ConfigureAwait(false);

            if (resultado[""] != null)
            {
                Conselhos Conselhos = new Conselhos();

                Conselhos.Title = (string)resultado["slip"];
                Conselhos.Id = (string)resultado["id"];
                Conselhos.Conselho = (string)resultado["advice"];
                return Conselhos;



            }
            else
            {
                return null;
            }
        }

        public static async Task<dynamic> getDataFromService(string queryString)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(queryString);
            dynamic data = null;

            if (response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject<dynamic>(json);
            }
            return data;
        }

        public static async Task<dynamic> getDataFromServiceByMensage(string id)
        {
          

            string url = string.Format("https://api.adviceslip.com/advice");
            HttpClient client = new HttpClient();

            var response = await client.GetAsync(url);
            dynamic data = null;

            if (response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject(json);
            }
            return data;
        }
    }
}

