using TestStack.Seleno.Configuration;

namespace UITests
{
    public static class BrowserHost
    {
        public static readonly SelenoHost Instance = new SelenoHost();
        public static readonly string RootUrl = @"http://localhost:60634/";

        static BrowserHost()
        {
            Instance.Run("Blog", 60634, w => w.WithRemoteWebDriver(BrowserFactory.Chrome));
            //RootUrl = Instance.Application.Browser.Url;
        }

    }
}
