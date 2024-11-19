using Lab2;
using Lab5.Models;
using LabsLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab5.Controllers
{
    public class LabController : Controller
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
                if (model.Matrix == null || model.Matrix.GetLength(0) != model.N || model.Matrix.GetLength(1) != model.M)
                {
                    ModelState.AddModelError(string.Empty, "Матриця має бути правильної розмірності.");
                }
                else
                {
                    try
                    {
                        model.Result = KadaneUtils.FindMaxSum(model.Matrix, model.N, model.M);
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
                if (model.Distances == null || model.Distances.GetLength(0) != model.N || model.Distances.GetLength(1) != model.N)
                {
                    ModelState.AddModelError(string.Empty, "Матриця відстаней повинна бути NxN.");
                }
                else
                {
                    try
                    {
                        model.Result = Lab3.ShortestPath.FindMaxShortestPath(model.Distances, model.N);
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
