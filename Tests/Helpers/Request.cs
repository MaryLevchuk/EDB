using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers;
using RestRequest = RestSharp.RestRequest;


namespace Tests.Helpers
{
    class Request
    {
       public IRestRequest RestRequest = new RestRequest();
       public Request(string url, Method method)
       {
            RestRequest.JsonSerializer = new RestSharp.Serializers.JsonSerializer();
        }
    }
}
