using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace VadimFramework.Engine
{
    class FileCreator
    {
        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-sm BtnGroup-item']")]
        public IWebElement clickCreateFile { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Name your file…']")]
        public IWebElement typeNameFile { get; set; }
        [FindsBy(How = How.XPath, Using = "//pre[contains(@class,'CodeMirror-line')]")]
        public IWebElement typeBodyFile { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@id='commit-summary-input']")]
        public IWebElement typeCommitFile { get; set; }
        [FindsBy(How = How.XPath, Using = "//textarea[@id='commit-description-textarea']")]
        public IWebElement typeCommitDescription { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[@id='submit-file']")]
        public IWebElement clickCommitButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[@class='Header-link']//*[local-name()='svg']")]
        public IWebElement clickLogo { get; set; }
    }
}
