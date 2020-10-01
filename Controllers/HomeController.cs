using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using EmpireForm.Models;


namespace EmpireForm.Controllers
{

    //Controller for the home page
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        //POST registrants through API
        [HttpPost]
        public ActionResult Index(RegistrantViewModel registrant)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://hartempire.azurewebsites.net/api/registration");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<RegistrantViewModel>("registration", registrant);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(registrant);
        }
    }
}