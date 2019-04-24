using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MovieApp.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
            GoBackCommand = new DelegateCommand(ExecuteGoBackCommand);
        }

        public DelegateCommand GoBackCommand { get; set; }

        #region Properties

        public string Title { get; set; }

        public bool IsBusy { get; set; }

        public bool IsLoading { get; set; }

        #endregion

        async void ExecuteGoBackCommand()
        {
            await NavigationService.GoBackAsync();
        }

        #region Lifecycle Methods

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }

        #endregion
    }
}
