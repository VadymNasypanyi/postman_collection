using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace FinalProject.FullCycle_PageFactory
{
    class DeletingProcess
    {
        [FindsBy(How = How.XPath, Using = "//input[@id='dashboard-repos-filter-left']")]
        public IWebElement SearchField { get; set; }
        [FindsBy(How = How.XPath, Using = "//ul[@class='list-style-none filterable-active']//li[1]//div[1]//a[1]")]
        public IWebElement RepositoryClick { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//nav[@class='hx_reponav reponav js-repo-nav js-sidenav-container-pjax clearfix container-lg px-3']/a[last()]")]
        public IWebElement SettingsClick { get; set; }
        [FindsBy(How = How.XPath, Using = "//summary[contains(text(),'Delete this repository')]")]
        public IWebElement clickDeleteButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//details-dialog[@class='Box Box--overlay d-flex flex-column anim-fade-in fast']//input[@name='verify']")]
        public IWebElement typeRepositoryFullName { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'I understand the consequences, delete this reposit')]")]
        public IWebElement clickFinalDeleting { get; set; }


    }
}
