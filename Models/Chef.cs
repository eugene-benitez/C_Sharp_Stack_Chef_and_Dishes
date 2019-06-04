using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Chef_And_Dishes.Models
{
    public class Chef
    {

        [Key]
        public int UserId { get; set; }
        [Required]
        [MinLength(2)]
        [Display(Name = "First Name: ")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        [Display(Name = "Last Name: ")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Date of Birth: ")]
        public DateTime DOB { get; set; }

        public int Age { get; set; }
        public List<Dish> CreatedDishes { get; set; }

    }
}