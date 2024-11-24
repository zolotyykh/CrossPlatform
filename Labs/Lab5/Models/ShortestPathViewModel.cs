using System.ComponentModel.DataAnnotations;

namespace Lab5.Models
{
    public class ShortestPathViewModel
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Розмір графу повинен бути більше 0.")]
        [Display(Name = "Розмір графу (N)")]
        public int GraphSize { get; set; }

        [Required]
        [Display(Name = "Матриця відстаней (рядки через новий рядок, числа через пробіл)")]
        public string DistanceMatrixInput { get; set; }

        public int[,] DistanceMatrix
        {
            get
            {
                if (string.IsNullOrWhiteSpace(DistanceMatrixInput))
                {
                    throw new Exception("Матриця відстаней не може бути порожньою.");
                }

                var rows = DistanceMatrixInput
                    .Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(row => row.Split(new[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray())
                    .ToArray();

                if (rows.Length != GraphSize || rows.Any(row => row.Length != GraphSize))
                {
                    throw new Exception($"Матриця повинна бути розміром {GraphSize}x{GraphSize}.");
                }

                var matrix = new int[GraphSize, GraphSize];
                for (int i = 0; i < GraphSize; i++)
                {
                    for (int j = 0; j < GraphSize; j++)
                    {
                        matrix[i, j] = rows[i][j];
                    }
                }

                return matrix;
            }
        }

        public int? MaxShortestPath { get; set; }
    }
}
