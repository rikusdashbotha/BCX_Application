using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BCX_Application.Models;
using Microsoft.Extensions.Configuration;
using BCX_CORE.Objects.Roles;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using BCX_CORE.DTOs.Employees;
using BCX_Application.Helpers;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using BCX_CORE.DTOs.Hours;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BCX_Application.Controllers
{
    public class HoursController : Controller
    {

        private readonly ILogger<HoursController> _logger;
        private readonly IConfiguration _config;
        private readonly IViewbagConvert _viewbagConvert;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly string _apiBaseUrl;

        public HoursController(ILogger<HoursController> logger, IConfiguration configuration, IViewbagConvert viewbagConvert,
            IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            _config = configuration;
            _viewbagConvert = viewbagConvert;
            _hostEnvironment = hostEnvironment;

            _apiBaseUrl = _config.GetValue<string>("HoursAPI");
        }

        public async Task<IActionResult> CreateNew()
        {
            try
            {
                HourDto dto = new HourDto();
                var employees = new List<SelectListItem>();
                employees.Add(new SelectListItem()
                { Text = "Select Employee", Selected = true, Value = "-1" });

                employees.AddRange(_viewbagConvert.ConvertToSelectList(await Helper.GetEmployeesAPICall(_config.GetValue<string>("EmployeesAPI"))));
                
                ViewBag.Employees = employees;
                return View(dto);

            }
            catch (Exception Ex)
            { throw; }
        }

        [HttpPost]
        public async Task<IActionResult> CreateNew([FromBody] HourDto data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                        string endpoint = _apiBaseUrl;// + $"/{Id}";

                        using (var Response = await client.PutAsync(endpoint, content))
                        {
                            if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                return RedirectToAction("Index");
                            }
                            else
                            {
                                ModelState.Clear();
                                ModelState.AddModelError(string.Empty, "Looks like an error on our side. Sorry!");
                                return View();

                            }
                        }
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception Ex)
            { throw; }
        }

        [HttpGet]
        public async Task<IActionResult> Index(int Id)
        {
            HourDto dto = new HourDto();
            using (HttpClient client = new HttpClient())
            {
                string endpoint = _apiBaseUrl + $"/{Id}";

                using (var Response = await client.GetAsync(endpoint/*, content*/))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await Response.Content.ReadAsStringAsync();
                        dto = JsonConvert.DeserializeObject<HourDto>(apiResponse);

                        var employees = new List<SelectListItem>();
                        employees.Add(new SelectListItem()
                        { Text = "Select Employee", Selected = true, Value = "-1" });

                        employees.AddRange(_viewbagConvert.ConvertToSelectList(await Helper.GetEmployeesAPICall(_config.GetValue<string>("EmployeesAPI"))));

                        ViewBag.Employees = employees;

                        return View(dto);
                    }
                    else
                    {
                        var employees = new List<SelectListItem>();
                        employees.Add(new SelectListItem()
                        { Text = "Select Employee", Selected = true, Value = "-1" });

                        employees.AddRange(_viewbagConvert.ConvertToSelectList(await Helper.GetEmployeesAPICall(_config.GetValue<string>("EmployeesAPI"))));

                        ViewBag.Employees = employees;

                        return View();

                    }

                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            HourDto dto = new HourDto();
            using (HttpClient client = new HttpClient())
            {
                //StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                string endpoint = _apiBaseUrl + $"/{Id}";

                using (var Response = await client.GetAsync(endpoint/*, content*/))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await Response.Content.ReadAsStringAsync();
                        dto = JsonConvert.DeserializeObject<HourDto>(apiResponse);

                        //ViewBag.Roles = _viewbagConvert.ConvertToSelectList(await Helper.GetRolesAPICall(_config.GetValue<string>("RolesAPI")), dto.RoleId);

                        return View(dto);
                    }
                    else
                    {
                        ModelState.Clear();
                        ModelState.AddModelError(string.Empty, "Looks like an error on our side. Sorry!");
                        return View();

                    }

                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id, HourDto data)
        {
            HourDto dto = new HourDto();
            using (HttpClient client = new HttpClient())
            {

                StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                string endpoint = _apiBaseUrl + $"/{Id}";

                using (var Response = await client.PostAsync(endpoint, content))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        //string apiResponse = await Response.Content.ReadAsStringAsync();
                        //dto = JsonConvert.DeserializeObject<RoleDto>(apiResponse);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.Clear();
                        ModelState.AddModelError(string.Empty, "Looks like an error on our side. Sorry!");
                        return View();

                    }

                }
            }
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
