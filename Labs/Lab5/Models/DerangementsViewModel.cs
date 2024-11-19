using System.ComponentModel.DataAnnotations;

namespace Lab5.Models
{
    public class DerangementsViewModel
    {
        [Required(ErrorMessage = "Необхідно вказати кількість гостей.")]
        [Range(1, int.MaxValue, ErrorMessage = "Кількість гостей повинна бути більше або дорівнювати 1.")]
        [Display(Name = "Кількість гостей")]
        public int Number { get; set; }

        [Display(Name = "Результат")]
        public long? Result { get; set; }
    }
}
