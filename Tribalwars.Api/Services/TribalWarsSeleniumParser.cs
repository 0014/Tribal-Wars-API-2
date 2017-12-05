using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using Tribalwars.Api.Enums;
using Tribalwars.Api.Models;

namespace Tribalwars.Api.Services
{
    public static class TribalWarsSeleniumParser
    {
        public static bool EnterGame(string user, string password, IWebDriver driver)
        {
            driver.Navigate().GoToUrl("https://www.klanlar.org/");

            driver.FindElement(By.Id("user")).SendKeys(user);
            driver.FindElement(By.Id("password")).SendKeys(password);

            driver.FindElement(By.ClassName("btn-login")).Click();

            var wait = new WebDriverWait(driver, new TimeSpan(0,0,0,10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("world_button_active")));

            driver.FindElement(By.ClassName("world_button_active")).Click();

            return true;
        }

        public static User InstantiateUser(IWebDriver driver, User user)
        {
            if(!driver.Url.Equals($"https://tr{user.World}.klanlar.org/game.php?screen=overview&intro"))
                driver.Navigate().GoToUrl($"https://tr{user.World}.klanlar.org/game.php?screen=overview&intro");

            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 0, 10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("tooltip-delayed")));

            user.Villages = new List<Village> { GetVillage(driver) };
            return user;
        }

        public static Village GetVillage(IWebDriver driver)
        {
            var villageName = driver
                .FindElement(By.XPath("//a[contains(@class, 'nowrap') and contains(@class, 'tooltip-delayed')]")).Text;

            return new Village
            {
                Name = villageName,
                Coordinates = GetCoordinates(driver),
                Resources = GetResources(driver),
                Army = GetArmy(driver),
                Buildings = GetBuildings(driver)
            };
        }

        public static Coordinates GetCoordinates(IWebDriver driver)
        {
            var coordinates = driver.FindElement(By.XPath("//td[@class='box-item']")).Text;
            
            return new Coordinates
            {
                X = int.Parse(coordinates.Substring(1, 3)),
                Y = int.Parse(coordinates.Substring(5, 3))
            };
        }

        public static Resources GetResources(IWebDriver driver)
        {
            return new Resources
            {
                Wood = int.Parse(driver.FindElement(By.Id("wood")).Text),
                Clay = int.Parse(driver.FindElement(By.Id("stone")).Text),
                Iron = int.Parse(driver.FindElement(By.Id("iron")).Text),
                Date = DateTime.Now
            };
        }

        public static List<Troops> GetArmy(IWebDriver driver)
        {
            var army = new List<Troops>();
            // get spears
            var amount = driver
                .FindElements(By.XPath($"//td[contains(., 'zrak') and not(contains(., 'asker topla'))]"))
                .FirstOrDefault();

            if (amount != null)
            {
                army.Add(new Troops
                {
                    Type = TroopTypes.Spear,
                    Name = "Spears",
                    Amount = int.Parse(amount.Text.Split(' ')[0]),
                    Date = DateTime.Now
                });
            }

            // get swordsman
            amount = driver
                .FindElements(By.XPath($"//td[contains(., 'stas') and not(contains(., 'asker topla'))]"))
                .FirstOrDefault();

            if (amount != null)
            {
                army.Add(new Troops
                {
                    Type = TroopTypes.Swords,
                    Name = "Swords",
                    Amount = int.Parse(amount.Text.Split(' ')[0]),
                    Date = DateTime.Now
                });
            }

            // get axes
            amount = driver
                .FindElements(By.XPath($"//td[contains(., 'altac') and not(contains(., 'asker topla'))]"))
                .FirstOrDefault();

            if (amount != null)
            {
                army.Add(new Troops
                {
                    Type = TroopTypes.Axe,
                    Name = "Axe",
                    Amount = int.Parse(amount.Text.Split(' ')[0]),
                    Date = DateTime.Now
                });
            }

            // get scouts
            amount = driver
                .FindElements(By.XPath($"//td[contains(., 'asus') and not(contains(., 'asker topla'))]"))
                .FirstOrDefault();

            if (amount != null)
            {
                army.Add(new Troops
                {
                    Type = TroopTypes.Scout,
                    Name = "Scout",
                    Amount = int.Parse(amount.Text.Split(' ')[0]),
                    Date = DateTime.Now
                });
            }
            // get light cavalry
            amount = driver
                .FindElements(By.XPath($"//td[contains(., 'afif') and not(contains(., 'asker topla'))]"))
                .FirstOrDefault();

            if (amount != null)
            {
                army.Add(new Troops
                {
                    Type = TroopTypes.LightCavalry,
                    Name = "LC",
                    Amount = int.Parse(amount.Text.Split(' ')[0])
                });
            }
            // get heavy cavalry
            amount = driver
                .FindElements(By.XPath($"//td[contains(., 'ğır') and not(contains(., 'asker topla'))]"))
                .FirstOrDefault();

            if (amount != null)
            {
                army.Add(new Troops
                {
                    Type = TroopTypes.HeavyCavalry,
                    Name = "HC",
                    Amount = int.Parse(amount.Text.Split(' ')[0]),
                    Date = DateTime.Now
                });
            }
            // get ram
            amount = driver
                .FindElements(By.XPath($"//td[contains(., 'ahmerdan') and not(contains(., 'asker topla'))]"))
                .FirstOrDefault();

            if (amount != null)
            {
                army.Add(new Troops
                {
                    Type = TroopTypes.Ram,
                    Name = "Ram",
                    Amount = int.Parse(amount.Text.Split(' ')[0]),
                    Date = DateTime.Now
                });
            }
            // get cats
            amount = driver
                .FindElements(By.XPath($"//td[contains(., 'Manc') and not(contains(., 'asker topla'))]"))
                .FirstOrDefault();

            if (amount != null)
            {
                army.Add(new Troops
                {
                    Type = TroopTypes.Catapult,
                    Name = "Cat",
                    Amount = int.Parse(amount.Text.Split(' ')[0]),
                    Date = DateTime.Now
                });
            }
            // get nobleman
            amount = driver
                .FindElements(By.XPath($"//td[contains(., 'isyoner') and not(contains(., 'asker topla'))]"))
                .FirstOrDefault();

            if (amount != null)
            {
                army.Add(new Troops
                {
                    Type = TroopTypes.Nobleman,
                    Name = "Noble",
                    Amount = int.Parse(amount.Text.Split(' ')[0]),
                    Date = DateTime.Now
                });
            }

            return army;
        }

        public static int ReturnLightCavalries(IWebDriver driver)
        {
            try
            {
                if (!driver.Url.Equals("https://tr43.klanlar.org/game.php?screen=overview&intro"))
                    driver.Navigate().GoToUrl("https://tr43.klanlar.org/game.php?screen=overview&intro");

                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 0, 10));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("tooltip-delayed")));

            }
            catch
            {
                return 0;
            }

            // get light cavalry
            var amount = driver
                .FindElements(By.XPath("//td[contains(., 'afif') and not(contains(., 'asker topla'))]"))
                .FirstOrDefault();

            return amount == null ? 0 : int.Parse(amount.Text.Split(' ')[0]);
        }

        public static List<Building> GetBuildings(IWebDriver driver)
        {
            return new List<Building>();
        }
    }
}
