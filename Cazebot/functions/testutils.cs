using System.Collections.ObjectModel;
using System.Text;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Cazebot.functions
{


  public class testutils
{
  public void ClickClearSendKeys(IWebDriver driver, By by, string text, int tempo = 120)
  {
    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(tempo));
    var element = wait.Until(ExpectedConditions.ElementExists(by));
    element = wait.Until(ExpectedConditions.ElementIsVisible(by));
    wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
    if (wait.Until(ExpectedConditions.ElementIsVisible(by)).Displayed && element.TagName != null)
    {
      element.FindElement(by).Click();
      element.FindElement(by).Clear();
      element.FindElement(by).SendKeys(text);
    }
  }

  public void ClickClear(IWebDriver driver, By by)
  {
    driver.FindElement(by).Click();
    driver.FindElement(by).Clear();
  }

  public void IrEMaximizar(IWebDriver driver, string url)
  {
    driver.Navigate().GoToUrl(url);
    driver.Manage().Window.Maximize();
  }

  public dynamic MassTest(string fileName)
  {
    var dir = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\..\\DataSource\\" + fileName + "");
    var json = File.ReadAllText(dir);
    return JObject.Parse(json);
  }

  public string TabPegaNomeAtual(IWebDriver driver)
  {
    return driver.CurrentWindowHandle;
  }

  public string TabAbertaPegaNome(IWebDriver driver)
  {
    driver.ExecuteJavaScript("window.open();");
    Thread.Sleep(2000);
    return driver.WindowHandles.Last();
  }

  public void TabFechaAtual(IWebDriver driver)
  {
    driver.ExecuteJavaScript("window.close();");
  }

  public ReadOnlyCollection<string> TabPegaTodosNomes(IWebDriver driver)
  {
    return driver.WindowHandles;
  }

  public void TabMudarPara(IWebDriver driver, string nameWindows)
  {
    driver.SwitchTo().Window(nameWindows);
  }

  public virtual void CheckboxButton(IWebDriver driver, By by)
  {
    var action = new Actions(driver);
    action.MoveToElement(driver.FindElement(by)).Click().Build().Perform();
  }

  public virtual void AguardarTotalCarregamento(IWebDriver driver, int tempo = 30)
  {
    IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(tempo));

    wait.Until(driver1 =>
        ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
  }

  public virtual void RadioButton(IWebDriver driver, By element)
  {
    driver.FindElement(element).Click();
  }

  public virtual IWebElement EsperaAparecerClicaEscreve(IWebDriver driver, By by, string text, int tempo = 100)
  {
    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(tempo));
    var element = wait.Until(ExpectedConditions.ElementExists(by));
    element = wait.Until(ExpectedConditions.ElementIsVisible(by));
    if (wait.Until(ExpectedConditions.ElementIsVisible(by)).Displayed && element.TagName != null)
    {
      element.Click();
      element.SendKeys(text);
    }

    return null;
  }

  public virtual IWebElement EsperaAparecerClica(IWebDriver driver, By by, int tempo = 60)
  {
    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(tempo));
    var element = wait.Until(ExpectedConditions.ElementExists(by));
    element = wait.Until(ExpectedConditions.ElementIsVisible(by));
    if (wait.Until(ExpectedConditions.ElementIsVisible(by)).Displayed && element.TagName != null) element.Click();
    return element;
  }

  public virtual IWebElement EsperaAparecerClicaLista(IWebDriver driver, By by, int num, int tempo = 40)
  {
    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(tempo));
    ReadOnlyCollection<IWebElement> element = driver.FindElements(by);
    var chosenElement = element[num];
    wait.Until(d => chosenElement.Enabled && chosenElement.Displayed);
    if (chosenElement.TagName != null) chosenElement.Click();
    return chosenElement;
  }

  public virtual IWebElement GetElement(IWebDriver driver, By by, int tempo = 40)
  {
    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(tempo));
    var element = wait.Until(ExpectedConditions.ElementExists(by));
    element = wait.Until(ExpectedConditions.ElementIsVisible(by));
    if (wait.Until(ExpectedConditions.ElementIsVisible(by)).Displayed && element.TagName != null) return element;
    return null;
  }


  public virtual IWebElement EsperaElementoAparecer(IWebDriver driver, By by, int tempo = 60)
  {
    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(tempo));
    var element = wait.Until(ExpectedConditions.ElementExists(by));
    element = wait.Until(ExpectedConditions.ElementIsVisible(by));
    if (wait.Until(ExpectedConditions.ElementIsVisible(by)).Displayed) return element;
    return null;
  }

  public virtual IWebElement EsperaAparecer(IWebDriver driver, By by, int tempo = 60)
  {
    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(tempo));
    wait.Until(ExpectedConditions.ElementIsVisible(by));
    var element = wait.Until(ExpectedConditions.ElementToBeClickable(by));
    if (element.TagName != null) return element;
    return null;
  }

  public virtual bool EsperarCarregar(IWebDriver driver, By by, int tempo = 120)
  {
    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(tempo));
    wait.Timeout = TimeSpan.FromSeconds(45);
    wait.Until(ExpectedConditions.ElementExists(by));
    wait.Until(ExpectedConditions.ElementIsVisible(by));
    wait.Timeout = TimeSpan.FromSeconds(tempo);
    if (wait.Until(ExpectedConditions.InvisibilityOfElementLocated(by)))
      return true;
    return false;
  }

  public virtual void EventFire(IWebDriver driver, string elemento, string evento)
  {
    var js = (IJavaScriptExecutor)driver;
    var stringBuilder = new StringBuilder();
    stringBuilder.Append(
        "function eventFire(el, etype){ if (el.fireEvent) { el.fireEvent('on' + etype); } else { var evObj = document.createEvent('Events'); evObj.initEvent(etype, true, false); el.dispatchEvent(evObj); } }; window.onload=eventFire(" +
        elemento + ",'" + evento + "')");
    js.ExecuteScript(stringBuilder.ToString());
  }

  public virtual IWebElement EsperaSerClicavelClica(IWebDriver driver, By by, int tempo = 40)
  {
    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(tempo));
    var element = wait.Until(ExpectedConditions.ElementExists(by));
    element = wait.Until(ExpectedConditions.ElementIsVisible(by));
    element = wait.Until(ExpectedConditions.ElementToBeClickable(by));

    if (wait.Until(ExpectedConditions.ElementToBeClickable(by)).Displayed && element.TagName != null)
      element.Click();
    return null;
  }
  
  public virtual bool ValidaTexto(IWebDriver driver, By @by, string textoEsperado, int tempo = 60)
  {
    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(tempo));
    var element = wait.Until(ExpectedConditions.ElementExists(by));
    element = wait.Until(ExpectedConditions.ElementIsVisible(by));
    if (wait.Until(ExpectedConditions.ElementIsVisible(by)).Displayed && element.Text == textoEsperado)
    {
      Console.WriteLine("Texto Válido");
      return true;
    }

    Console.WriteLine("Texto Inválido");
    return false;

  }
}
}