using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;


namespace VadimFramework.Engine
{
    class LoginPage
    {
        [FindsBy(How = How.XPath, Using = "//a[@class='HeaderMenu-link no-underline mr-3']")]
        public IWebElement FirstButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='login_field']")]
        public IWebElement typeEmail { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='password']")]
        public IWebElement typePassword { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='commit']")]
        public IWebElement signInButton { get; set; }


    }
}
