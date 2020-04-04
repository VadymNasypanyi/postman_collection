package Github;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

public class CreatorPage {
    private WebDriver driver;

    public CreatorPage(WebDriver driver) {
        this.driver = driver; }
    private By repositoryName = By.xpath("//input[@id='repository_name']");
    private By repositoryDescription = By.xpath("//input[@id='repository_description']");
    private By readMeRadioButton = By.xpath("//input[@id='repository_auto_init']");
    private By createRepositoryButton = By.xpath("//button[@class='btn btn-primary first-in-line']");
    private By createRepositoryFile = By.xpath("//button[@class='btn btn-sm BtnGroup-item']");

    public CreatorPage typeName(String Name){
        driver.findElement(repositoryName).sendKeys(Name);
        return this;
    }
    public CreatorPage typeDescription(String Description){
        driver.findElement(repositoryDescription).sendKeys(Description);
        return this;
    }
    public CreatorPage clickReadMe(){
        driver.findElement(readMeRadioButton).click();
        return this;
    }
    public RepositoryMenu clickCreateRep(){
        driver.findElement(createRepositoryButton).click();
        return new RepositoryMenu(driver);
    }
    public FileCreator clickCreateFile(){
        driver.findElement(createRepositoryFile).click();
        return new FileCreator(driver);
    }



    public RepositoryMenu typeMainFields(String Name, String Description) {
        this.typeName(Name);
        this.typeDescription(Description);
        this.clickReadMe();
        //this.clickCreateRep();
        //this.clickCreateFile();
        return new RepositoryMenu(driver);
    }






}

