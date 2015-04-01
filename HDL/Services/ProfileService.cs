using HDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HDL.Services
{
    public class ProfileService
    {
        private static List<Profile> profiles;
        private static HotdogsService hotdogService;
        static ProfileService()
        {
            reload();
        }


        public List<Profile> ListAll()
        {
            return profiles;
        }
        public Profile Get(int id)
        {
            Profile foundProfile = new Profile();
            foreach (Profile profile in profiles)
            {
                if (profile.ProfileID == id)
                {
                    foundProfile = profile;
                }
            }
            return foundProfile;
        }
        public void Add(Profile profile)
        {
            if (profile == null)
            {
                return;
            }

            profiles.Add(profile);
        }

        public void AddDog(Profile profile, Hotdogs dog)
        {
            Profile p = Get(profile.ProfileID);
            p.HotdogList.Add(dog);

        }
        public void Remove(Profile profile)
        {
            if (profile == null)
            {
                return;
            }

            Profile profileToRemove = null;
            foreach (Profile p in profiles)
            {
                if (p.ProfileID == profile.ProfileID)
                {
                    profileToRemove = p;
                }
            }
            if (profileToRemove != null)
            {
                profiles.Remove(profileToRemove);
            }
        }
        public void Update(Profile profile)
        {
            Profile profileToUpdate = Get(profile.ProfileID);

            profileToUpdate.Name = profile.Name;
            profileToUpdate.Picture = profile.Picture;
            profileToUpdate.AboutMe = profile.AboutMe;

            Remove(profile);
            Add(profileToUpdate);
        }
        public static void reload()
        {
            hotdogService = new HotdogsService();
            profiles = new List<Profile>();

            List<Hotdogs> myFavoriteHotdogs = new List<Hotdogs>();
            myFavoriteHotdogs.Add(hotdogService.Get(1));
            myFavoriteHotdogs.Add(hotdogService.Get(2));
            myFavoriteHotdogs.Add(hotdogService.Get(3));

            Profile p1 = new Profile()
            {
                Name = "Alex",
                AboutMe = "My Name is Alex and my favorite hot dog is my hotdog!",
                Picture = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcTUimzq6P3hPYTbxKiPvfoDr1NcouiFjmn5xEEgKbYyXhr4-rZa",
                ProfileID = 1,
                FavoriteHotdog = hotdogService.Get(1),
                HotdogList = myFavoriteHotdogs
            };
            profiles.Add(p1);

            myFavoriteHotdogs = new List<Hotdogs>();
            myFavoriteHotdogs.Add(hotdogService.Get(1));
            myFavoriteHotdogs.Add(hotdogService.Get(3));

            Profile p2 = new Profile()
            {
                Name = "Bryan",
                AboutMe = "My Name is Bryan and my favorite hot dog is my hotdog!",
                Picture = "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcRMTfL6jkJW42L3_wOsv2j_VtdddNTkj2mILErKqFkXGgQzAM82Lg",
                ProfileID = 2,
                FavoriteHotdog = hotdogService.Get(3),
                HotdogList = myFavoriteHotdogs
            };
            profiles.Add(p2);

            myFavoriteHotdogs = new List<Hotdogs>();
            myFavoriteHotdogs.Add(hotdogService.Get(2));

            Profile p3 = new Profile()
            {
                Name = "Chris",
                AboutMe = "My Name is Chris and my favorite hot dog is my hotdog!",
                Picture = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcRcCoS1gWSUp-HRhUdSMUssRDE18BAZhUMJMr9AP9d7Hj6I1Zwk",
                ProfileID = 3,
                FavoriteHotdog = hotdogService.Get(2),
                HotdogList = myFavoriteHotdogs
            };
            profiles.Add(p3);
        }
    }
}