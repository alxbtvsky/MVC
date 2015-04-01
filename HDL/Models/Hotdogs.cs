using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace HDL.Models
{
    public class Hotdogs
    {
        public int HotdogsID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [DisplayName("Hot Dog Name")]
        public string HotdogsName { get; set; }
        [DisplayName("Last Ate")]
        [Required(ErrorMessage = "When you last ate it is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LastTimeAte { get; set; }

        [DisplayName("Where did you eat it?")]
        [Required(ErrorMessage = "Where you ate it is required")]
        public string LastPlaceAte { get; set; }
        [Range(1, 5,
            ErrorMessage = "Please Pick a rating")]
        public int Rating { get; set; }

    }
}