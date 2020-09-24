using BCX_CORE.DTOs.Employees;
using BCX_CORE.DTOs.EmployeeTasks;
using BCX_CORE.DTOs.Tasks;
using BCX_CORE.Objects.Roles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BCX_Application.Helpers
{
    public static class Helper
    {

        public static  async Task<List<RoleDto>> GetRolesAPICall(string BaseUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = BaseUrl;// + $"/{Id}";

                using (var Response = await client.GetAsync(endpoint/*, content*/))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await Response.Content.ReadAsStringAsync();

                        return JsonConvert.DeserializeObject<List<RoleDto>>(apiResponse);
                    }
                    else
                    {
                        return null;
                    }

                }
            }
        }

        public static async Task<EmployeeTaskCollection> GetEmployeeTasksByTaskIdAPICall(string BaseUrl, int Id)
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = BaseUrl + $"/EmployeeTasksByTaskId?Id={Id}";

                using (var Response = await client.GetAsync(endpoint/*, content*/))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await Response.Content.ReadAsStringAsync();

                        return JsonConvert.DeserializeObject<EmployeeTaskCollection>(apiResponse);
                    }
                    else
                    {
                        return null;
                    }

                }
            }
        }

        public static async Task<TaskCollection> GetTasksByEmployeeIdAPICall(string BaseUrl, int Id)
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = BaseUrl + $"/TasksByEmployeeId?Id={Id}";

                using (var Response = await client.GetAsync(endpoint/*, content*/))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await Response.Content.ReadAsStringAsync();

                        return JsonConvert.DeserializeObject<TaskCollection>(apiResponse);
                    }
                    else
                    {
                        return null;
                    }

                }
            }
        }

        public static async Task<List<EmployeeDto>> GetEmployeesAPICall(string BaseUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = BaseUrl;// + $"/{Id}";

                using (var Response = await client.GetAsync(endpoint/*, content*/))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await Response.Content.ReadAsStringAsync();

                        return JsonConvert.DeserializeObject<List<EmployeeDto>>(apiResponse);
                    }
                    else
                    {
                        return null;
                    }

                }
            }
        }

        public static async Task<EmployeeDto> GetEmployeeIdAPICall(string BaseUrl, int Id)
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = BaseUrl + $"/{Id}";

                using (var Response = await client.GetAsync(endpoint/*, content*/))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await Response.Content.ReadAsStringAsync();

                        return JsonConvert.DeserializeObject<EmployeeDto>(apiResponse);
                    }
                    else
                    {
                        return null;
                    }

                }
            }
        }

    }
}
