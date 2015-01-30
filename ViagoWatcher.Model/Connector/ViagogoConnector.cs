using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using ViagoWatcher.Model.Connector.Dto;

namespace ViagoWatcher.Model.Connector
{
    public class ViagogoConnector
    {
        public IEnumerable<ProductDto> GetProduct(string url)
        {
            RestClient restClient = new RestClient();

            RestRequest restRequest = new RestRequest(url, Method.POST) {RequestFormat = DataFormat.Json};

            restRequest.AddBody(new
            {
                method = "GetGridData"
            });

            
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Accept-Encoding", "gzip,deflate");

            var response = restClient.Execute<List<ContentDto>>(restRequest);
            ContentDto deserializeObject = JsonConvert.DeserializeObject<ContentDto>(response.Content);
            return deserializeObject.Items;
        }
    }
}