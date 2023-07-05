using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfKaKao.ViewModels
{
    [ObservableObject]
    public partial class MainWindowViewModel
    {
        // CurrentViewModel(property) 자동으로 생성;
        [ObservableProperty]
        private INotifyPropertyChanged? _currentViewModel;

        // ToLoginCommand -> Command지우기
        [RelayCommand]
        public void ToLogin()
        {
            CurrentViewModel = (INotifyPropertyChanged)App.Current.Services.GetService(typeof(LoginControlViewModel))!;

        }
        [RelayCommand]
        public void ToChangePwd()
        {
            CurrentViewModel = (INotifyPropertyChanged)App.Current.Services.GetService(typeof(ChangePwdControlViewModel))!;

        }
        [RelayCommand]
        public void ToSignup()
        {
            CurrentViewModel = (INotifyPropertyChanged)App.Current.Services.GetService(typeof(SignupControlViewModel))!;

        }

        public MainWindowViewModel()
        {
            // 처음 생성자 부분은 기본적으로 필드 변수로 세팅
            _currentViewModel = (INotifyPropertyChanged)App.Current.Services.GetService(typeof(LoginControlViewModel))!;
        }

    }
}
