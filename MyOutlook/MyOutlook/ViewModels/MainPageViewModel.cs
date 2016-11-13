using System;
using System.Collections.Generic;
using MyOutlook.Models;
using MyOutlook.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;

namespace MyOutlook.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private IPageDialogService _pageDialogService;
        private INavigationService _navigationService;

        private List<Message> _messages;

        public List<Message> Messages
        {
            get { return _messages; }
            set
            {
                SetProperty(ref _messages, value);
            }
        }

        public DelegateCommand<Message> ShowMessageCommand => new DelegateCommand<Message>(
            async (message) =>
            {
                var p = new NavigationParameters();
                p.Add("message", message);

                await _navigationService.NavigateAsync(nameof(DetailPage), p);
            }
            );

        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            try
            {
                Messages?.Clear();

                if (!await AuthUtility.AuthAsync())
                {
                    await _pageDialogService.DisplayAlertAsync("错误", "用户认证失败！", "OK");
                }
                else
                {
                    Messages = await EmailUtility.GetListAsync();
                }
            }
            catch (Exception ex)
            {
                await _pageDialogService.DisplayAlertAsync("错误", ex.Message, "OK");
            }
        }
    }
}
