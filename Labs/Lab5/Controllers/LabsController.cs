using Lab5.Models;
using LabsLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab5.Controllers
{
    public class LabsController : Controller
    {
        [Authorize]
        public IActionResult Derangements()
        {
            return View(new DerangementsViewModel());
        }

        [Authorize]
        [HttpPost]
        public IActionResult Derangements(DerangementsViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Number < 1)
                {
                    ModelState.AddModelError(string.Empty, "Кількість гостей повинна бути більше або дорівнювати 1.");
                }
                else
                {
                    try
                    {
                        model.Result = Lab1.Derangements.CalculateDerangements(model.Number);
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(string.Empty, "Помилка при обчисленні: " + ex.Message);
                    }
                }
            }

            return View(model);
        }

        [Authorize]
        public IActionResult Kadane()
        {
            return View(new KadaneViewModel());
        }

        [Authorize]
        [HttpPost]
        public IActionResult Kadane(KadaneViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Matrix == null)
                {
                    ModelState.AddModelError(string.Empty, "Неможливо розпарсити матрицю. Перевірте введені дані.");
                }
                else
                {
                    try
                    {
                        model.MaxSum = Lab2.KadaneUtils.FindMaxSum(model.Matrix, model.RowCount, model.ColumnCount);
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(string.Empty, "Помилка при обчисленні: " + ex.Message);
                    }
                }
            }

            return View(model);
        }

        [Authorize]
        public IActionResult ShortestPath()
        {
            return View(new ShortestPathViewModel());
        }

        [Authorize]
        [HttpPost]
        public IActionResult ShortestPath(ShortestPathViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.DistanceMatrix == null)
                {
                    ModelState.AddModelError(string.Empty, "Неможливо розпарсити матрицю. Перевірте введені дані.");
                }
                else
                {
                    try
                    {
                        model.MaxShortestPath = Lab3.ShortestPath.FindMaxShortestPath(model.DistanceMatrix, model.GraphSize);
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(string.Empty, "Помилка при обчисленні: " + ex.Message);
                    }
                }
            }

            return View(model);
        }
    }
}
