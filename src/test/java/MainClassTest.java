import Github.CreatorPage;
import Github.LoginPage;
import Github.RepositoryMenu;
import org.junit.*;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

import java.util.concurrent.TimeUnit;

public class MainClassTest {

    private WebDriver driver;
    private LoginPage loginPageTest;
    private CreatorPage creatorPageTest;
    //WebDriverWait wait1 = new WebDriverWait(driver, 5);
    @Before
    public void setUp() {
        System.setProperty("webdriver.chrome.driver", "C:\\Users\\vadym.nasypanyi\\Downloads\\chromedriver_win32\\chromedriver.exe");
        //ChromeDriver driver = new ChromeDriver();
        driver = new ChromeDriver();
        driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
        //WebDriverWait wait = new WebDriverWait(driver, 5);
        driver.manage().window().maximize();
        driver.get("https://github.com/");
        loginPageTest = new LoginPage(driver);
        creatorPageTest = new CreatorPage(driver);




    }


    @Test

    public void RepositoryCreator() {
        CreatorPage loginPage1 = loginPageTest.loginProcess("nv.test1.demo@gmail.com", "CSWINksk2");
        String heading1 = loginPageTest.getHeadingText1();
        Assert.assertEquals("Create a new repository", heading1);
    }
    @Test

    public void MainMenu() {
        CreatorPage loginPage1 = loginPageTest.loginProcess_short("nv.test1.demo@gmail.com", "CSWINksk2");
        String heading2 = loginPageTest.getHeadingText2();
        Assert.assertEquals("Learn Git and GitHub without any code!", heading2);
    }
    @Test

    public void Login() {
        LoginPage loginPage1 = loginPageTest.firstButton();
        String heading = loginPageTest.getHeadingText();
        Assert.assertEquals("Sign in to GitHub", heading);
    }





    @After
    public void tearDown() {
        driver.quit();
    }








}




