using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpireForm.Models
{
    public class RegistrantViewModel
    {
        [Required] public string Fname { get; set; }
        [Required] public string Lname { get; set; }

    }
}
