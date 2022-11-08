using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using AppConselho.Model;
using Microsoft.CSharp;

namespace AppConselho.Services
{
     class DataService
    {
        public static async Task<Conselhos> GetConselhos()
        {
            string queryString = "https://api.adviceslip.com/advice";
            dynamic resultado = await getDataFromService(queryString).ConfigureAwait(false);

            if (resultado["slip"] != null)
            {
                Conselhos Conselho = new Conselhos();

                
                Conselho.Slip_Id = (string)resultado["slip"]["id"];
                Conselho.Conselho = (string)resultado["slip"]["advice"];
                return Conselho;



            }
            else
            {
                return null;
            }
        }
        public static async Task<Conselhos> getConselhoByNum(string Conselho_Num)
        {


            string queryString = "https://api.adviceslip.com/advice/" + Conselho_Num;
            dynamic resultado = await getDataFromService(queryString).ConfigureAwait(false);


            if (resultado.slip != null)
            {
                Conselhos conselho = new Conselhos();
                conselho.Conselho = (string)resultado["slip"]["advice"];
                conselho.Slip_Id = (string)resultado["slip"]["id"];
                return conselho;
            }
            return null;
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

       
    }
}

