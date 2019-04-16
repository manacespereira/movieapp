using MovieApp.Helpers;
using MovieApp.Models;
using MovieApp.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MovieApp.ViewModels
{
    public class MoviesListPageViewModel : ViewModelBase
    {
        public MoviesListPageViewModel(INavigationService navigationService, MovieService movieService) 
            : base(navigationService)
        {
            Title = "Lista de Filmes";

            this.movieService = movieService;

            OpenDetailsCommand = new DelegateCommand<Movie>(ExecuteOpenDetailsCommand);
        }

        private readonly MovieService movieService;

        public ObservableCollection<Movie> Movies { get; set; }

        public DelegateCommand<Movie> OpenDetailsCommand { get; set; }


        void ExecuteOpenDetailsCommand(Movie movie)
        {
            
        }

        void LoadData ()
        {
            var response = movieService.GetUpcoming();
            var movies = response.Results;
            movies.ForEach(movie => {
                movie.BackdropPath = $"{Consts.BASE_IMAGE_URL}/{movie.BackdropPath}";
                movie.PosterPath = $"{Consts.BASE_IMAGE_URL}/{movie.PosterPath}";
            });
            Movies = new ObservableCollection<Movie>(movies);
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            LoadData();
        }
    }
}
