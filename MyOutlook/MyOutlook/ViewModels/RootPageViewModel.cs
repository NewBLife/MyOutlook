using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace MyOutlook.ViewModels
{
    public class RootPageViewModel : BindableBase
    {
        private INavigationService _navigationService { get; }

        private bool isPresented = false;

        public bool IsPresented
        {
            get { return this.isPresented; }
            set
            {
                this.SetProperty(ref this.isPresented, value);
            }
        }

        public DelegateCommand<string> NavigateCommand => new DelegateCommand<string>(
            (name) =>
            {
                _navigationService.NavigateAsync(name);
            }
            );

        public RootPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
