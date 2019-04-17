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
        
        public Response<List<Movie>> GetUpcoming (string filter = "", int page = 1)
        {
            return Get<List<Movie>>($"/movie/upcoming?api_key={Consts.API_KEY}&language=en-US&page={page}");
        }

        public Response<List<Genre>> GetAllGenres()
        {
            return Get<List<Genre>>($"/genre/movie/list?api_key={Consts.API_KEY}&language=en-US");
        }

    }
}
