using MovieApp.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Services
{
    public class BaseService<T> where T : class
    {
        protected RestClient CreateClient()
        {
            var client = new RestClient("https://api.themoviedb.org/3/movie");
            return client;
        }
    }
}
