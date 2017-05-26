using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pages.ArticleDetailsPage
{
    public static class ArticleDetailsPageAsserter
    {

        //Check if you see Log in button
        public static void AssertYouAreOnEditPage(this ArticleDetailsPage page)
        {
            Assert.AreEqual("Edit Article", page.EditArticleText.Text);
        }

        //Check if you are on article list page
        public static void AssertYouAreOnListPage(this ArticleDetailsPage page)
        {
            Assert.AreEqual("http://localhost:60634/Article/List", page.URL);
        }

        //Check if you see Log in button
        public static void AssertYouAreOnCreatePage(this ArticleDetailsPage page)
        {
            Assert.AreEqual("Create Article", page.CreateArticleText.Text);
        }

        //Check if you are logged off
        public static void AssertYouAreNotLogged(this ArticleDetailsPage page)
        {
            Assert.AreEqual("Log in", page.LoginButton.Text);
        }

        //Check if you are on Manage page
        public static void AssertYouAreOnManagePage(this ArticleDetailsPage page)
        {
            Assert.AreEqual("Manage", page.ManageText.Text);

        }

        //Check if you see Error 403
        public static void AssertYouHaveNoPermissions(this ArticleDetailsPage page)
        {
            Assert.AreEqual("HTTP Error 403.0 - Forbidden", page.Forbidden.Text);

        }
    }
}