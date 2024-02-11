namespace InfoHub.Pages;

public partial class CreditsPage : ContentPage
{
    string link = "";
    public CreditsPage()
    {
        InitializeComponent();
        GenerateCredits();
    }

    void GenerateCredits()
    {
        string icons = "<h2>Weather icons</h2>" +
            "<li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/oMdcU92GFKlj/windiges-wetter\">Windiges Wetter</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li><li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/KKDDiwt2gs5d/sonniger-tag-snowy\">Snowy Sunny Day</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li><li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/glqGVfSCkqBT/feuchtigkeit\">Feuchtigkeit</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li><li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/HWPdQMFoVy95/leichter-regen\">Leichter Regen</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li><li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/HWPdQMFoVy95/leichter-regen\">Leichter Regen</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li><li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/7tEHHH5dn7A3/neblige-nacht\">Fog</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li><li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/RtDA8YDN9Mi9/wind\">Wind</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li><li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/9XlIvJuZ1DEv/sonnenuntergang\">Sonnenuntergang</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li><li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/eB996llrCC83/sonnenaufgang\">Sonnenaufgang</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li><li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/8EUmYhfLPTCF/sonne\">Sonne</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li><li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/IL2szZWdo0Bo/nebel-tag\">Nebel Tag</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li><li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/qHIFUjYhnsFU/nebel-nacht\">Nebel Nacht</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li><li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/7Dcax1eBasEf/intensiver-regen\">Intensiver Regen</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li><li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/R1kPtXvDMnWj/starkregen\">Starkregen</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li><li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/QZJFPE7TNi5Q/leichter-regen\">Leichter Regen</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li><li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/JBQOSn7KOSuD/leichter-schneefall\">Leichter Schneefall</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li><li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/kKxyuLXD4w0n/regen\">Regen</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li><li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/PIXtKMDAXCzo/leichter-regen-2\">Leichter Regen 2</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li><li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/MVj2tmasj0Pp/teilweise-bew%C3%B6lkt-%26-regen\">Teilweise bew�lkt & Regen</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li><li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/ycLdTupX7dng/platzregen\">Platzregen</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li><li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/wBPV56Uje50D/regnerische-nacht\">Regnerische Nacht</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li><li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/fyJ8mNcBHced/schneeregen\">Schneeregen</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li><li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/cyZConbteZk9/schnee\">Schnee</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li><li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/Mi2BdbZQWNYQ/schneesturm\">Schneesturm</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li><li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/DlsFhDMp4rhs/sturm\">Sturm</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li><li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/6AAyqKfBlzoB/sturm-mit-starkem-regen\">Storm With Heavy Rain</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li><li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/PwHEPRMlRd4a/st%C3%BCrmische-nacht\">Stormy Night</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li><li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/uzabNvAfhNNr/sintflutartiger-regen\">Sintflutartiger Regen</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li><li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/EFrx3a9OC3Ud/mond\">Mond</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li><li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/W8fUZZSmXssu/wolken\">Wolken</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li><li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/OFU5h8HeWK3z/wolken\">Wolken</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li><li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/VT8HlhlnhUwL/leichter-regen-nacht\">Leichter Regen Nacht</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li><li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/zIVmoh4T8wh7/leicht-bew%C3%B6lkt-tag\">Leicht bew�lkt Tag</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li><li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/TeROlZnH2EAa/luftdruck\">Luftdruck</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li><li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/hpwbr3sG19tQ/feuchtigkeitsmesser\">Feuchtigkeitsmesser</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li><li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/e3LJkBOFiBL7/thermometer\">Thermometer</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li><li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/wBPV56Uje50D/regnerische-nacht\">Regnerische Nacht</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li><li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/c0Otgmp74zQX/wolkenblitz\">Wolkenblitz</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li><li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/a54zFcoylfIg/co2-messer\">CO2-Messer</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li><li>\r\n<a target=\"_blank\" href=\"https://icons8.com/icon/HoIlx2KEJXho/lawine\">Avalanche</a> Icon von <a target=\"_blank\" href=\"https://icons8.com\">Icons8</a>\r\n</li>\r\n";
        string main = $"{icons}\n" + link;
        string html = "<!DOCTYPE html><html><head><style>" + Utilities.MarkdownStyle.CSS() + "</style></head><body>" + main + "</body></html>";

        HtmlWebViewSource source = new HtmlWebViewSource { Html = html };
        web.Source = source;
        link = source.BaseUrl;
    }

    private void web_Navigating(object sender, WebNavigatingEventArgs e)
    {
        if (e.Url != link)
        {
            e.Cancel = true;
            Browser.Default.OpenAsync(e.Url).Wait();
        }
    }

    private void RefreshView_Refreshing(object sender, EventArgs e)
    {
        GenerateCredits();
        refresh.IsRefreshing = false;
    }
}