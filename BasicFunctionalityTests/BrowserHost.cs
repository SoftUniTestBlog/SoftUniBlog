using TestStack.Seleno.Configuration;
using OpenQA.Selenium.Chrome;
namespace BasicFunctionalityTests

{
    public static class BrowserHost
    {
        public static readonly SelenoHost Instance = new SelenoHost();
        public static readonly string RootUrl = "http://localhost:60640/Article/List";

        static BrowserHost()
        {
            //Instance.Run("Blog", 60640, w => w.WithRemoteWebDriver(BrowserFactory.Chrome));
            Instance.Run("Blog", 60640, w => w.WithRemoteWebDriver(() => new ChromeDriver()));
            //RootUrl = Instance.Application.Browser.Url;
        }

    }
}
