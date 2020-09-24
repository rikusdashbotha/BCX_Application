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

namespace BCX_Application.Controllers
{
    public class TasksController : Controller
    {

        private readonly ILogger<TasksController> _logger;
        private readonly IConfiguration _config;
        private readonly IViewbagConvert _viewbagConvert;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly string _apiBaseUrl;

        public TasksController(ILogger<TasksController> logger, IConfiguration configuration, IViewbagConvert viewbagConvert,
            IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            _config = configuration;
            _viewbagConvert = viewbagConvert;
            _hostEnvironment = hostEnvironment;

            _apiBaseUrl = _config.GetValue<string>("TasksAPI");
        }

        public async Task<IActionResult> CreateNew()
        {
            try
            {
                TaskDto dto = new TaskDto();
                //ViewBag.Roles = _viewbagConvert.ConvertToSelectList(await Helper.GetRolesAPICall(_config.GetValue<string>("RolesAPI")));
                return View(dto);

            }
            catch (Exception Ex)
            { throw; }
        }

        [HttpPost]
        public async Task<IActionResult> CreateNew(TaskDto data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        //data.ImagePath = await FileUpload(data);

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
            TaskCollection list = new TaskCollection();
            using (HttpClient client = new HttpClient())
            {
                //StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                string endpoint = _apiBaseUrl;// + "/GetList";

                using (var Response = await client.GetAsync(endpoint/*, content*/))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await Response.Content.ReadAsStringAsync();
                        list.Tasks = JsonConvert.DeserializeObject<List<TaskDto>>(apiResponse);
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
            TaskDto dto = new TaskDto();
            using (HttpClient client = new HttpClient())
            {
                //StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                string endpoint = _apiBaseUrl + $"/{Id}";

                using (var Response = await client.GetAsync(endpoint/*, content*/))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await Response.Content.ReadAsStringAsync();
                        dto = JsonConvert.DeserializeObject<TaskDto>(apiResponse);

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
        public async Task<IActionResult> Edit(int Id, TaskDto data)
        {
            TaskDto dto = new TaskDto();
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
