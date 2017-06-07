using TestStack.Seleno.Configuration;

namespace UITests

{
    public static class BrowserHost
    {
  
        public static readonly SelenoHost Instance = new SelenoHost();
        public static readonly string RootUrl = "http://localhost:60639/";

        static BrowserHost()
        {
            //Instance.Run("Blog", 60639, w => w.WithRemoteWebDriver(BrowserFactory.Chrome));
            Instance.Run("..\\Blog", 60639);
            //RootUrl = Instance.Application.Browser.Url;
        }
    }
}
