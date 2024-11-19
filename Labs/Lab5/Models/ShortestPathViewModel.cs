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
                try
                {
                    var rows = DistanceMatrixInput
                        .Split("\r\n", StringSplitOptions.RemoveEmptyEntries)
                        .Select(row => row.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray())
                        .ToArray();

                    if (rows.Length != GraphSize || rows.Any(row => row.Length != GraphSize))
                    {
                        throw new Exception("Невідповідність розмірів матриці.");
                    }

                    var matrix = new int[GraphSize, GraphSize];
                    for (int i = 0; i < GraphSize; i++)
                        for (int j = 0; j < GraphSize; j++)
                            matrix[i, j] = rows[i][j];

                    return matrix;
                }
                catch
                {
                    return null;
                }
            }
        }

        public int? MaxShortestPath { get; set; }
    }
}
