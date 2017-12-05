using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using Tribalwars.Api;
using Tribalwars.Api.Models;
using Tribalwars.Models;
using Tribalwars.Properties;

namespace Tribalwars.Controllers
{
    public class MainController
    {
        public User User { get; set; }

        private readonly IWebDriver _driver;
        private readonly TrivalwarsContext _context;
        private readonly Request _api;

        private int _counter;

        public MainController()
        {
            _context = new TrivalwarsContext();

            _api = new Request();

            _driver = new ChromeDriver(@"D:\SeleniumDrivers\");
            _driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 0, 10);
        }

        public bool EnterGame()
        {
            User = _api.EnterGame(Settings.Default.UserName, Settings.Default.Password, Settings.Default.World, _driver);

            return User != null;
        }

        public bool Attack()
        {
            var defaultLc = 8;

            _counter ++;
            if (_counter > 5)
            {
                _api.NavigateRandomUrl(_driver);
                _counter = 0;
                return true;
            }

            if (_api.ReturnLightCavalryAmount(_driver) < defaultLc)
                return false;

            //get all the farm villages
            var village = _context.FarmVillages.Where(x => x.DateAttacked < DateTime.Now)
                .OrderBy(o => o.DateAttacked).FirstOrDefault();
            if (village == null) return false;

            if (!_api.Farm(_driver, defaultLc, village.X, village.Y))
                return false;

            _context.FarmAttacks.Add(new FarmAttacks
            {
                AmountLc = defaultLc,
                Date = DateTime.Now,
                FarmId = village.Id
            });

            int minutesToAdd = (int)Math.Sqrt(Math.Pow(525 - village.X, 2) + Math.Pow(607 - village.Y, 2)) * 20;

            village.DateAttacked = DateTime.Now.AddMinutes(minutesToAdd);

            return _context.SaveChanges() >= 0;
        }

        public List<FarmAttacks> ReturnAttackData()
        {
            var yesterday = DateTime.Now.AddDays(-1);
            return _context.FarmAttacks.Where(x => x.Date > yesterday).ToList();
        }

        public List<FarmVillages> AddNewFarmVillage(string xCoord, string yCoord, string name = "village")
        {
            if(xCoord.Equals("") && yCoord.Equals(""))
                return _context.FarmVillages.ToList();

            try
            {
                var x = int.Parse(xCoord);
                var y = int.Parse(yCoord);

                if (_context.FarmVillages
                    .FirstOrDefault(_ => _.X == x && _.Y == y) != null)
                    return null;

                _context.FarmVillages.Add(new FarmVillages
                {
                    Name = name,
                    X = x,
                    Y = y,
                    TimesAttacked = 0,
                    DateAttacked = DateTime.Now
                });
            }
            catch
            {
                return null;
            }

            _context.SaveChanges();

            return _context.FarmVillages.ToList();
        }

    }
}
