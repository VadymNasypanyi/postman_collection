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
using Serilog;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;

namespace VadimFramework.Engine
{
    public class BaseClass
    {
        public IWebDriver driver = new ChromeDriver();

        public String screenUrl = "https://github.com/";
        public String emailLogin = "nv.test1.demo@gmail.com"; 
        public String passwordLogin = "CSWINksk2";
        public String RepositoryName = "Vadim_Repository_Final_Version_NV";
        public String RepositoryFullName = "VadimNas/Vadim_Repository_Final_Version_NV";
        public String Description = "Demo_Test_VNasypanyi_Creator_Description";
        public String NameFile = "Vadim_Demo_C#_File";
        public String BodyFile = "class HelloWorld{public static void main(String[] args) {System.out.println('Hello_World!')}";
        public String CommitFile = "Vadim_Commit_Demo_4/13_2020";
        public String CommitDescription = "Vadim_Nasypanyi_Auto_Test_C#";
        

        [OneTimeSetUp]
        public void Initialize()
        {

            driver.Navigate().GoToUrl("https://github.com/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //Thread.Sleep(2000);
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File(@"C:\Users\vadym.nasypanyi\source\repos\VadimFramework\VadimFramework\Logs\logs.txt")
            .CreateLogger();

            Log.Information("Here we go again");

        }
        [TearDown]
        public void EndTest()
        {
            Log.Information("Test method has been executed. Switching to the next one!");
        }

        [OneTimeTearDown]
        public void EndSuite()
        {
            driver.Close();
            Log.Information("Test Suite has been executed!");
            Log.CloseAndFlush();
        }

        














    }
}


    







