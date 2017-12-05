using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Tribalwars.Api.Services
{
    public static class TribalWarsSeleniumCommand
    {
        public static readonly List<string> UrlList = new List<string>
        {
           "https://tr43.klanlar.org/game.php?screen=main",
           "https://tr43.klanlar.org/game.php?screen=place",
           "https://tr43.klanlar.org/game.php?screen=barracks",
           "https://tr43.klanlar.org/game.php?screen=smith",
           "https://tr43.klanlar.org/game.php?screen=stable",
           "https://tr43.klanlar.org/game.php?screen=farm",
           "https://tr43.klanlar.org/game.php?screen=main",
           "https://tr43.klanlar.org/game.php?screen=main",
           "https://tr43.klanlar.org/game.php?screen=main",
           "https://tr43.klanlar.org/game.php?screen=main",
           "https://tr43.klanlar.org/game.php?screen=main"
        };

        public static bool FarmWithLc(IWebDriver driver, int lc, int x, int y)
        {
            if (!driver.Url.Equals("https://tr43.klanlar.org/game.php?screen=place"))
                driver.Navigate().GoToUrl("https://tr43.klanlar.org/game.php?screen=place");

            try
            {
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 0, 10));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("unit_input_light")));

                driver.FindElement(By.Id("unit_input_light")).SendKeys($"{lc}");
                driver.FindElement(By.ClassName("target-input-field")).SendKeys($"{x}|{y}");

                driver.FindElement(By.Id("target_attack")).Click();

                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("troop_confirm_go")));
                driver.FindElement(By.Id("troop_confirm_go")).Click();

            }
            catch
            {
                return false;
            }

            return true;
        }

        public static bool NavigateRandomUrl(IWebDriver driver)
        {
            var rnd = new Random().Next(1, UrlList.Count);
            try
            {
                driver.Navigate().GoToUrl(UrlList[rnd]);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
