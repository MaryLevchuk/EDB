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

        public int IngredientsNumber = 0;
        public int InstructionsNumber = 0;
        public int TechniquesNumber = 0;
        public int GuidesNumber = 0;

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

        public IRestResponse GetAllGuides()
        {
            var request = Get(ConfigurationManager.AppSettings["Guides"]);
            IRestResponse response = Client.Execute(request);
            return response;
        }

        public IRestResponse GetAllInstructions()
        {
            var request = Get(ConfigurationManager.AppSettings["Instructions"]);
            IRestResponse response = Client.Execute(request);
            return response;
        }

        public IRestResponse GetAllTechniques()
        {
            var request = Get(ConfigurationManager.AppSettings["Techniques"]);
            IRestResponse response = Client.Execute(request);
            return response;
        }

        public int GetNumberOfItems(IRestResponse response)
        {
            JArray objects = JsonConvert.DeserializeObject<JArray>(response.Content);
            return objects.Count;
        }

        public void GetItemsNumber()
        {
            IngredientsNumber = GetNumberOfItems(GetAllIngredients());
            GuidesNumber = GetNumberOfItems(GetAllGuides());
            InstructionsNumber = GetNumberOfItems(GetAllInstructions());
            TechniquesNumber = GetNumberOfItems(GetAllTechniques());
        }
    }
}
