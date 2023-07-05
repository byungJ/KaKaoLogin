using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using WpfKaKao.ViewModels;

namespace WpfKaKao
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Services = ConfigureServices();
            Startup += App_Startup;

            //집컴에서 에러 발생
            //this.InitializeComponent();
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            var mainWindow = App.Current.Services.GetService<MainWindow>()!;
            mainWindow.Show();
        }

        public new static App Current => (App)Application.Current;
        public IServiceProvider Services { get; }
        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // viewModels (서비스 등록)
            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<LoginControlViewModel>();
            services.AddTransient<SignupControlViewModel>();
            services.AddTransient<ChangePwdControlViewModel>();

            // Views (서비스 등록)
            services.AddSingleton<MainWindow>();

            return services.BuildServiceProvider();
        }
    }
}
