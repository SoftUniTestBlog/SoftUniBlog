using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pages.CreatePage
{
    public static class CreatePageAsserter
    {

        //Check if you see Log in button
        public static void AssertYouSeeLogInButton(this CreatePage page)
        {
            Assert.AreEqual("Log in", page.LoginButton.Text);
        }

        //Check if you see Password text
        public static void AssertYouSeePassword(this CreatePage page)
        {
            Assert.AreEqual("Manage", page.ManageText.Text);
        }

        //Check if you see created article
        public static void AssertYouSeeArticle(this CreatePage page)
        {
            Assert.AreEqual("TestArticle12345", page.Article.Text);
        }

        //Check if you see title error
        public static void AssertYouSeeTitleError(this CreatePage page)
        {
            Assert.AreEqual("The Title field is required.", page.TitleErrorMessage.Text);
        }

        //Check if you see content error
        public static void AssertYouSeeContentError(this CreatePage page)
        {
            Assert.AreEqual("The Content field is required.", page.ContentErrorMessage.Text);
        }

        //Check if you see characters error
        public static void AssertYouSeeCharactersError(this CreatePage page)
        {
            Assert.AreEqual("The field Title must be a string with a maximum length of 50.", page.CharactersErrorMessage.Text);
        }

        //Check if you are on article list page
        public static void AssertYouAreOnArticleListPage(this CreatePage page)
        {
            Assert.AreEqual("http://localhost:60634/Article/List", page.URL);
        }
    }
}
