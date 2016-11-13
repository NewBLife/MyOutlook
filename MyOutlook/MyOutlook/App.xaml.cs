using Microsoft.Identity.Client;
using MyOutlook.Views;
using Prism.Unity;
using Xamarin.Forms;

namespace MyOutlook
{
    public partial class App : PrismApplication
    {
        public static PublicClientApplication PCA = null;
        public static AuthenticationResult Authentication = null;

        public App(IPlatformInitializer initializer = null) : base(initializer)
        {
        }

        protected override void OnInitialized()
        {
            InitializeComponent();

            PCA = new PublicClientApplication(Constants.APPLICATION_ID);

            NavigationService.NavigateAsync("/RootPage/NavigationPage/MainPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<RootPage>();
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<SettingPage>();
            Container.RegisterTypeForNavigation<DetailPage>();
        }
    }
}
