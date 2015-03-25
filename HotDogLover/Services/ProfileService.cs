using HotDogLover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotDogLover.Services
{
    public class ProfileService
    {
        private static List<Profile> profiles;
        private static HotDogService hotDogService;
        static ProfileService() {
            reload();
        }

       
        public List<Profile> ListAll() {
            return profiles;
        }
        public Profile Get(int id) {
            Profile foundProfile = new Profile();
            foreach (Profile profile in profiles) {
                if (profile.ProfileID == id) {
                    foundProfile = profile;
                }
            }
            return foundProfile;
        }
        public void Add(Profile profile) {
            if (profile == null)
            {
                return;
            }

            profiles.Add(profile);
        }

        public void AddDog(Profile profile, HotDog dog) {
            Profile p = Get(profile.ProfileID);
            p.HotDogList.Add(dog);
            
        }
        public void Remove(Profile profile)
        {
            //trap for null objects
            if (profile == null)
            {
                return;
            }

            //find the profile to whack
            Profile profileToRemove = null;
            foreach (Profile p in profiles) {
                if (p.ProfileID == profile.ProfileID) {
                    profileToRemove = p;
                }
            }
            //whack profile
            if (profileToRemove != null) {
                profiles.Remove(profileToRemove);
            }
        }
        public void Update(Profile profile) {
            Profile profileToUpdate = Get(profile.ProfileID);
          
            profileToUpdate.Name = profile.Name;
            profileToUpdate.Picture = profile.Picture;
            profileToUpdate.Bio = profile.Bio;

            Remove(profile);
            Add(profileToUpdate);
        }
        public static void reload()
        {
            hotDogService = new HotDogService();
            profiles = new List<Profile>();

            List<HotDog> myFavs = new List<HotDog>();
            myFavs.Add(hotDogService.Get(1));
            myFavs.Add(hotDogService.Get(2));
            myFavs.Add(hotDogService.Get(3));

            Profile p1 = new Profile()
            {
                Name = "Alex",
                Bio = "My Name is Alex and my favorite hot dog is my hotdog!",
                Picture = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcTUimzq6P3hPYTbxKiPvfoDr1NcouiFjmn5xEEgKbYyXhr4-rZa",
                ProfileID = 1,
                FavoriteHotDog = hotDogService.Get(1),
                HotDogList = myFavs
            };
            profiles.Add(p1);

            myFavs = new List<HotDog>();
            myFavs.Add(hotDogService.Get(1));
            myFavs.Add(hotDogService.Get(3));

            Profile p2 = new Profile()
            {
                Name = "Bryan",
                Bio = "My Name is Bryan and my favorite hot dog is my hotdog!",
                Picture = "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcRMTfL6jkJW42L3_wOsv2j_VtdddNTkj2mILErKqFkXGgQzAM82Lg",
                ProfileID = 2,
                FavoriteHotDog = hotDogService.Get(3),
                HotDogList = myFavs
            };
            profiles.Add(p2);

            myFavs = new List<HotDog>();
            myFavs.Add(hotDogService.Get(2));

            Profile p3 = new Profile()
            {
                Name = "Chris",
                Bio = "My Name is Chris and my favorite hot dog is my hotdog!",
                Picture = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcRcCoS1gWSUp-HRhUdSMUssRDE18BAZhUMJMr9AP9d7Hj6I1Zwk",
                ProfileID = 3,
                FavoriteHotDog = hotDogService.Get(2),
                HotDogList = myFavs
            };
            profiles.Add(p3);
        }
    }
}