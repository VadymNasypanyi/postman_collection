package Github;


import org.openqa.selenium.By;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;


public class MainClass {
    public static void main(String[] args) {
        System.setProperty("webdriver.chrome.driver", "C:\\Users\\vadym.nasypanyi\\Downloads\\chromedriver_win32\\chromedriver.exe");
        ChromeDriver driver = new ChromeDriver();
        //driver.manage().timeouts().implicitlyWait(15, TimeUnit.SECONDS);

        WebDriverWait wait = new WebDriverWait(driver, 5);
        driver.manage().window().maximize();

        driver.get("https://github.com/");


        LoginPage login = new LoginPage(driver);
        login.loginProcess("nv.test1.demo@gmail.com","CSWINksk2");

        CreatorPage creator = new CreatorPage(driver);
        creator.typeMainFields("Vadim_Nasypanyi_4/3/20_20","test_Description");
        WebElement CreateRepositoryButton;
        CreateRepositoryButton = wait.until(ExpectedConditions.elementToBeClickable(By.xpath("//button[@class='btn btn-primary first-in-line']")));
        CreateRepositoryButton.click();

        FileCreator createFile = new FileCreator(driver);
        createFile.createFile("Vadim_Demo","class HelloWorld{public static void main(String[] args) {System.out.println('Hello_World!')}","Vadim_Commit_Demo_4/3_2020","Vadim_Nasypanyi_Auto_Test");

        driver.quit();







    }
}
