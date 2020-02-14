using Geocoding.Google;


namespace BindFinder.Helpers
{
    static class GeocoderHelper
    {
        private const string GoogleNoApi = "Для использования сервиса Google Maps необходимо наличие API ключа. Вы можете зарегистрировать его на сайте Google Clouds." +
                            "\n\nУкажите ваш ключ в настройках программы в разделе Служба поиска адресов";
        public enum CoderKind { Google = 1 }
        public static string GoogleAPIKey
        {
            get => Properties.Settings.Default.GoogleAPIKey;
            set => Properties.Settings.Default.GoogleAPIKey = value;
        }
        public static string QueryLanguage
        {
            get => Properties.Settings.Default.GoogleQueryLanguage;
            set => Properties.Settings.Default.GoogleQueryLanguage = value;
        }
        public static Geocoding.IGeocoder GetGeocoder(bool keyRequest = true)
        {
            try
            {
                return Initialize(CoderKind.Google);
            }
            catch (System.Exception ex)
            {
                if (keyRequest)
                    System.Windows.Forms.MessageBox.Show(ex.Message, "Ошибка инициализации геокодера", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return null;
        }
        private static Geocoding.IGeocoder Initialize(CoderKind kind)
        {
            switch (kind)
            {
                case CoderKind.Google:
                    if (string.IsNullOrEmpty(GoogleAPIKey))
                    {
                        throw new System.Exception(GoogleNoApi);
                    }
                    else
                    {
                        return new GoogleGeocoder(GoogleAPIKey) { Language = QueryLanguage };
                    }                
            }
            return null;
        }

    }
}
