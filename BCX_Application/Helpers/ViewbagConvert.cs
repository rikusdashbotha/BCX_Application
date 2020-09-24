using BCX_CORE.DTOs.Employees;
using BCX_CORE.DTOs.Tasks;
using BCX_CORE.Objects.Roles;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCX_Application.Helpers
{
    public class ViewbagConvert : IViewbagConvert
    {
        public ViewbagConvert()
        {

        }

        public List<SelectListItem> ConvertToSelectList(List<RoleDto> InputList)
        {
            var convertedList = new List<SelectListItem>();
            try
            {
                foreach (var item in InputList)
                {
                    convertedList.Add(new SelectListItem()
                    { 
                        Value = item.Id.ToString(),
                        Text = item.Name
                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
            return convertedList;
        }

        public List<SelectListItem> ConvertToSelectList(List<RoleDto> InputList, int SelectedId)
        {
            var convertedList = new List<SelectListItem>();
            try
            {
                foreach (var item in InputList)
                {
                    convertedList.Add(new SelectListItem()
                    {
                        Value = item.Id.ToString(),
                        Text = item.Name,
                        Selected = (SelectedId == item.Id)
                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
            return convertedList;
        }


        public List<SelectListItem> ConvertToSelectList(List<EmployeeDto> InputList)
        {
            var convertedList = new List<SelectListItem>();
            try
            {
                foreach (var item in InputList)
                {
                    convertedList.Add(new SelectListItem()
                    {
                        Value = item.Id.ToString(),
                        Text = $"{item.FirstName}, {item.LastName}"
                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
            return convertedList;
        }

        public List<SelectListItem> ConvertToSelectList(List<EmployeeDto> InputList, int SelectedId)
        {
            var convertedList = new List<SelectListItem>();
            try
            {
                foreach (var item in InputList)
                {
                    convertedList.Add(new SelectListItem()
                    {
                        Value = item.Id.ToString(),
                        Text = $"{item.FirstName}, {item.LastName}",
                        Selected = (SelectedId == item.Id)
                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
            return convertedList;
        }

        public List<SelectListItem> ConvertToSelectList(List<TaskDto> InputList)
        {
            var convertedList = new List<SelectListItem>();
            try
            {
                foreach (var item in InputList)
                {
                    convertedList.Add(new SelectListItem()
                    {
                        Value = item.Id.ToString(),
                        Text = item.Name
                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
            return convertedList;
        }
    }
}
