using EmpApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;


namespace EmpApp.Controllers
{
    public class HomeController : Controller
    {
  
        public async Task<IActionResult> EmployeeView()
        {
            var client = new HttpClient();
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
        public ActionResult Post()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Post(EmployeeModelMVC empreg)
        {
            var client = new HttpClient();
            //HttpClientHandler clientHandler = new HttpClientHandler();
            //clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            //Pass the handler to httpclient(from you are calling api)
            //HttpClient client = new HttpClient(clientHandler);
        client.BaseAddress = new Uri("https://localhost:7170");
        var postTask = client.PostAsJsonAsync<EmployeeModelMVC>("api/Employee/post", empreg);
        postTask.Wait();
            var Result = postTask.Result;
            if (Result.IsSuccessStatusCode)
            {
                return RedirectToAction("EmployeeView");
    }
            return View();
    }

    //[HttpPost]
    //public IActionResult Post(EmployeeModelMVC modelobj)
    //{
    //    var client = new HttpClient();
    //    client.BaseAddress = new Uri("https://localhost:7170");
    //    HttpResponseMessage postTask = client.PostAsJsonAsync<EmployeeModelMVC>("api/Employee/post", modelobj).Result;
    //    //postTask.Wait();

    //    if (!postTask.IsSuccessStatusCode)
    //    {
    //        return RedirectToAction("EmployeeView");
    //    }
    //    return View();
    //}

    public async Task<IActionResult> Delete(string UserName)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7170");
            await client.DeleteAsync($"api/Employee/Delete/{UserName}");
            return RedirectToAction("EmployeeView");

        }

        

    }
}