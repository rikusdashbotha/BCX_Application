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
using BCX_Application.Helpers;

namespace BCX_Application.Controllers
{
    public class RolesController : Controller
    {

        private readonly ILogger<RolesController> _logger;
        private readonly IConfiguration _config;
        private readonly string _apiBaseUrl;

        public RolesController(ILogger<RolesController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _config = configuration;

            _apiBaseUrl = _config.GetValue<string>("RolesAPI");
        }

        public async Task<IActionResult> CreateNew()
        {
            try
            {
                RoleDto dto = new RoleDto();
                //ViewBag.Roles = _viewbagConvert.ConvertToSelectList(await Helper.GetRolesAPICall(_config.GetValue<string>("RolesAPI")));
                return View(dto);

            }
            catch (Exception Ex)
            { throw; }
        }

        [HttpPost]
        public async Task<IActionResult> CreateNew(RoleDto data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                        string endpoint = _apiBaseUrl;

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
        public async Task<IActionResult> Index()
        {
            RoleCollection list = new RoleCollection();
            using (HttpClient client = new HttpClient())
            {
                //StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                string endpoint = _apiBaseUrl;// + "/GetList";

                using (var Response = await client.GetAsync(endpoint/*, content*/))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await Response.Content.ReadAsStringAsync();
                        list.Roles = JsonConvert.DeserializeObject<List<RoleDto>>(apiResponse);
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
            RoleDto dto = new RoleDto();
            using (HttpClient client = new HttpClient())
            {
                //StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                string endpoint = _apiBaseUrl + $"/{Id}";

                using (var Response = await client.GetAsync(endpoint/*, content*/))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await Response.Content.ReadAsStringAsync();
                        dto = JsonConvert.DeserializeObject<RoleDto>(apiResponse);
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
        public async Task<IActionResult> Edit(int Id, RoleDto data)
        {
            RoleDto dto = new RoleDto();
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

        //[HttpGet]
        //public async Task<JsonResult> GetRoleByEmployeeId(int Id)
        //{
        //    //Get role by employee Id
        //    var role = await Helper.GetRoleByEmployeeIdAPICall(_apiBaseUrl, Id);
        //    if (role != null)
        //    {
        //        //Have role
        //        var jsonString = Json(role);
        //        return jsonString;
        //    }
        //    return null;
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
