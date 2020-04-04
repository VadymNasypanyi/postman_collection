import Github.CreatorPage;
import Github.LoginPage;
import jdk.nashorn.internal.ir.annotations.Ignore;
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

   @Before
    public void setUp(){
       System.setProperty("webdriver.chrome.driver", "C:\\Users\\vadym.nasypanyi\\Downloads\\chromedriver_win32\\chromedriver.exe");
       ChromeDriver driver = new ChromeDriver();
       driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
       WebDriverWait wait = new WebDriverWait(driver, 5);
       driver.manage().window().maximize();
       driver.get("https://github.com/");
       loginPageTest = new LoginPage(driver);


   }

   @Test
   public void signIn(){
       CreatorPage creatorPage1 = loginPageTest.loginProcess("nv.test1.demo@gmail.com", "CSWINksk2");
       String heading = loginPageTest.getHeadingText();
       Assert.assertEquals("Create a new repository", heading);
   }

   @Test
   @Ignore
   public void Test(){

   }


   @AfterClass
    public void tearDown(){
       driver.quit();
   }
}
