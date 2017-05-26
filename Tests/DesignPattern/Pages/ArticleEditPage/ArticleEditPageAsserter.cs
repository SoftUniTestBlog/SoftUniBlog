using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pages.ArticleEditPage
{
    public static class ArticleEditPageAsserter
    {

        //Check if you see changed title
        public static void AssertChangedTitle(this ArticleEditPage page)
        {
            Assert.AreEqual("Edit title", page.ChangedTitle.Text);
        }

        //Check if you see changed content
        public static void AssertChangedContent(this ArticleEditPage page)
        {
            Assert.AreEqual("Edit content", page.ChangedContent.Text);
        }

        //Check if you see changed content
        public static void AssertCancel(this ArticleEditPage page)
        {
            Assert.AreNotEqual("This should not be visible", page.ChangedContent.Text);
        }




    }
}