using Prism;
using Prism.Ioc;
using MovieApp.ViewModels;
using MovieApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DLToolkit.Forms.Controls;
using MovieApp.Services;
using MovieApp.Resources;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MovieApp
{
    public partial class App
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer)
        {
            // Only works in Debug MODE.
            #if DEBUG
            HotReloader.Current.Start(this);
            #endif

            FlowListView.Init();

            // Set the culture info of device
            SetCultureInfo();
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync("MoviesListPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register of navigations pages
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MoviesListPage, MoviesListPageViewModel>();
            containerRegistry.RegisterForNavigation<MovieDetailsPage, MovieDetailsPageViewModel>();

            // Register of services
            containerRegistry.RegisterSingleton<MovieService>();
        }

       void SetCultureInfo ()
        {
            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
            {
                var ci = DependencyService.Get<ICultureService>().GetCurrentCultureInfo();
                AppResources.Culture = ci;
                DependencyService.Get<ICultureService>().SetLocale(ci);
            }
        }
    }
}
