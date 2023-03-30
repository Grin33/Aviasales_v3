using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace Aviasales_v3.Models
{
    public class Flight
    {
        [Display(Name = "Откуда")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        public string Where_From { get; set; }
        [Display(Name = "Куда")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        public string Where_To { get; set; }
        [Display(Name = "Когда")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [DataType(DataType.Date)]
        public DateTime When { get; set; }


        [Display(Name = "Свободные места")]
        public int Free_Seats { get; set; }

        public int Id { get; set; }
    }
}
