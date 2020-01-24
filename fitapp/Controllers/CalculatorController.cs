using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fitapp.ViewModels;

namespace fitapp.Controllers
{
    public class CalculatorController : Controller
    {

        // GET: Calculator
        public ActionResult IndexBmi(CalculatorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userData = model;
                if ((model.Height != 0) && (model.Weight != 0))
                {
                    userData.BMI = CalculateBmi(userData);
                }
                return View(userData);
            }

            if (!ModelState.IsValid)
            {
                TempData["ViewData"] = ViewData;
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult IndexBmr(CalculatorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userData = model;
                if ((model.Age != 0) && (model.Height != 0) && (model.Weight != 0) && (model.Gender != null))
                {
                    userData.BMR = CalculateBmr(userData);
                }
                return View(userData);
            }

            if (!ModelState.IsValid)
            {
                TempData["ViewData"] = ViewData;
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult IndexCpm(CalculatorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userData = model;
                if ((model.Age != 0) && (model.Height != 0) && (model.Weight != 0) && (model.Gender != null) && (model.PhysicalActivity != null))
                {
                    userData.CPM = CalculateCpm(userData);
                }
                return View(userData);
            }

            if (!ModelState.IsValid)
            {
                TempData["ViewData"] = ViewData;
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // BMI
        public double CalculateBmi(CalculatorViewModel userData)
        {
            return Math.Round(userData.Weight / Math.Pow((userData.Height / 100), 2), 2);
        }

        // BMR
        public double CalculateBmr(CalculatorViewModel userData)
        {
                if (userData.Gender == "Female")
                {
                    return Math.Round((665 + (9.6 * userData.Weight) + (1.8 * userData.Height) - (4.7 * userData.Age)), 2);
                }
                else
                {
                    return Math.Round((66 + (13.7 * userData.Weight) + (5 * userData.Height) - (6.76 * userData.Age)), 2);
                }
        }

        // CPM
        public double CalculateCpm(CalculatorViewModel userData)
        {

            //if (userData.PhysicalActivity == null)
            //{
            //    return 0;
            //}
            //else
            {
                string a = userData.PhysicalActivity;
                double pActivity = Convert.ToDouble(a);

                if (userData.Gender == "Female")
                {
                    return Math.Round(((665 + (9.6 * userData.Weight) + (1.8 * userData.Height) - (4.7 * userData.Age)) * pActivity), 2);
                }
                else
                {
                    return Math.Round(((66 + (13.7 * userData.Weight) + (5 * userData.Height) - (6.76 * userData.Age)) * pActivity), 2);
                }
            }
        }
    }
}