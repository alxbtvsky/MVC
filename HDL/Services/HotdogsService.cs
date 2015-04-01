using HDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HDL.Services
{
    public class HotdogsService
    {
        private static List<Hotdogs> hotdogsList;
        static HotdogsService()
        {
            hotdogsList = new List<Hotdogs>();
            Hotdogs hotdog1 = new Hotdogs()
            {
                HotdogsID = 1,
                HotdogsName = "Alex's Dog",
                LastPlaceAte = "Alex's",
                LastTimeAte = new DateTime(),
                Rating = 10
            };
            hotdogsList.Add(hotdog1);

            Hotdogs hotdog2 = new Hotdogs()
            {
                HotdogsID = 2,
                HotdogsName = "Chris' Dog",
                LastPlaceAte = "Chris'",
                LastTimeAte = new DateTime(),
                Rating = 9
            };
            hotdogsList.Add(hotdog2);

            Hotdogs hotdog3 = new Hotdogs()
            {
                HotdogsID = 3,
                HotdogsName = "Bryan's Dog",
                LastPlaceAte = "Bryan's",
                LastTimeAte = new DateTime(),
                Rating = 8
            };
            hotdogsList.Add(hotdog3);
        }

        public List<Hotdogs> listAll()
        {
            return hotdogsList;
        }
        public Hotdogs Get(int id)
        {
            Hotdogs selectedHotdog = new Hotdogs();
            foreach (Hotdogs hotdog in hotdogsList)
            {
                if (hotdog.HotdogsID == id)
                {
                    selectedHotdog = hotdog;
                }
            }
            return selectedHotdog;
        }
        public void Add(Hotdogs hotdog)
        {
            hotdogsList.Add(hotdog);
        }
        public void Remove(Hotdogs hotdog)
        {
            hotdogsList.Remove(hotdog);
        }
    }
}