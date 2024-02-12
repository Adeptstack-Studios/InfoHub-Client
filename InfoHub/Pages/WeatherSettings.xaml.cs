using InfoHub.ContentViews;
using InfoHub.ContextClasses;
using InfoHub.CustomEventArgs;
using InfoHub.Utilities;

namespace InfoHub.Pages;

public partial class WeatherSettings : ContentPage
{
    int index = 0;
    bool isEdit = false;
    public WeatherSettings()
    {
        InitializeComponent();
        Thread locationCards = new Thread(new ThreadStart(GenerateLocationCards));
        locationCards.Start();
    }

    bool CheckLocationExists()
    {
        foreach (var item in Utilities.AppResources.settings.WeatherLocations)
        {
            if (location.Text == item.Name || (latitude.Text == item.Latitude && longitude.Text == item.Longitude))
            {
                return true;
            }
        }
        return false;
    }

    int GetIndexOfSameLocation()
    {
        int index = 0;
        for (int i = 0; i < Utilities.AppResources.settings.WeatherLocations.Count; i++)
        {
            if (location.Text == Utilities.AppResources.settings.WeatherLocations[i].Name && (latitude.Text == Utilities.AppResources.settings.WeatherLocations[i].Latitude && longitude.Text == Utilities.AppResources.settings.WeatherLocations[i].Longitude))
            {
                index = i;
                return index;
            }
        }
        return -1;
    }

    private void SaveBtn_Clicked(object sender, EventArgs e)
    {
        bool isExisting = CheckLocationExists();

        if (!isExisting)
        {
            int id = 0;
            if (Utilities.AppResources.settings.WeatherLocations.Count > 0)
            {
                id = Utilities.AppResources.settings.WeatherLocations[Utilities.AppResources.settings.WeatherLocations.Count - 1].ID + 1;
            }

            Utilities.AppResources.settings.WeatherLocations.Add(new WeatherLocations
            {
                ID = id,
                Name = location.Text,
                Longitude = longitude.Text,
                Latitude = latitude.Text,
                Main = isMain.IsChecked
            });
        }
        else if (isEdit)
        {
            Utilities.AppResources.settings.WeatherLocations[index].Name = location.Text;
            Utilities.AppResources.settings.WeatherLocations[index].Longitude = longitude.Text;
            Utilities.AppResources.settings.WeatherLocations[index].Latitude = latitude.Text;
            Utilities.AppResources.settings.WeatherLocations[index].Main = isMain.IsChecked;
        }
        else
        {
            lblMessage.Text = "The location with this data already exists!";
            message.IsVisible = true;
        }

        ManageEdit(false);
        location.Text = "";
        longitude.Text = "";
        latitude.Text = "";
        isMain.IsChecked = false;
        Data.SaveSettings(Utilities.AppResources.settings);
        ShowLocations();
    }

    void ShowLocations()
    {
        Thread threadLocationCard = new Thread(new ThreadStart(GenerateLocationCards));
        threadLocationCard.Start();
    }

    void GenerateLocationCards()
    {
        Dispatcher.Dispatch(() => weatherLocationData.Children.Clear());
        foreach (var item in Utilities.AppResources.settings.WeatherLocations)
        {
            WeatherLocationsView view = new WeatherLocationsView
            {
                Name = item.Name,
                Latitude = item.Latitude,
                Longitude = item.Longitude,
                Main = item.Main,
            };
            view.Clicked += OptionsBtnClicked;

            Dispatcher.Dispatch(() => weatherLocationData.Children.Add(view));
        }
    }

    private void OptionsBtnClicked(object sender, InContentViewClickedEventArgs e)
    {
        index = e.Index;
        ManageEdit(true);
        var values = Utilities.AppResources.settings.WeatherLocations[e.Index];

        location.Text = values.Name;
        longitude.Text = values.Longitude;
        latitude.Text = values.Latitude;
        isMain.IsChecked = values.Main;
    }

    private void DeleteBtn_Clicked(object sender, EventArgs e)
    {
        int index = GetIndexOfSameLocation();

        if (index >= 0)
        {
            Utilities.AppResources.settings.WeatherLocations.RemoveAt(index);

            location.Text = "";
            longitude.Text = "";
            latitude.Text = "";
            isMain.IsChecked = false;
            Data.SaveSettings(Utilities.AppResources.settings);
            ShowLocations();
        }
        ManageEdit(false);
    }

    private void OKBtn_Clicked(object sender, EventArgs e)
    {
        message.IsVisible = false;
    }

    void ManageEdit(bool isEdit)
    {
        if (isEdit)
        {
            this.isEdit = true;
            title.Text = "Edit location:";
            cancelEditBtn.IsVisible = true;
        }
        else
        {
            this.isEdit = false;
            title.Text = "Manage locations:";
            cancelEditBtn.IsVisible = false;
        }
    }

    private void cancelEditBtn_Clicked(object sender, EventArgs e)
    {
        ManageEdit(false);
    }
}