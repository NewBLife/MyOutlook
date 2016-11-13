using MyOutlook.Models;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace MyOutlook.ViewModels
{
    public class DetailPageViewModel : BindableBase, INavigationAware
    {
        private IPageDialogService _pageDialogService;

        private string _title = string.Empty;

        public string Title
        {
            get { return _title; }
            set
            {
                SetProperty(ref _title, value);
            }
        }

        private string _html = string.Empty;

        public string Html
        {
            get { return _html; }
            set
            {
                SetProperty(ref _html, value);
                OnPropertyChanged(nameof(Content));
            }
        }

        public HtmlWebViewSource Content
        {
            get { return new HtmlWebViewSource { Html = Html }; }
        }


        public DetailPageViewModel(IPageDialogService pageDialogService)
        {
            _pageDialogService = pageDialogService;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("message"))
            {
                var message = parameters["message"] as Message;
                if (message != null)
                {
                    Title = message.subject;
                    Html = message.body.content;
                }
                else
                {
                    await _pageDialogService.DisplayActionSheetAsync("错误", "请选择邮件！", "OK");
                }
            }
        }
    }
}
