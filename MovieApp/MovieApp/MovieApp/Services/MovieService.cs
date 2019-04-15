using MovieApp.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Services
{
    public class MovieService : BaseService<Movie>
    {
        private readonly RestClient Client;

        public MovieService()
        {
            Client = CreateClient();
        }
    }
}
