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
        ShowLocations();
    }

    bool CheckLocationExists()
    {
        foreach (var item in Utilities.AppResources.settings.WeatherSettings)
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
        for (int i = 0; i < Utilities.AppResources.settings.WeatherSettings.Count; i++)
        {
            if (location.Text == Utilities.AppResources.settings.WeatherSettings[i].Name && (latitude.Text == Utilities.AppResources.settings.WeatherSettings[i].Latitude && longitude.Text == Utilities.AppResources.settings.WeatherSettings[i].Longitude))
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
            if (Utilities.AppResources.settings.WeatherSettings.Count > 0)
            {
                id = Utilities.AppResources.settings.WeatherSettings[Utilities.AppResources.settings.WeatherSettings.Count - 1].ID + 1;
            }

            Utilities.AppResources.settings.WeatherSettings.Add(new WeatherLocations
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
            Utilities.AppResources.settings.WeatherSettings[index].Name = location.Text;
            Utilities.AppResources.settings.WeatherSettings[index].Longitude = longitude.Text;
            Utilities.AppResources.settings.WeatherSettings[index].Latitude = latitude.Text;
            Utilities.AppResources.settings.WeatherSettings[index].Main = isMain.IsChecked;
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
        weatherLocationData.Children.Clear();
        foreach (var item in Utilities.AppResources.settings.WeatherSettings)
        {
            WeatherLocationsView view = new WeatherLocationsView
            {
                Name = item.Name,
                Latitude = item.Latitude,
                Longitude = item.Longitude,
                Main = item.Main,
            };
            view.Clicked += OptionsBtnClicked;

            weatherLocationData.Children.Add(view);
        }
    }

    private void OptionsBtnClicked(object sender, InContentViewClickedEventArgs e)
    {
        index = e.Index;
        ManageEdit(true);
        var values = Utilities.AppResources.settings.WeatherSettings[e.Index];

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
            Utilities.AppResources.settings.WeatherSettings.RemoveAt(index);

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