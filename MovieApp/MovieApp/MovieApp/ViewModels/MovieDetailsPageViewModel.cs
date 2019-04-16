using MovieApp.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp.ViewModels
{
	public class MovieDetailsPageViewModel : ViewModelBase
	{
        public MovieDetailsPageViewModel(INavigationService navigationService) 
            : base(navigationService)
        {
            
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            var movie = parameters.GetValue<Movie>("selectedMovie");
        }
    }
}
