using HotDogLover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotDogLover.Services
{
    public class HotDogService
    {
        private static List<HotDog> hotDogs;
        static HotDogService() {
            hotDogs = new List<HotDog>();
            HotDog dog1 = new HotDog()
            {
                HotDogID = 1,
                HotDogName = "Alex's Dog",
                LastPlaceAte = "Alex's",
                LastTimeAte = new DateTime(),
                Rating = 10
            };
            hotDogs.Add(dog1);
           
            HotDog dog2 = new HotDog()
            {
                HotDogID = 2,
                HotDogName = "Chris' Dog",
                LastPlaceAte = "Chris'",
                LastTimeAte = new DateTime(),
                Rating = 9
            };
            hotDogs.Add(dog2);

            HotDog dog3 = new HotDog()
            {
                HotDogID = 3,
                HotDogName = "Bryan's Dog",
                LastPlaceAte = "Bryan's",
                LastTimeAte = new DateTime(),
                Rating = 8
            };
            hotDogs.Add(dog3);
        }

        public List<HotDog> listAll(){
            return hotDogs;
        }
        public HotDog Get(int id) {
            HotDog selectedDog = new HotDog();
            foreach (HotDog hotdog in hotDogs) {
                if (hotdog.HotDogID == id) {
                    selectedDog = hotdog;
                }
            }
            return selectedDog;
        }
        public void Add(HotDog hotdog) {
            hotDogs.Add(hotdog);
        }
        public void Remove(HotDog hotdog) {
            hotDogs.Remove(hotdog);
        }
    }
}