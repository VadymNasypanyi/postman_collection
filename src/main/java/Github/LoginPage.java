package Github;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;

public class LoginPage {
    private WebDriver driver;
    public LoginPage(WebDriver driver) {
        this.driver = driver;
    }
    private By emailFieldFirst = By.xpath("//input[@id='login_field']");
    private By passwordFieldFirst = By.xpath("//input[@id='password']");
    private By signInButton = By.xpath("//input[@name='commit']");
    private By signInMainButton = By.xpath("//a[@class='HeaderMenu-link no-underline mr-3']");
    private By startProjectButton = By.xpath("//a[@class='btn shelf-cta mx-2 mb-3']");
    private By heading1 = By.xpath("//h2[@class='Subhead-heading']");
    private By heading = By.xpath("//h1[contains(text(),'Sign in to GitHub')]");
    private By heading2 = By.xpath("//h2[@class='shelf-title']");


    public String getHeadingText(){
        return driver.findElement(heading).getText();
    }
    public String getHeadingText1(){
        return driver.findElement(heading1).getText();
    }
    public String getHeadingText2(){
        return driver.findElement(heading2).getText();
    }

    public LoginPage typeEmail1(String email1){
        driver.findElement(emailFieldFirst).sendKeys(email1);
        return this;
    }
    public LoginPage typePassword1(String password1){
        driver.findElement(passwordFieldFirst).sendKeys(password1);
        return this;
    }
    public CentralMenu clickSignButton(){
        driver.findElement(signInButton).click();
        return new CentralMenu(driver);
    }
    public LoginPage firstButton() {
        driver.findElement(signInMainButton).click();
        return new LoginPage(driver);
    }
    public CreatorPage startProject(){
            driver.findElement(startProjectButton).click();
            return new CreatorPage(driver);
    }

    public CreatorPage loginProcess(String email, String password){
        this.firstButton();
        this.typeEmail1(email);
        this.typePassword1(password);
        this.clickSignButton();
        this.startProject();
        return new CreatorPage(driver);
    }
    public CreatorPage loginProcess_short(String email, String password){
        this.firstButton();
        this.typeEmail1(email);
        this.typePassword1(password);
        this.clickSignButton();
        //this.startProject();
        return new CreatorPage(driver);
    }


}


