using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pages.ArticleDeletePage
{
    public static class ArticleDeletePageAsserter
    {

        //Check if title is changed
        public static void AssertTitleIsNotChanged(this ArticleDeletePage page)
        {
            Assert.AreNotEqual("This should not be visible", page.TitleField.Text);
        }

        //Check if content is changed
        public static void AssertContentIsNotChanged(this ArticleDeletePage page)
        {
            Assert.AreNotEqual("This should not be visible", page.ContentField.Text);
        }

        //Check if content is changed
        public static void AssertYouAreOnListPage(this ArticleDeletePage page)
        {
            Assert.AreEqual("TestArticle12345", page.FirstArticle.Text);
        }

        //Check if content is deleted
        public static void AssertArticleIsDeleted(this ArticleDeletePage page)
        {
            Assert.AreEqual("SOFTUNI BLOG", page.FirstArticle.Text);
        }
    }
}