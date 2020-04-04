package Github;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;

public class CentralMenu {
    private WebDriver driver;
    public CentralMenu(WebDriver driver) {
        this.driver = driver;
    }
    private By startProjectButton = By.xpath("//a[@class='btn shelf-cta mx-2 mb-3']");
    public CreatorPage startProject(){
        driver.findElement(startProjectButton).click();
        return new CreatorPage(driver);
    }




}
