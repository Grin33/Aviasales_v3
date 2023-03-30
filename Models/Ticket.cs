using System.ComponentModel.DataAnnotations;

namespace Aviasales_v3.Models
{
    public class Ticket
    {
        [Display(Name = "ID")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        public int Id { get; set; }
        [Display(Name = "Номер Билета")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        public int Ticket_Number { get; set; }
        [Display(Name = "ID Рейса")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        public int Flight_Id { get; set; }
        public Flight Flight { get; set; }
    }
}
