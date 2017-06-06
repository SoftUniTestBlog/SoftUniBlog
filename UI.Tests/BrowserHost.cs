using TestStack.Seleno.Configuration;

namespace UITests
{
    public static class BrowserHost
    {
        public static readonly SelenoHost Instance = new SelenoHost();
        public static readonly string RootUrl = @"http://localhost:60634/Article/List";

        static BrowserHost()
        {
            Instance.Run("Blog", 60634);
            //RootUrl = Instance.Application.Browser.Url;
        }

    }
}
