using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace LeksikonTests.Helpers
{
    public class ClientRequest
    {
        public IRestClient Client = new RestClient(ConfigurationManager.AppSettings["ApiUrl"]);
        public IRestRequest Request = new RestRequest();
        public string Url;

        public ClientRequest()
        {
            Request.AddHeader("Accept", "application/json");
        }

        public IRestRequest Get(string url)
        {
            Request.Resource = url;
            Request.Method = Method.GET;
            return Request;
        }

        public IRestResponse GetAllIngredients()
        {
            var request = Get(ConfigurationManager.AppSettings["Ingredients"]);
            IRestResponse response = Client.Execute(request);
            return response;
        }

        public int GetNumberOfIngredients(IRestResponse response)
        {
            JArray objects = JsonConvert.DeserializeObject<JArray>(response.Content);
            return objects.Count;
        }

        public int GetIngredientsNumber()
        {
            int n= GetNumberOfIngredients(GetAllIngredients());
            return n;
        }
    }
}
