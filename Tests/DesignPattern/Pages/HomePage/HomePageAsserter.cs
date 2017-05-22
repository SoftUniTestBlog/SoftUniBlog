using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectTests.Pages.HomePage
{
    public static class HomePageAsserter
    {   //First Commit
        //Check if you are on Registration Page
        public static void AssertYouAreOnRegistrationPage(this HomePage page, string text)
        {
            Assert.AreEqual(text, page.RegisterPageLogo.Text);
        }

        //Check if logo is there
        public static void AssertYouAreOnHomePage(this HomePage page, string text)
        {
            Assert.AreEqual(text, page.Logo.Text);
        }

        //Check if you are on Login Page
        public static void AssertYouAreOnLoginPage(this HomePage page, string text)
        {
            Assert.AreEqual(text, page.LoginPageLogo.Text);
        }

        //Check if you are on Login Page
        public static void AssertCopyrightIsPresent(this HomePage page)
        {
            Assert.AreEqual("© 2017 - SoftUni Blog", page.Copyright.Text);
        }


    }
}
