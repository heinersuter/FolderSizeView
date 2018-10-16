using System.Windows;

namespace FolderSizeView
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var viewModel = new MainViewModel();

            MainWindow = new MainView
            {
                DataContext = viewModel
            };

            MainWindow.Show();
        }
    }
}
