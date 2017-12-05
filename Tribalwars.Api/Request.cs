using OpenQA.Selenium;
using Tribalwars.Api.Models;
using Tribalwars.Api.Services;

namespace Tribalwars.Api
{
    public class Request
    {
        public User User { get; set; }

        public Request()
        {
            User = new User();
        }

        public User EnterGame(string userName, string password, string world, IWebDriver driver)
        {
            if (!TribalWarsSeleniumParser.EnterGame(userName, password, driver))
                return null;

            User.UserName = userName;
            User.World = world;

            return TribalWarsSeleniumParser.InstantiateUser(driver, User);

        }

        public int ReturnLightCavalryAmount(IWebDriver driver)
        {
            return TribalWarsSeleniumParser.ReturnLightCavalries(driver);
        }

        public bool Farm(IWebDriver driver, int lcAmount, int x, int y)
        {
            return TribalWarsSeleniumCommand.FarmWithLc(driver, lcAmount, x, y);
        }

        public bool NavigateRandomUrl(IWebDriver driver)
        {
            return TribalWarsSeleniumCommand.NavigateRandomUrl(driver);
        }
    }
}
