using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace FinalProject.FullCycle_PageFactory
{
    class LogoutProcess
    {
        [FindsBy(How = How.XPath, Using = "//details[@class='details-overlay details-reset js-feature-preview-indicator-container']//summary[@class='Header-link']")]
        public IWebElement clickHeaderButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[@class='dropdown-item dropdown-signout']")]
        public IWebElement clickLogoutButton { get; set; }

    }
}
