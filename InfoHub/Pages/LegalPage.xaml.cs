namespace InfoHub.Pages;

public partial class LegalPage : ContentPage
{
    public LegalPage()
    {
        InitializeComponent();
    }

    private void License_Clicked(object sender, EventArgs e)
    {
        Browser.Default.OpenAsync("https://github.com/Adeptstack-Studios/InfoHub-Client/blob/main/LICENSE").Wait();
    }

    private void privacy_Clicked(object sender, EventArgs e)
    {
        Browser.Default.OpenAsync("https://adeptstack.vercel.app/privacy").Wait();
    }

    private void Imprint_Clicked(object sender, EventArgs e)
    {
        Browser.Default.OpenAsync("https://adeptstack.vercel.app/imprint").Wait();
    }
}