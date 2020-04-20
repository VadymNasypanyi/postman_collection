using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using Serilog;
using Serilog.Debugging;
using SeleniumExtras.WaitHelpers;
using ExpectedConditions = OpenQA.Selenium.Support.UI.ExpectedConditions;


namespace VadimFramework.Engine
{
    [TestFixture]
    public class FinalEngine : BaseClass
    {

        [Test, Order(1)]
        [Author("Vadym Nasypanyi", "vadym.nasypanyi@fortegrp.com")]

        public void ExecuteLogin()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Assert.Multiple(() =>
            { 
                Assert.IsTrue(driver.Url.Equals(screenUrl), "URL is incorrect");
            Assert.AreEqual(driver.Title, "The world’s leading software development platform · GitHub", "Page title is incorrect");
            Assert.IsTrue(driver.FindElement(By.XPath("//a[@class='HeaderMenu-link no-underline mr-3']")).Displayed, "Button 'Sign In' is absent");
            });
            Log.Information("First block of Asserts is passed");

            LoginPage loginPage = new LoginPage();
            PageFactory.InitElements(driver, loginPage);


            loginPage.FirstButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@name='commit']")));

            Assert.Multiple(() =>
            {
                Assert.AreEqual(driver.Title, "Sign in to GitHub · GitHub", "Page title is incorrect");
                Assert.IsTrue(driver.FindElement(By.XPath("//a[@class='label-link']")).Text.Equals("Forgot password?"),"Button 'FP' is absent");
                Assert.IsTrue(driver.FindElement(By.XPath(" //p[@class='create-account-callout mt-3']")).Displayed, "Block 'CA' is absent");
            });

            Log.Information("Second block of Asserts is passed");

