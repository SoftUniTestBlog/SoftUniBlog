using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pages.ArticleDetailsPage
{
    public partial class ArticleDetailsPage
    {
        public IWebElement EmailFieldLogin
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.Id("Email")));
                return Driver.FindElement(By.Id("Email"));
            }
        }

        public IWebElement PasswordFieldLogin
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.Id("Password")));
                return Driver.FindElement(By.Id("Password"));
            }
        }

        public IWebElement LoginSubmitButton
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.ClassName("btn")));
                return Driver.FindElement(By.ClassName("btn"));
            }
        }

        public IWebElement LoginButton
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.Id("loginLink")));
                return Driver.FindElement(By.Id("loginLink"));
            }
        }

        public IWebElement EditButton
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/article/footer/a[1]")));
                return Driver.FindElement(By.XPath("/html/body/div[2]/div/article/footer/a[1]"));
            }
        }

        public IWebElement EditArticleText
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/h2")));
                return Driver.FindElement(By.XPath("/html/body/div[2]/div/div/h2"));
            }
        }

        public IWebElement BackButton
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/article/footer/a[3]")));
                return Driver.FindElement(By.XPath("/html/body/div[2]/div/article/footer/a[3]"));
            }
        }

        public IWebElement CreateButton
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"logoutForm\"]/ul/li[1]/a")));
                return Driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li[1]/a"));
            }
        }

        public IWebElement CreateArticleText
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/h2")));
                return Driver.FindElement(By.XPath("/html/body/div[2]/div/div/h2"));
            }
        }

        public IWebElement LogOffButton
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"logoutForm\"]/ul/li[3]/a")));
                return Driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li[3]/a"));
            }
        }

        public IWebElement ManageButton
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"logoutForm\"]/ul/li[2]/a")));
                return Driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li[2]/a"));
            }
        }
        public IWebElement ManageText
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/h2")));
                return Driver.FindElement(By.XPath("/html/body/div[2]/h2"));
            }
        }

        public IWebElement RegisterButton
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.Id("registerLink")));
                return Driver.FindElement(By.Id("registerLink"));
            }
        }

        public IWebElement EmailFieldRegister
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.Id("Email")));
                return Driver.FindElement(By.Id("Email"));
            }
        }


        public IWebElement FullNameFieldRegister
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.Id("FullName")));
                return Driver.FindElement(By.Id("FullName"));
            }
        }


        public IWebElement PasswordFieldRegister
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.Id("Password")));
                return Driver.FindElement(By.Id("Password"));
            }
        }


        public IWebElement ConfirmPasswordFieldRegister
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.Id("ConfirmPassword")));
                return Driver.FindElement(By.Id("ConfirmPassword"));
            }
        }

        public IWebElement RegisterSubmitButton
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/form/div[6]/div/input")));
                return Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[6]/div/input"));
            }
        }

        public IWebElement Forbidden
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"content\"]/div[1]/h3")));
                return Driver.FindElement(By.XPath("//*[@id=\"content\"]/div[1]/h3"));
            }
        }

        public IWebElement DeleteButton
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/article/footer/a[2]")));
                return Driver.FindElement(By.XPath("/html/body/div[2]/div/article/footer/a[2]"));
            }
        }

        public IWebElement RegistrationButton
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.LinkText("Register")));
                return this.Driver.FindElement(By.LinkText("Register"));
            }

        }

        public IWebElement LoginPageLogo
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/h2")));
                return Driver.FindElement(By.XPath("/html/body/div[2]/div/div/h2"));
            }
        }

        public IWebElement Logo
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.ClassName("navbar-brand")));
                return this.Driver.FindElement(By.ClassName("navbar-brand"));

            }
        }



        public string URL
        {
            get
            {

                return Driver.Url;
            }
        }

    }
}
