package Github;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;

import java.io.File;

public class FileCreator {
    private WebDriver driver;
    public FileCreator(WebDriver driver) {
        this.driver = driver;
    }
    private By createRepositoryFile = By.xpath("//button[@class='btn btn-sm BtnGroup-item']");
    private By NameFile = By.xpath("//input[@placeholder='Name your file…']");
    private By BodyFile = By.xpath("//pre[contains(@class,'CodeMirror-line')]");
    private By CommitFileName = By.xpath("//input[@id='commit-summary-input']");
    private By CommitDescription = By.xpath("//textarea[@id='commit-description-textarea']");
    private By CommitButton = By.xpath("//button[@id='submit-file']");
    private By SettingsButton = By.xpath("//nav[@class='hx_reponav reponav js-repo-nav js-sidenav-container-pjax clearfix container-lg px-3']/a[last()]");
    private By HeaderButton = By.xpath("//details[@class='details-overlay details-reset js-feature-preview-indicator-container']//summary[@class='Header-link']");
    private By LogoutButton = By.xpath("//button[@class='dropdown-item dropdown-signout']");

    public FileCreator clickCreateFile(){
        driver.findElement(createRepositoryFile).click();
        return this;
    }
    public FileCreator typeNameFile(String Name){
        driver.findElement(NameFile).sendKeys(Name);
        return this;
    }
    public FileCreator typeBodyFile(String Body){
        driver.findElement(BodyFile).sendKeys(Body);
        return this;
    }
    public FileCreator typeCommitFile(String CommitName){
        driver.findElement(CommitFileName).sendKeys(CommitName);
        return this;
    }
    public FileCreator typeCommitDescription(String Description){
        driver.findElement(CommitDescription).sendKeys(Description);
        return this;
    }
    public FileCreator clickCommitButton(){
        driver.findElement(CommitButton).click();
        return this;
    }
    public SettingsMenu clickSettingsButton(){
        driver.findElement(SettingsButton).click();
        return new SettingsMenu(driver);
    }
    public SettingsMenu clickHeaderButton(){
        driver.findElement(HeaderButton).click();
        return new SettingsMenu(driver);
    }
    public SettingsMenu clickLogoutButton(){
        driver.findElement(LogoutButton).click();
        return new SettingsMenu(driver);
    }

    public FileCreator createFile(String Name, String Body, String CommitName, String Description){
        this.clickCreateFile();
        this.typeNameFile(Name);
        this.typeBodyFile(Body);
        this.typeCommitFile(CommitName);
        this.typeCommitDescription(Description);
        this.clickCommitButton();
        this.clickSettingsButton();
        this.clickHeaderButton();
        this.clickLogoutButton();
        return this;
    }


}
