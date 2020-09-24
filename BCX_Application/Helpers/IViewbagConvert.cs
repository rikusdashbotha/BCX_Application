using BCX_CORE.DTOs.Employees;
using BCX_CORE.Objects.Roles;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCX_Application.Helpers
{
    public interface IViewbagConvert
    {
        List<SelectListItem> ConvertToSelectList(List<RoleDto> InputList);
        List<SelectListItem> ConvertToSelectList(List<RoleDto> InputList, int SelectedId);

        List<SelectListItem> ConvertToSelectList(List<EmployeeDto> InputList);
        List<SelectListItem> ConvertToSelectList(List<EmployeeDto> InputList, int SelectedId);
    }
}
