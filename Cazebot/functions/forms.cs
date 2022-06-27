using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Cazebot.functions;

public class forms
{
  private testutils _utils = new testutils();
  public void Inicio(IWebDriver driver)
  {
    _utils.IrEMaximizar(driver, "https://miaw.mtv.com.br/vote/icono-miaw");

  }

  public void ClicaNoCaze(IWebDriver driver)
  {
    _utils.EsperaAparecerClica(driver,
      By.XPath(
        "//*[@id='main']/div/div/div/div[2]/div[2]/div[1]/div[1]/div/div[2]/div[1]/div[2]/div/div/div[3]/div/div[2]/div/div[2]"));
  }

  public void Continuar(IWebDriver driver)
  {
    _utils.EsperaAparecerClica(driver, By.XPath("//a[contains(text(),'Vote')]"));
    _utils.EsperaAparecerClica(driver, By.XPath("//a[contains(text(),'Ícone MIAW')]"));
    
  }
} 