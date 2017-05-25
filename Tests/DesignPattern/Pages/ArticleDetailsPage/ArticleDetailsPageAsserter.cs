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


    }
}