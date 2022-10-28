using EmpApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;

namespace EmpApp.Controllers
{
    public class HomeController : Controller
    {

        public async Task<IActionResult> EmployeeView()
        {
            HttpClientHandler clienthandler = new HttpClientHandler();
            clienthandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslpolicyerrors) => { return true; };

            HttpClient client = new HttpClient(clienthandler);
            client.BaseAddress = new Uri("https://localhost:7170");
            List<EmployeeModelMVC>? emplist = new List<EmployeeModelMVC>();

            HttpResponseMessage res = client.GetAsync("api/Employee/Get").Result;
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                emplist = JsonConvert.DeserializeObject<List<EmployeeModelMVC>>(result);
            }
            return View(emplist);

        }
        public async Task<ActionResult> Post()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7170");
            List<DesignationMVC>? designationTemp = new List<DesignationMVC>();

            HttpResponseMessage res = await client.GetAsync("api/Designation");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                designationTemp = JsonConvert.DeserializeObject<List<DesignationMVC>>(result);
                ViewData["designationtemp"] = designationTemp;
            }
            return View();
        }


        [HttpPost]
        public IActionResult Post(EmployeeModelMVC empreg)
        {

            HttpClientHandler clienthandler = new HttpClientHandler();
            clienthandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslpolicyerrors) => { return true; };


            HttpClient client = new HttpClient(clienthandler);
            client.BaseAddress = new Uri("https://localhost:7170");
            var postTask = client.PostAsJsonAsync<EmployeeModelMVC>("api/Employee/Post/", empreg);
            postTask.Wait();
            var Result = postTask.Result;
            if (Result.IsSuccessStatusCode)
            {
                return RedirectToAction("EmployeeView");
            }
            return View();
        }

        public async Task<IActionResult> Delete(string UserName)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7170");
            await client.DeleteAsync($"api/Employee/Delete/{UserName}");
            return RedirectToAction("EmployeeView");

        }
        //public async Task<IActionResult> Edit(string username)
        //{

        //    var client = new HttpClient();
        //    client.BaseAddress = new Uri("https://localhost:7170");
        //    TempData temp = new TempData();
        //    HttpResponseMessage res = await client.GetAsync($"api/Employee/Get/{username}");//Api layr
        //    if (res.IsSuccessStatusCode)
        //    {
        //        var result = res.Content.ReadAsStringAsync().Result;


        //        temp = JsonConvert.DeserializeObject<TempData>(result);
        //    }


        //    return View(temp);
        //}
        [HttpPost]
        public async Task<IActionResult> Edit(TempData temp)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7170");
            var postTask = client.PostAsJsonAsync<TempData>("api/Employee/Edit", temp);
            postTask.Wait();
            var Result = postTask.Result;
            if (Result.IsSuccessStatusCode)
            {
                return RedirectToAction("EmployeeView");
            }
            return View();
        }


        public async Task<IActionResult> Edit(string username)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7170");
            List<DesignationMVC>? designationTemp = new List<DesignationMVC>();

            HttpResponseMessage des = await client.GetAsync("api/Designation");

            if (des.IsSuccessStatusCode)
            {
                var result = des.Content.ReadAsStringAsync().Result;
                designationTemp = JsonConvert.DeserializeObject<List<DesignationMVC>>(result);
                ViewData["designationtemp"] = designationTemp;
            }

            TempData employee = new TempData();
            HttpResponseMessage res = await client.GetAsync($"api/Employee/Get/{username}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                employee = JsonConvert.DeserializeObject<TempData>(result);
            }


            return View(employee);
        }

        public ActionResult designation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> designation(DesignationMVC designationClass)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7170");
            var postTask = client.PostAsJsonAsync<DesignationMVC>("api/Designation/designation", designationClass);

            /*  var postTask = client.PostAsJsonAsync<DesignationClass>("api/Designation/Designation", designationClass)*/
            postTask.Wait();
            var Result = postTask.Result;
            if (Result.IsSuccessStatusCode)
            {
                return RedirectToAction("DashBoard","AdminMVC");
            }
            return View();
        }
        


    }
}

