using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using ViagogoWatcher.Model.Connector.Dto;
using ViagoWatcher.Model.Connector.Dto;

namespace ViagogoWatcher.Model.Connector
{
    public interface IViagogoConnector
    {
        IEnumerable<ProductDto> GetProduct(string url);
    }

    public class ViagogoConnector : IViagogoConnector
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
            try
            {
                ContentDto deserializeObject = JsonConvert.DeserializeObject<ContentDto>(response.Content);
                return deserializeObject.Items;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}