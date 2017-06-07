using TestStack.Seleno.Configuration;

namespace ProjectTests

{
    public static class BrowserHost
    {
        public static readonly SelenoHost Instance = new SelenoHost();
        public static readonly string RootUrl = "http://localhost:60634/Article/List";

        static BrowserHost()
        {
            //Instance.Run("Blog", 60639, w => w.WithRemoteWebDriver(BrowserFactory.Chrome));
            Instance.Run("Blog", 60634);
            //RootUrl = Instance.Application.Browser.Url;
        }

    }
}
