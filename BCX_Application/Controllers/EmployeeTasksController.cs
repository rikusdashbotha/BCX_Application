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
using BCX_CORE.Objects.Tasks;
using BCX_CORE.DTOs.Tasks;
using BCX_CORE.DTOs.TaskAssigns;
using BCX_CORE.DTOs.EmployeeTasks;
using BCX_CORE.Objects.EmployeeTasks;

namespace BCX_Application.Controllers
{
    public class EmployeeTasksController : Controller
    {

        private readonly ILogger<EmployeeTasksController> _logger;
        private readonly IConfiguration _config;
        private readonly IViewbagConvert _viewbagConvert;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly string _apiBaseUrl;

        public EmployeeTasksController(ILogger<EmployeeTasksController> logger, IConfiguration configuration, IViewbagConvert viewbagConvert,
            IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            _config = configuration;
            _viewbagConvert = viewbagConvert;
            _hostEnvironment = hostEnvironment;

            _apiBaseUrl = _config.GetValue<string>("EmployeeTasksAPI");
        }

        

        [HttpGet]
        public async Task<IActionResult> DetermineRouteAction(int Id)
        {
           //Need to determine if EmployeeTasks exist for this Task Id, because that will determine whether an edit or create new method will be called instead

            EmployeeTaskDto dto = new EmployeeTaskDto();
            var employeeTaskCollection = await Helper.GetEmployeeTasksByTaskIdAPICall(_apiBaseUrl, Id);
            if (employeeTaskCollection != null)
            {
                //Get Employees to assign
                //ViewBag.Employees = _viewbagConvert.ConvertToSelectList(await Helper.GetRolesAPICall(_config.GetValue<string>("EmployeesAPI")));
                return RedirectToAction(nameof(Edit), new { Id = Id });
            }
            else
            {
                //EmployeeTask(s) does not exist for this Task Id, redirect to CreateNew
                return RedirectToAction(nameof(CreateNew), new { Id = Id });
            }
        }

        public async Task<IActionResult> CreateNew(int Id)
        {
            try
            {
                EmployeeTaskCollection dto = new EmployeeTaskCollection();
                dto.TaskId = Id;
                ViewBag.Employees = _viewbagConvert.ConvertToSelectList(await Helper.GetEmployeesAPICall(_config.GetValue<string>("EmployeesAPI")));
                return View(dto);

            }
            catch (Exception Ex)
            { throw; }
        }

        [HttpPost]
        public async Task<IActionResult> CreateNew([FromBody] EmployeeTaskCollection data)
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
                return RedirectToAction(nameof(Index));
            }
            catch (Exception Ex)
            { throw; }
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            EmployeeTaskCollection list = new EmployeeTaskCollection();
            using (HttpClient client = new HttpClient())
            {
                //StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                string endpoint = _apiBaseUrl;// + "/GetList";

                using (var Response = await client.GetAsync(endpoint/*, content*/))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await Response.Content.ReadAsStringAsync();
                        list.EmployeeTasks = JsonConvert.DeserializeObject<List<EmployeeTaskDto>>(apiResponse);
                        return View(list);
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

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            //Coming from the Tasks index page.
            var employeeTaskCollection = await Helper.GetEmployeeTasksByTaskIdAPICall(_apiBaseUrl, Id);

            //Grab Task Id since you're going to assign to it
            employeeTaskCollection.TaskId = Id;
            ViewBag.Employees = _viewbagConvert.ConvertToSelectList(await Helper.GetEmployeesAPICall(_config.GetValue<string>("EmployeesAPI")));

            return View(employeeTaskCollection);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] EmployeeTaskCollection data)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                string endpoint = _apiBaseUrl;// + $"/{Id}";

                using (var Response = await client.PostAsync(endpoint, content))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        //string apiResponse = await Response.Content.ReadAsStringAsync();
                        //dto = JsonConvert.DeserializeObject<RoleDto>(apiResponse);
                        return RedirectToAction("Index", "Tasks");
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

        [HttpGet]
        public async Task<JsonResult> TasksByEmployeeId([FromQuery]int Id)
        {
            //Get all tasks by employee Id
            var tasks = await Helper.GetTasksByEmployeeIdAPICall(_apiBaseUrl, Id);
            if (tasks != null)
            {
                //Have tasks
                var jsonString = Json(tasks);
                return jsonString;
            }
            return null;
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
