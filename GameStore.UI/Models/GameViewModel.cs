using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameStore.UI.Models
{
    public class GameViewModel
    {
        public int Id { get; set; }
        public int? Year { get; set; }

        [Required(ErrorMessage = "Назва не може бути порожньою")]
        [StringLength(50, ErrorMessage = "Максимальна к-сть символів 50")]
        public string Name { get; set; }
        public double? Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Genre { get; set; }
        public string Developer { get; set; }
    }
}