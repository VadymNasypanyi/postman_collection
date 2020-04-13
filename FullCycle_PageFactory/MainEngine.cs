using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;


namespace FinalProject.FullCycle_PageFactory
{
    class MainEngine
    {
        IWebDriver driver = new ChromeDriver();
        [OneTimeSetUp]
        public void Initialize()
        {
            driver.Navigate().GoToUrl("https://github.com/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);

        }
        [Test, Order(1)]
        public void ExecuteLogin()
        {
            LoginPage loginPage = new LoginPage();
            PageFactory.InitElements(driver, loginPage);
            loginPage.FirstButton.Click();
            Thread.Sleep(1000);
            Assert.True(driver.FindElement(By.XPath("//input[@name='commit']")).Displayed);
            loginPage.typeEmail.SendKeys("nv.test1.demo@gmail.com");
            loginPage.typePassword.SendKeys("CSWINksk2");
            loginPage.signInButton.Click();
           
           Thread.Sleep(500);
        }
        
        [Test, Order(2)]
        //[Ignore("Ignore a test")]
        public void ExecuteReposytoryCreation()
        {
            RepositoryCreator repositoryCreator1 = new RepositoryCreator();
            PageFactory.InitElements(driver, repositoryCreator1);
            repositoryCreator1.startProjectButton.Click();
            Thread.Sleep(1000);
            repositoryCreator1.typeRepositoryName.SendKeys("Vadim_Repository_Final_Version");
            Thread.Sleep(500);
            repositoryCreator1.typeDescription.SendKeys("Demo_Test_VNasypanyi_Creator_Description");
            Thread.Sleep(500);
            repositoryCreator1.readMeRadioButton.Click();
            Thread.Sleep(1000);
            repositoryCreator1.createRepositoryButton.Click();
            Thread.Sleep(1500);
        }
        [Test, Order(3)]
        //[Ignore("Ignore a test")]

        public void ExecuteFileCreation()
        {
            FileCreator fileCreator1 = new FileCreator();
            PageFactory.InitElements(driver, fileCreator1);
            fileCreator1.clickCreateFile.Click();
            Thread.Sleep(500);
            fileCreator1.typeNameFile.SendKeys("Vadim_Demo_C#_File"); 
            Thread.Sleep(500);
            fileCreator1.typeBodyFile.SendKeys("class HelloWorld{public static void main(String[] args) {System.out.println('Hello_World!')}");
            Thread.Sleep(500);
            fileCreator1.typeCommitFile.SendKeys("Vadim_Commit_Demo_4/13_2020");
            Thread.Sleep(500);
            fileCreator1.typeCommitDescription.SendKeys("Vadim_Nasypanyi_Auto_Test_C#");
            Thread.Sleep(500);
            fileCreator1.clickCommitButton.Click();
            Thread.Sleep(1000);
            fileCreator1.clickLogo.Click();
            Thread.Sleep(1000);



        }
        [Test, Order(4)]
        public void ExecuteReposytoryDeleting()
        {
            DeletingProcess deletingProcess1 = new DeletingProcess();
            PageFactory.InitElements(driver, deletingProcess1);
            deletingProcess1.SearchField.SendKeys("VadimNas/Vadim_Repository_Final_Version");
            Thread.Sleep(1000);
            deletingProcess1.RepositoryClick.Click();
            Thread.Sleep(1000);
            deletingProcess1.SettingsClick.Click();
            Thread.Sleep(1500);
            deletingProcess1.clickDeleteButton.Click();
            Thread.Sleep(1000);

            deletingProcess1.typeRepositoryFullName.SendKeys("VadimNas/Vadim_Repository_Final_Version");
            Thread.Sleep(2000);
            deletingProcess1.clickFinalDeleting.Click();
            Thread.Sleep(2000);





        }
        [Test, Order(5)]
        //[Ignore("Ignore a test")]

        public void ExecuteLogoutProcess()
        {
            LogoutProcess logoutProcess1 = new LogoutProcess();
            PageFactory.InitElements(driver, logoutProcess1);
            logoutProcess1.clickHeaderButton.Click();
            Thread.Sleep(500);
            logoutProcess1.clickLogoutButton.Click();
            Thread.Sleep(1000);

        }


        [OneTimeTearDown]
        public void EndTest()
        {
            driver.Close();
        }

    }
}
