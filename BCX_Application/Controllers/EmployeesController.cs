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

namespace BCX_Application.Controllers
{
    public class EmployeesController : Controller
    {

        private readonly ILogger<EmployeesController> _logger;
        private readonly IConfiguration _config;
        private readonly IViewbagConvert _viewbagConvert;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly string _apiBaseUrl;

        public EmployeesController(ILogger<EmployeesController> logger, IConfiguration configuration, IViewbagConvert viewbagConvert,
            IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            _config = configuration;
            _viewbagConvert = viewbagConvert;
            _hostEnvironment = hostEnvironment;

            _apiBaseUrl = _config.GetValue<string>("EmployeesAPI");
        }

        public async Task<IActionResult> CreateNew()
        {
            try
            {
                EmployeeDto dto = new EmployeeDto();
                ViewBag.Roles = _viewbagConvert.ConvertToSelectList(await Helper.GetRolesAPICall(_config.GetValue<string>("RolesAPI")));
                return View(dto);

            }
            catch (Exception Ex)
            { throw; }
        }

        private async Task<string> FileUpload(EmployeeDto data)
        {
            try
            {
                if (data.ImageFile != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(data.ImageFile.FileName);
                    string extension = Path.GetExtension(data.ImageFile.FileName);
                    var name = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/Images/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await data.ImageFile.CopyToAsync(fileStream);
                        data.ImageFile = null;
                    }
                    return name;
                }
                else return null;
            }
            catch (Exception Ex)
            { throw; }
        
        }

        [HttpPost]
        public async Task<IActionResult> CreateNew(EmployeeDto data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (HttpClient client = new HttpClient())
                    {

                        //string wwwRootPath = _hostEnvironment.WebRootPath;
                        //string fileName = Path.GetFileNameWithoutExtension(data.ImageFile.FileName);
                        //string extension = Path.GetExtension(data.ImageFile.FileName);
                        //var name = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        //string path = Path.Combine(wwwRootPath + "/Images/", fileName);
                        //using (var fileStream = new FileStream(path, FileMode.Create))
                        //{
                        //    await data.ImageFile.CopyToAsync(fileStream);
                        //    data.ImageFile = null;
                        //}

                        data.ImagePath = await FileUpload(data);

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
            EmployeeCollection list = new EmployeeCollection();
            using (HttpClient client = new HttpClient())
            {
                //StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                string endpoint = _apiBaseUrl;// + "/GetList";

                using (var Response = await client.GetAsync(endpoint/*, content*/))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await Response.Content.ReadAsStringAsync();
                        list.Employees = JsonConvert.DeserializeObject<List<EmployeeDto>>(apiResponse);
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
            EmployeeDto dto = new EmployeeDto();
            using (HttpClient client = new HttpClient())
            {
                //StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                string endpoint = _apiBaseUrl + $"/{Id}";

                using (var Response = await client.GetAsync(endpoint/*, content*/))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await Response.Content.ReadAsStringAsync();
                        dto = JsonConvert.DeserializeObject<EmployeeDto>(apiResponse);

                        ViewBag.Roles = _viewbagConvert.ConvertToSelectList(await Helper.GetRolesAPICall(_config.GetValue<string>("RolesAPI")), dto.RoleId);

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
        public async Task<IActionResult> Edit(int Id, EmployeeDto data)
        {
            EmployeeDto dto = new EmployeeDto();
            using (HttpClient client = new HttpClient())
            {

                data.ImagePath = await FileUpload(data);

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
