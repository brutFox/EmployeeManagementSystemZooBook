using EmployeeManagementZooBookFronEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using EmployeeManagementZooBookFronEnd.Helper;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;

namespace EmployeeManagementZooBookFronEnd.Controllers
{
    public class HomeController : Controller
    {
        private zooBookApi _api = new zooBookApi();
        HttpClient client;
        public HomeController()
        {
            client = _api.Initial();
        }

        public async Task<IActionResult> Index()
        {
            List<EmployeeVM> employees = null;

            HttpResponseMessage responseMessage = await client.GetAsync("api/Employee/GetEmployees");

            if (responseMessage.IsSuccessStatusCode)
            {
                var result = responseMessage.Content.ReadAsStringAsync().Result;
                employees = JsonConvert.DeserializeObject<List<EmployeeVM>>(result);
            }
            
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeVM employeeVM)
        {
            if (ModelState.IsValid)
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, "/api/Employee/CreateEmployee");
                requestMessage.Headers.Add("Accept-Encoding", "gzip,deflate");
                var content = new StringContent(JsonConvert.SerializeObject(employeeVM), Encoding.UTF8, "application/json");
                requestMessage.Content = content;
                var response = await client.SendAsync(requestMessage);
                if (!response.IsSuccessStatusCode)
                {
                    ModelState.AddModelError("SavingError", "Something went wrong, please try again later.");
                    return View("Create", employeeVM);
                }
            }
            else
            {
                return View("Create", employeeVM);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync($"api/Employee/DeleteEmployee?id={id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            EmployeeVM employee = null;

            HttpResponseMessage responseMessage = await client.GetAsync($"api/Employee/GetEmployeeById?id={id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var result = responseMessage.Content.ReadAsStringAsync().Result;
                employee = JsonConvert.DeserializeObject<EmployeeVM>(result);
            }

            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeVM employeeVM)
        {
            if (ModelState.IsValid)
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, "/api/Employee/UpdateEmployee");
                requestMessage.Headers.Add("Accept-Encoding", "gzip,deflate");
                var content = new StringContent(JsonConvert.SerializeObject(employeeVM), Encoding.UTF8, "application/json");
                requestMessage.Content = content;
                var response = await client.SendAsync(requestMessage);
                if (!response.IsSuccessStatusCode)
                {
                    ModelState.AddModelError("SavingError", "Something went wrong, please try again later.");
                    return View("Edit", employeeVM);
                }
            }
            else
            {
                return View("Edit", employeeVM);
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
