using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Model
{
    public class ProfileDetailsViewModel
    {
        [Display(Name = "UserPhoto")]
        public  byte[] UserPhoto { get; set; }

    }
}
