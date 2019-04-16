using Prism;
using Prism.Ioc;
using MovieApp.ViewModels;
using MovieApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DLToolkit.Forms.Controls;
using MovieApp.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MovieApp
{
    public partial class App
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer)
        {
            LiveReload.Init();
            FlowListView.Init();
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("MoviesListPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MoviesListPage, MoviesListPageViewModel>();

            containerRegistry.RegisterSingleton<MovieService>();
            containerRegistry.RegisterForNavigation<MovieDetailsPage, MovieDetailsPageViewModel>();
        }
    }
}
