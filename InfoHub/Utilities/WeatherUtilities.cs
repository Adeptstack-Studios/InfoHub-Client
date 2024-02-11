namespace InfoHub.Utilities
{
    public class WeatherUtilities
    {
        public static (string text, string imgPath) GetWeatherCodeText(int weatherCode, int isNight)
        {
            string text;
            string imgPath = "Resources/Images/";

            switch (weatherCode)
            {
                case 0:
                    text = "Clear sky";
                    if (isNight == 0)
                    {
                        imgPath += "mond.png";
                    }
                    else
                    {
                        imgPath += "sonne.png";
                    }
                    break;
                case 1:
                    text = "Mainly clear";
                    if (isNight == 0)
                    {
                        imgPath += "leichter_regen_nacht.png";
                    }
                    else
                    {
                        imgPath += "leicht_bewoelkt_tag.png";
                    }
                    break;
                case 2:
                    text = "Partly cloudy";
                    if (isNight == 0)
                    {
                        imgPath += "leichter_regen_nacht.png";
                    }
                    else
                    {
                        imgPath += "leicht_bewoelkt_tag.png";
                    }
                    break;
                case 3:
                    text = "Overcast";
                    if (isNight == 0)
                    {
                        imgPath += "wolken_night.png";
                    }
                    else
                    {
                        imgPath += "wolken.png";
                    }
                    break;
                case 45:
                    text = "Foggy";
                    if (isNight == 0)
                    {
                        imgPath += "nebel_nacht.png";
                    }
                    else
                    {
                        imgPath += "nebel_tag.png";
                    }
                    break;
                case 48:
                    text = "Fog and depositing rime fog";
                    if (isNight == 0)
                    {
                        imgPath += "nebel_nacht.png";
                    }
                    else
                    {
                        imgPath += "nebel_tag.png";
                    }
                    break;
                case 51:
                    text = "Light drizzle";
                    if (isNight == 0)
                    {
                        imgPath += "leichter_regen_2_nacht.png";
                    }
                    else
                    {
                        imgPath += "leichter_regen_2.png";
                    }
                    break;
                case 53:
                    text = "Moderate drizzle";
                    if (isNight == 0)
                    {
                        imgPath += "leichter_regen_2_nacht.png";
                    }
                    else
                    {
                        imgPath += "leichter_regen_2.png";
                    }
                    break;
                case 55:
                    text = "heavy drizzle";
                    if (isNight == 0)
                    {
                        imgPath += "leichter_regen_2_nacht.png";
                    }
                    else
                    {
                        imgPath += "leichter_regen_2.png";
                    }
                    break;
                case 56:
                    text = "Slightly freezing drizzle";
                    if (isNight == 0)
                    {
                        imgPath += "leichter_regen_2_nacht.png";
                    }
                    else
                    {
                        imgPath += "leichter_regen_2.png";
                    }
                    break;
                case 57:
                    text = "Dense freezing drizzle";
                    if (isNight == 0)
                    {
                        imgPath += "leichter_regen_2_nacht.png";
                    }
                    else
                    {
                        imgPath += "leichter_regen_2.png";
                    }
                    break;
                case 61:
                    text = "Light rain";
                    if (isNight == 0)
                    {
                        imgPath += "leichter_regen_2_nacht.png";
                    }
                    else
                    {
                        imgPath += "leichter_regen_2.png";
                    }
                    break;
                case 63:
                    text = "Moderate rain";
                    if (isNight == 0)
                    {
                        imgPath += "leichter_regen_2_nacht.png";
                    }
                    else
                    {
                        imgPath += "leichter_regen_2.png";
                    }
                    break;
                case 65:
                    text = "Heavy rain";
                    if (isNight == 0)
                    {
                        imgPath += "regen_nacht.png";
                    }
                    else
                    {
                        imgPath += "regen.png";
                    }
                    break;
                case 66:
                    text = "Light freezing rain";
                    if (isNight == 0)
                    {
                        imgPath += "hagel_nacht.png";
                    }
                    else
                    {
                        imgPath += "hagel.png";
                    }
                    break;
                case 67:
                    text = "Heavy freezing rain";
                    if (isNight == 0)
                    {
                        imgPath += "hagel_nacht.png";
                    }
                    else
                    {
                        imgPath += "hagel.png";
                    }
                    break;
                case 71:
                    text = "Light snowfall";
                    if (isNight == 0)
                    {
                        imgPath += "snowy_moony_night.png";
                    }
                    else
                    {
                        imgPath += "snowy_sunny_day.png";
                    }
                    break;
                case 73:
                    text = "Moderate snowfall";
                    if (isNight == 0)
                    {
                        imgPath += "leichter_schneefall_nacht.png";
                    }
                    else
                    {
                        imgPath += "leichter_schneefall.png";
                    }
                    break;
                case 75:
                    text = "Heavy snowfall";
                    if (isNight == 0)
                    {
                        imgPath += "schnee_nacht.png";
                    }
                    else
                    {
                        imgPath += "schnee.png";
                    }
                    break;
                case 77:
                    text = "Snow grains";
                    if (isNight == 0)
                    {
                        imgPath += "schnee_nacht.png";
                    }
                    else
                    {
                        imgPath += "schnee.png";
                    }
                    break;
                case 80:
                    text = "Light rain showers";
                    if (isNight == 0)
                    {
                        imgPath += "starkregen_nacht.png";
                    }
                    else
                    {
                        imgPath += "starkregen.png";
                    }
                    break;
                case 81:
                    text = "Moderate rain showers";
                    if (isNight == 0)
                    {
                        imgPath += "sintflutartiger_regen_nacht.png";
                    }
                    else
                    {
                        imgPath += "sintflutartiger_regen.png";
                    }
                    break;
                case 82:
                    text = "Heavy rain showers";
                    if (isNight == 0)
                    {
                        imgPath += "platzregen_nacht.png";
                    }
                    else
                    {
                        imgPath += "platzregen.png";
                    }
                    break;
                case 85:
                    text = "Light snow showers";
                    if (isNight == 0)
                    {
                        imgPath += "schneesturm.png";
                    }
                    else
                    {
                        imgPath += "schneesturm.png";
                    }
                    break;
                case 86:
                    text = "Heavy snow showers";
                    if (isNight == 0)
                    {
                        imgPath += "schneesturm.png";
                    }
                    else
                    {
                        imgPath += "schneesturm.png";
                    }
                    break;
                case 95:
                    text = "Thunderstorms";
                    if (isNight == 0)
                    {
                        imgPath += "stormy_night.png";
                    }
                    else
                    {
                        imgPath += "wolkenblitz.png";
                    }
                    break;
                case 96:
                    text = "Thunderstorm with slight hail";
                    if (isNight == 0)
                    {
                        imgPath += "stormy_night.png";
                    }
                    else
                    {
                        imgPath += "sturm.png";
                    }
                    break;
                case 99:
                    text = "Thunderstorm with heavy hail";
                    if (isNight == 0)
                    {
                        imgPath += "stormy_night.png";
                    }
                    else
                    {
                        imgPath += "storm_with_heavy_rain.png";
                    }
                    break;
                default:
                    text = "Error";
                    imgPath = "";
                    break;
            }
            return (text, imgPath);
        }

        public static string GetUVIndexString(double uvIndex)
        {
            if (uvIndex < 3)
            {
                return "Low";
            }
            else if (uvIndex <= 5.5)
            {
                return "Medium";
            }
            else if (uvIndex < 8)
            {
                return "High";
            }
            else if (uvIndex < 10)
            {
                return "Very high";
            }
            else
            {
                return "Extrme";
            }
        }

        public static string CalculateAltitude(double pressureMSL, double surfacePressure)
        {
            double h = (44330 * (1 - Math.Pow((surfacePressure / pressureMSL), (1 / 5.255))));
            double currentHeight = Math.Round(h, 2);
            return currentHeight.ToString() + "m";
        }
    }
}
