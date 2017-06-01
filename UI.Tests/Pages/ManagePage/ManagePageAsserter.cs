using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pages.ManagePage
{
    public static class ManagePageAsserter
    {
        //Second Commit
        //Check if you are on Home Page
        public static void AssertYouAreOnHomePage(this ManagePage page)
        {
            Assert.AreEqual("SOFTUNI BLOG", page.Logo.Text);
        }

        //Check if copyright is  present
        public static void AssertCopyrightIsPresent(this ManagePage page)
        {
            Assert.AreEqual("© 2017 - SoftUni Blog", page.Copyright.Text);
        }

        //Check if you are on create page on Manage Page
        public static void AssertIAmOnCreatePage(this ManagePage page)
        {
            Assert.AreEqual("Create Article", page.CreatePageLogo.Text);
        }

        //Check if you are on create page on Manage Page
        public static void AssertIAmLoggedOff(this ManagePage page)
        {
            Assert.AreEqual("Log in", page.LoginButton.Text);
        }
    }
}
