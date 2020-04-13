using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FinalProject.FullCycle_PageFactory
{
    class RepositoryCreator
    {
        [FindsBy(How = How.XPath, Using = "//a[@class='btn shelf-cta mx-2 mb-3']")]
        public IWebElement startProjectButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@id='repository_name']")]
        public IWebElement typeRepositoryName { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@id='repository_description']")]
        public IWebElement typeDescription { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@id='repository_auto_init']")]
        public IWebElement readMeRadioButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-primary first-in-line']")]
        public IWebElement createRepositoryButton { get; set; }

    }
}
