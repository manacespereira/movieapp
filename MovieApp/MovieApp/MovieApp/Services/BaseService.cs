using MovieApp.Helpers;
using MovieApp.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Services
{
    public class BaseService
    {
        protected RestClient Client;

        public BaseService()
        {
            Client = new RestClient(Consts.BASE_URL);
        }

        public Response<T> Get<T>(string url) where T : class
        {
            var request = new RestRequest(url, Method.GET);
            var response = Client.Execute<Response<T>>(request);
            return response.Data;
        }
    }
}
