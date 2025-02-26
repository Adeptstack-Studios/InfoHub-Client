using Microsoft.Maui.ApplicationModel;
namespace InfoHub
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Application.Current.UserAppTheme = AppTheme.Dark;
        }
    }
}