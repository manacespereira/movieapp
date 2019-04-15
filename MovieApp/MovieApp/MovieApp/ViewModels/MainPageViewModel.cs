using Prism.Commands;
using Prism.Navigation;
using System.Collections.Generic;

namespace MovieApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Lista de Filmes";

            OpenDetailsCommand = new DelegateCommand<string>(ExecuteOpenDetailsCommand);

            Items = new List<string> { "Filme 1", "Filme 2", "Filme 3", "Filme 4", "Filme 5" };
        }

        public DelegateCommand<string> OpenDetailsCommand { get; set; }

        public List<string> Items { get; set; }


        void ExecuteOpenDetailsCommand(string movie)
        {
            App.Current.MainPage.DisplayAlert(movie, movie, "OK");
        }
    }
}
