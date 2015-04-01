using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HDL.Models
{
    public class Profile
    {
        public int ProfileID { get; set; }
        public string Name { get; set; }
        public string AboutMe { get; set; }
        public string Picture { get; set; }
        public Hotdogs FavoriteHotdog { get; set; }
        public List<Hotdogs> HotdogList { get; set; }
    }
}