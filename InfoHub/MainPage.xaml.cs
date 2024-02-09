namespace InfoHub
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            Data.Create();
        }

        private void NavToSensorsBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SensorsPage());
        }
    }
}