            if (
                driver.FindElement(By.XPath("//input[@name='commit']")).Displayed
                && driver.FindElement(By.XPath("//input[@id='login_field']")).Displayed
                && driver.FindElement(By.XPath("//input[@id='password']")).Displayed
                )
            {
                loginPage.typeEmail.SendKeys(emailLogin);
                loginPage.typePassword.SendKeys(passwordLogin);
                loginPage.signInButton.Click();
                Log.Information("Login process is executed successfully! Time is {Now}", DateTime.Now);
            }
            else 
            {
                Log.Error("Elements are absent!Time is {Now}", DateTime.Now);
            }
        }

        [Test, Order(2)]
        [Author("Vadym Nasypanyi", "vadym.nasypanyi@fortegrp.com")]
        //[Ignore("Ignore a test")]
        public void ExecuteReposytoryCreation()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Assert.Multiple(() =>
            {
                Assert.AreEqual(driver.Title, "GitHub", "Page title is incorrect");
                Assert.IsTrue(driver.FindElement(By.XPath("//a[@class='btn shelf-cta mx-2 mb-3']")).Text.Equals("Start a project"), "Button 'SP' is absent");
                Assert.IsTrue(driver.FindElement(By.XPath("//a[@class='btn btn-primary shelf-cta mx-2 mb-3']")).Displayed, "Block 'Read the guide' is absent");
            });

            Log.Information("Third block of Asserts is passed");

            RepositoryCreator repositoryCreator1 = new RepositoryCreator();
            PageFactory.InitElements(driver, repositoryCreator1);
            repositoryCreator1.startProjectButton.Click();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(driver.Title, "Create a New Repository", "Incorrect page title");
                Assert.IsTrue(driver.FindElement(By.XPath("//input[@id='repository_visibility_public']")).Selected, "Check-box 'Public' is NOT selected");
                Assert.IsFalse(driver.FindElement(By.XPath("//input[@id='repository_visibility_private']")).Selected, "Check-box 'Private' is selected");
                Assert.IsFalse(driver.FindElement(By.XPath("//input[@id='repository_auto_init']")).Selected, "Check-box 'ReadME' is selected");
                Assert.IsTrue(driver.FindElement(By.XPath("//button[@class='btn btn-primary first-in-line']")).Displayed, "Button 'Create Repository' is absent");

            });

            Log.Information("Forth block of Asserts is passed");

            bool selection = driver.FindElement(By.XPath("//input[@id='repository_name']")).Displayed
                             && driver.FindElement(By.XPath("//input[@id='repository_description']")).Displayed
                             && driver.FindElement(By.XPath("//input[@id='repository_auto_init']")).Displayed;
            switch (selection)
            {
                case true:
                    repositoryCreator1.typeRepositoryName.SendKeys(RepositoryName);
                    repositoryCreator1.typeDescription.SendKeys(Description);
                    repositoryCreator1.readMeRadioButton.Click();
                    IWebElement createButton =
                        wait.Until(ExpectedConditions.ElementToBeClickable(
                            By.XPath("//button[@class='btn btn-primary first-in-line']")));
                    repositoryCreator1.createRepositoryButton.Click();

                    Log.Information("Repository is created successfully! Time is {Now}", DateTime.Now);
                    Thread.Sleep(2000);
                    break;
                case false:
                    Log.Information("Fail of Repository Creation! Time is {Now}", DateTime.Now);
                    break;
                default:
                    Log.Information("That's impossible!");
                    break;
            }
        }

        [Test, Order(3)]
        [Author("Vadym Nasypanyi", "vadym.nasypanyi@fortegrp.com")]
        //[Ignore("Ignore a test")]

        public void ExecuteFileCreation()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Assert.Multiple(() =>
            {
                Assert.IsTrue(driver.FindElement(By.XPath("//h2[@class='shelf-title']")).Text.Equals("Learn Git and GitHub without any code!"), "Incorrect main title");
                Assert.IsTrue(driver.FindElement(By.XPath("//span[@class='text-gray-dark mr-2']")).Text.Equals(Description), "Incorrect Description of repository");
                Assert.IsTrue(driver.FindElement(By.XPath("//button[@class='btn btn-sm BtnGroup-item']")).Displayed, "Button 'Create New File' is absent");
            });

            Log.Information("Fifth block of Asserts is passed");

            FileCreator fileCreator1 = new FileCreator();
            PageFactory.InitElements(driver, fileCreator1);
            fileCreator1.clickCreateFile.Click();

            Assert.Multiple(() =>
            {
                Assert.IsTrue(driver.FindElement(By.XPath("//a[@class='Header-link']//*[local-name()='svg']")).Displayed, "The Button 'CommitButton' is absent");
                Assert.IsTrue(driver.FindElement(By.XPath("//div[contains(@class,'form-checkbox pl-4 mt-0 mb-2')]//label[1]/input")).Selected, "Check-box 'Commit directly to the master branch' is NOT selected");
                Assert.IsFalse(driver.FindElement(By.XPath("//div[contains(@class,'form-checkbox pl-4 my-0')]//label[1]/input")).Selected, "Check-box 'Create a new branch for this commit and start a pull request' is NOT selected");
                Assert.IsTrue(driver.FindElement(By.XPath("//a[contains(@class,'btn btn-danger flex-auto text-center mx-3 mx-md-0')]")).Enabled, "The Button 'CANCEL' is NOT selected");
            });

            Log.Information("Sixth block of Asserts is passed");

            if (
                driver.FindElement(By.XPath("//input[@placeholder='Name your file…']")).Displayed
                && driver.FindElement(By.XPath("//pre[contains(@class,'CodeMirror-line')]")).Displayed
                && driver.FindElement(By.XPath("//input[@id='commit-summary-input']")).Displayed
                && driver.FindElement(By.XPath("//textarea[@id='commit-description-textarea']")).Displayed
            )
            {
                fileCreator1.typeNameFile.SendKeys(NameFile);
                fileCreator1.typeBodyFile.SendKeys(BodyFile);
                fileCreator1.typeCommitFile.SendKeys(CommitFile);
                fileCreator1.typeCommitDescription.SendKeys(CommitDescription);
                fileCreator1.clickCommitButton.Click();
                IWebElement logoButton =
                    wait.Until(ExpectedConditions.ElementToBeClickable(
                        By.XPath("//a[@class='Header-link']//*[local-name()='svg']")));
                fileCreator1.clickLogo.Click();

                Log.Information("File Creation process is executed successfully! Time is {Now}", DateTime.Now);
            }
            else
            {
                Log.Error("Elements are absent!Time is {Now}", DateTime.Now);
            }
        }
        [Test, Order(4)]
        [Author("Vadym Nasypanyi", "vadym.nasypanyi@fortegrp.com")]
        //[Ignore("Ignore a test")]

        public void ExecuteReposytoryDeleting()
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(driver.Title, "GitHub", "Page title is incorrect");
                Assert.IsTrue(driver.FindElement(By.XPath("//div[@class='mb-3 Details js-repos-container mt-5']//h2[@class='f4 hide-sm hide-md mb-1 f5 d-flex flex-justify-between flex-items-center'][contains(text(),'Repositories')]/*")).Displayed, "The Button 'NEW' is absent");
                Assert.IsTrue(driver.FindElement(By.XPath("//div[@class='mb-3 Details js-repos-container mt-5']//div[@class='js-repos-container']")).Displayed, "The Perository container is absent");
                Assert.IsTrue(driver.FindElement(By.XPath("//input[@id='dashboard-repos-filter-left']")).Displayed, "The FIELD 'Find a repository' is absent");
            });
            Log.Information("Seventh block of Asserts is passed");

            DeletingProcess deletingProcess1 = new DeletingProcess();
            PageFactory.InitElements(driver, deletingProcess1);

            if (driver.FindElement(By.XPath("//input[@id='dashboard-repos-filter-left']")).Displayed)
            {
                deletingProcess1.SearchField.SendKeys(RepositoryFullName);
                if (driver.FindElement(By.XPath("//ul[@class='list-style-none filterable-active']//li[1]//div[1]//a[1]")).Enabled)
                {
                    deletingProcess1.RepositoryClick.Click();
                }
                else
                {
                    Log.Error("Searched repository is absent!Time is {Now}", DateTime.Now);
                }

            }
            else
            {
                Log.Error("Fail of needed repository finding !Time is {Now}", DateTime.Now);
            }
            Assert.Multiple(() =>
            {
                Assert.IsTrue(driver.FindElement(By.XPath("//h2[@class='shelf-title']")).Text.Equals("Learn Git and GitHub without any code!"), "Incorrect main title");
                Assert.IsTrue(driver.FindElement(By.XPath("//span[@class='text-gray-dark mr-2']")).Text.Equals(Description), "Incorrect Description of repository");
                Assert.IsTrue(driver.FindElement(By.XPath("//nav[@class='hx_reponav reponav js-repo-nav js-sidenav-container-pjax clearfix container-lg px-3']/a[last()]")).Displayed, "Button 'Settings' is absent");
            });

            Log.Information("Eighth block of Asserts is passed");
            deletingProcess1.SettingsClick.Click();
            if (driver.FindElement(By.XPath("//summary[contains(text(),'Delete this repository')]")).Enabled)
            {
                deletingProcess1.clickDeleteButton.Click();
                deletingProcess1.typeRepositoryFullName.SendKeys(RepositoryFullName);
                if (driver.FindElement(By.XPath("//button[contains(text(),'I understand the consequences, delete this reposit')]")).Enabled)
                {
                    deletingProcess1.clickFinalDeleting.Click();
                }
                else
                {
                    Log.Error("Button for Final Deleting is not clickable! Time is {Now}", DateTime.Now);
                }
                Log.Information("Repository Deleting process is executed successfully! Time is {Now}", DateTime.Now); 
            }
            else
            {
                Log.Error("Repository Deleting process is failed!Time is {Now}", DateTime.Now);
            }


        }
        [Test, Order(5)]
        [Author("Vadym Nasypanyi", "vadym.nasypanyi@fortegrp.com")]
        //[Ignore("Ignore a test")]

        public void ExecuteLogoutProcess()
        {

            LogoutProcess logoutProcess1 = new LogoutProcess();
            PageFactory.InitElements(driver, logoutProcess1);

            if (driver.FindElement(By.XPath("//details[@class='details-overlay details-reset js-feature-preview-indicator-container']//summary[@class='Header-link']")).Displayed)
            {
                logoutProcess1.clickHeaderButton.Click();
                if (driver.FindElement(By.XPath("//button[@class='dropdown-item dropdown-signout']")).Enabled)
                {
                    logoutProcess1.clickLogoutButton.Click();

                }
                else
                {
                    Log.Error("The Button 'Log out' is failed!Time is {Now}", DateTime.Now);

                }
            }
            else
            {
                Log.Error("Logout process is failed!Time is {Now}", DateTime.Now);
            }

            Log.Information("Logout process is executed successfully! Time is {Now}", DateTime.Now);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(driver.Url.Equals(screenUrl), "URL is incorrect");
                Assert.AreEqual(driver.Title, "The world’s leading software development platform · GitHub", "Page title is incorrect");
            });

            Log.Information("Final block of Asserts is passed. User is located on the Main screen");
        }

    }
}
