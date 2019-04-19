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
            SearchCommand = new DelegateCommand<string>(ExecuteSearchCommand);
            LoadMoreCommand = new DelegateCommand(ExecuteLoadMoreCommand);
            SizeChangedCommand.Execute();
            LoadData();
        }

        private readonly MovieService movieService;

        public ObservableCollection<Movie> Movies { get; set; }

        //Only used to filter
        private List<Movie> moviesToFilter { get; set; } = new List<Movie>();

        public int ColumnsPerRow { get; set; }
        public int CurrentPage { get; set; }

        public DelegateCommand<Movie> OpenDetailsCommand { get; set; }
        public DelegateCommand LoadMoreCommand { get; set; }
        public DelegateCommand SizeChangedCommand { get; set; }
        public DelegateCommand<string> SearchCommand { get; set; }


        async void ExecuteOpenDetailsCommand(Movie movie)
        {
            await NavigationService.NavigateAsync("MovieDetailsPage", new NavigationParameters { { "selectedMovie", movie } });
        }

        /// <summary>
        /// Execute when the user change device orientation
        /// </summary>
        void ExecuteSizeChangedCommand()
        {
            ColumnsPerRow = DeviceDisplay.MainDisplayInfo.Orientation == DisplayOrientation.Portrait ? 2 : 3;
        }

        void ExecuteSearchCommand(string filter)
        {
            if(string.IsNullOrEmpty(filter))
            {
                Movies = new ObservableCollection<Movie>(moviesToFilter);
                return;
            }
            Movies = new ObservableCollection<Movie>(moviesToFilter.Where(x =>
                x.Title.ToLower().Contains(filter.ToLower()) ||
                x.ReleaseDate.ToString().Contains(filter)));
        }

        void ExecuteLoadMoreCommand()
        {
            CurrentPage++;
            LoadData();
        }

        async Task LoadData()
        {
            IsLoading = true;

            var repo = new Repository();

            // Save locally all genres if it was not save before
            if (!repo.GenresWasLoaded())
                repo.AddGenres(movieService.GetAllGenres().Genres);

            var response = await Task.Run(() => movieService.GetUpcoming(page: CurrentPage));

            if (Movies == null)
                Movies = new ObservableCollection<Movie>();

            foreach (var item in response.Results)
                Movies.Add(item);

            moviesToFilter.AddRange(response.Results);

            IsLoading = false;
        }
    }
}
