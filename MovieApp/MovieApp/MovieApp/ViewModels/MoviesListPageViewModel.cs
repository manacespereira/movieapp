using MovieApp.Helpers;
using MovieApp.Models;
using MovieApp.Services;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
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

            OpenDetailsCommand = new DelegateCommand<Movie>(ExecuteOpenDetailsCommand);
            SizeChangedCommand = new DelegateCommand(ExecuteSizeChangedCommand);
            RefreshCommand = new DelegateCommand(ExecuteRefreshCommand);
            SizeChangedCommand.Execute();
            LoadData();
        }

        private readonly MovieService movieService;

        public ObservableCollection<Movie> Movies { get; set; }

        public int ColumnsPerRow { get; set; }

        public DelegateCommand<Movie> OpenDetailsCommand { get; set; }
        public DelegateCommand SizeChangedCommand { get; set; }
        public DelegateCommand RefreshCommand { get; set; }


        async void ExecuteOpenDetailsCommand(Movie movie)
        {
            await NavigationService.NavigateAsync("NavigationPage/MoviesListPage/MovieDetailsPage", new NavigationParameters { { "selectedMovie", movie } });
        }

        void ExecuteSizeChangedCommand()
        {
            ColumnsPerRow = DeviceDisplay.MainDisplayInfo.Orientation == DisplayOrientation.Portrait ? 2 : 3;
        }

        async void ExecuteRefreshCommand()
        {
            await Task.Run(async () =>
            {
                Movies = new ObservableCollection<Movie>();
                await LoadData();
            });
        }

        async Task LoadData()
        {
            IsLoading = true;
            var response = await Task.Run(() => movieService.GetUpcoming());
            var movies = response.Results;
            movies.ForEach(movie =>
            {
                movie.BackdropPath = $"{Consts.BASE_IMAGE_URL}/{movie.BackdropPath}";
                movie.PosterPath = $"{Consts.BASE_IMAGE_URL}/{movie.PosterPath}";
            });
            Movies = new ObservableCollection<Movie>(movies);
            IsLoading = false;
        }
    }
}
