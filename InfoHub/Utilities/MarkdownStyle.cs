namespace InfoHub.Utilities
{
    class MarkdownStyle
    {
        static string css_dark = "body { background-color: #000000; color: white; font-family: 'OpenSansRegular', serif; margin: 20px 20px 20px 40px;} " +
                              "blockquote { Background: #222222; padding: 5px 20px; border-radius: 10px; }" +
                              "img { border-radius: 10px; }" +
                              "a { text-decoration: none; color: #00a8ff; }" +
                              "p { word-wrap: break-word; }" +
                              "pre { background: #262626; padding: 5px 10px; border-radius: 10px; }  div { border-radius: 11px; }" +
                              "code { background: #262626; padding: 2px 5px; border-radius: 5px; }";

        static string css_light = "body { background-color: white; color: black; font-family: 'OpenSansRegular', serif; margin: 20px 20px 20px 40px;} " +
                                   "blockquote { Background: lightgray; padding: 5px 20px; border-radius: 10px; }" +
                                   "img { border-radius: 10px; }" +
                                   "a { text-decoration: none; color: #00a8ff; }" +
                                   "p { word-wrap: break-word; }" +
                                   "pre { background: darkgray; padding: 5px 10px; border-radius: 10px; } div { border-radius: 11px; }" +
                                   "code { background: darkgray; padding: 2px 5px; border-radius: 5px; }";

        public static string CSS()
        {
            if (Application.Current.UserAppTheme == AppTheme.Dark)
            {
                return css_dark;
            }
            else
            {
                return css_light;
            }
        }
    }
}
