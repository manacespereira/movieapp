using MovieApp.Helpers;
using MovieApp.Models;
using MovieApp.Services;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MovieApp.ViewModels
{
    public class MoviesListPageViewModel : ViewModelBase
    {
        public MoviesListPageViewModel(INavigationService navigationService, MovieService movieService)
            : base(navigationService)
        {
            this.movieService = movieService;
            CurrentPage = 1;

            OpenDetailsCommand = new DelegateCommand<Movie>(ExecuteOpenDetailsCommand);
            SizeChangedCommand = new DelegateCommand(ExecuteSizeChangedCommand);
            RefreshCommand = new DelegateCommand(ExecuteRefreshCommand);
            ScrollEndCommand = new DelegateCommand<Movie>(ExecuteScrollEndCommand);
            SizeChangedCommand.Execute();
            LoadData();
        }

        private readonly MovieService movieService;

        public ObservableCollection<Movie> Movies { get; set; }

        public int ColumnsPerRow { get; set; }
        public int CurrentPage { get; set; }

        public DelegateCommand<Movie> OpenDetailsCommand { get; set; }
        public DelegateCommand<Movie> ScrollEndCommand { get; set; }
        public DelegateCommand SizeChangedCommand { get; set; }
        public DelegateCommand RefreshCommand { get; set; }


        async void ExecuteOpenDetailsCommand(Movie movie)
        {
            await NavigationService.NavigateAsync("MovieDetailsPage", new NavigationParameters { { "selectedMovie", movie } });
        }

        void ExecuteSizeChangedCommand()
        {
            ColumnsPerRow = DeviceDisplay.MainDisplayInfo.Orientation == DisplayOrientation.Portrait ? 2 : 3;
        }

        async void ExecuteRefreshCommand()
        {
            await Task.Run(async () =>
            {
                Movies = null;
                await LoadData();
            });
        }

        void ExecuteScrollEndCommand(Movie movie)
        {
            CurrentPage++;
            LoadData();
        }

        async Task LoadData()
        {
            var repo = new Repository();

            if (!repo.GenresWasLoaded())
                repo.AddGenres(movieService.GetAllGenres().Genres);

            IsLoading = true;

            var response = await Task.Run(() => movieService.GetUpcoming(page: CurrentPage));

            var movies = response.Results;
            movies.ForEach(movie =>
            {
                movie.BackdropPath = $"{Consts.BASE_IMAGE_URL}/{movie.BackdropPath}";
                movie.PosterPath = $"{Consts.BASE_IMAGE_URL}/{movie.PosterPath}";
                movie.Genres = repo.GetGenresByIdList(movie.GenreIds.ToList());
            });

            if (Movies == null)
                Movies = new ObservableCollection<Movie>();

            foreach (var item in movies)
                Movies.Add(item);

            IsLoading = false;
        }
    }
}
