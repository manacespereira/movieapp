using MovieApp.Helpers;
using MovieApp.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Services
{
    public class MovieService : BaseService
    {
        
        public Response<List<Movie>> GetUpcoming (string filter = "", int page = 1, int skip = 0)
        {
            return Get<List<Movie>>($"/upcoming?api_key={Consts.API_KEY}&language=en-US&page={page}");
        }

    }
}
