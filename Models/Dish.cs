using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Chef_And_Dishes.Models
{
    public class Dish
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public int Tastiness { get; set; }
        public string Description { get; set; }
        public int ChefId { get; set; }
        public Chef Creator { get; set; }

    }
}