using System.ComponentModel.DataAnnotations;

namespace Lab5.Models
{
    public class KadaneViewModel
    {
        [Required(ErrorMessage = "Необхідно вказати розмір матриці N.")]
        [Range(1, 1000, ErrorMessage = "Розмір N повинен бути в діапазоні від 1 до 1000.")]
        [Display(Name = "Розмір N")]
        public int N { get; set; }

        [Required(ErrorMessage = "Необхідно вказати розмір матриці M.")]
        [Range(1, 1000, ErrorMessage = "Розмір M повинен бути в діапазоні від 1 до 1000.")]
        [Display(Name = "Розмір M")]
        public int M { get; set; }

        [Required(ErrorMessage = "Необхідно вказати матрицю.")]
        [Display(Name = "Матриця")]
        public int[,] Matrix { get; set; }

        [Display(Name = "Результат")]
        public int? Result { get; set; }
    }
}
