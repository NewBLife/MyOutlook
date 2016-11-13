using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;

namespace MyOutlook.ViewModels
{
    public class SettingPageViewModel : BindableBase, INavigationAware
    {
        private IPageDialogService _pageDialogService;

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);
            }
        }

        private string _address;

        public string Address
        {
            get { return _address; }
            set
            {
                SetProperty(ref _address, value);
            }
        }

        public DelegateCommand LoginCommand => new DelegateCommand(
            async () =>
            {
                if (await AuthUtility.AuthAsync())
                {
                    loadUserInfo();
                }
                else
                {
                    await _pageDialogService.DisplayAlertAsync("错误", "用户认证失败！", "OK");
                }
                LogoutCommand.CanExecute();
            },
            () => App.Authentication?.Token == null
            );

        public DelegateCommand LogoutCommand => new DelegateCommand(
            () =>
            {
                App.Authentication.User.SignOut();
                LoginCommand.CanExecute();
            },
            () => App.Authentication?.User != null
            );

        public SettingPageViewModel(IPageDialogService pageDialogService)
        {
            _pageDialogService = pageDialogService;
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            loadUserInfo();
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }
        private void loadUserInfo()
        {
            Name = App.Authentication?.User?.Name;
            Address = App.Authentication?.User?.DisplayableId;
        }
    }
}
