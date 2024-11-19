using System.ComponentModel.DataAnnotations;

namespace Lab5.Models
{
    public class KadaneViewModel
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Кількість рядків повинна бути більше 0.")]
        [Display(Name = "Кількість рядків (N)")]
        public int RowCount { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Кількість стовпців повинна бути більше 0.")]
        [Display(Name = "Кількість стовпців (M)")]
        public int ColumnCount { get; set; }

        [Required]
        [Display(Name = "Матриця (рядки через новий рядок, числа через пробіл)")]
        public string MatrixInput { get; set; }

        public int[,] Matrix
        {
            get
            {
                try
                {
                    var rows = MatrixInput
                        .Split("\r\n", StringSplitOptions.RemoveEmptyEntries)
                        .Select(row => row.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray())
                        .ToArray();

                    if (rows.Length != RowCount || rows.Any(row => row.Length != ColumnCount))
                    {
                        throw new Exception("Невідповідність розмірів матриці.");
                    }

                    var matrix = new int[RowCount, ColumnCount];
                    for (int i = 0; i < RowCount; i++)
                        for (int j = 0; j < ColumnCount; j++)
                            matrix[i, j] = rows[i][j];

                    return matrix;
                }
                catch
                {
                    return null;
                }
            }
        }

        public int? MaxSum { get; set; }
    }
}
