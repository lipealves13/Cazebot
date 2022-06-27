using Cazebot.functions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Cazebot;


class Program
{
	public static void Main(string[] args)
	{
		IWebDriver driver = new ChromeDriver();
		var forms = new forms();
		forms.Inicio(driver);
		var a = 1000;
		while (a>0)
		{
			var i = 10;
			while (i > 0)
			{
				forms.ClicaNoCaze(driver);
				i = i - 1;
			}
			a = a - 1;
			forms.Continuar(driver);
		}
		return ;
	}
}