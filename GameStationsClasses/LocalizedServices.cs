namespace GameStationsClasses
{
    public static class LocalizedServices
    {
        public delegate void LanguageChange(string culture);

        public static event LanguageChange? OnLanguageChanged;

        private static string _currentLanguage = "en-US";

        public static readonly Dictionary<string, Dictionary<string, string>> localizedServices = new Dictionary<string, Dictionary<string, string>>
        {
            ["en-US"] = new Dictionary<string, string>
            {
                ["Service1"] = "Service 1",
                ["Service2"] = "Service 2",
                ["Service3"] = "Service 3",
                ["Title"] = "Game Station",
                ["BoardGames"] = "Board Games",
                ["Others"] = "Others"
            },
            ["fr-FR"] = new Dictionary<string, string>
            {
                ["Service1"] = "Service 1 (FR)",
                ["Service2"] = "Service 2 (FR)",
                ["Service3"] = "Service 3 (FR)",
                ["Title"] = "Game Station",
                ["BoardGames"] = "Jeux de société",
                ["Others"] = "Autres"
            }
        };

        public static string GetLocalizedService(string serviceKey)
        {
            var culture = System.Globalization.CultureInfo.CurrentUICulture.Name;
            if (localizedServices.TryGetValue(culture, out var services) && services.TryGetValue(serviceKey, out var localizedService))
            {
                return localizedService;
            }
            return serviceKey; // Fallback to the key if no localization is found
        }

        public static void ChangeLanguage(string culture)
        {
            System.Globalization.CultureInfo.CurrentUICulture = new System.Globalization.CultureInfo(culture);
            if (!localizedServices.ContainsKey(culture))
            {
                return; // No localization available for this culture, do not change
            }
            _currentLanguage = culture;
            LocalizedServices.OnLanguageChanged?.Invoke(culture);
        }












    }
}
