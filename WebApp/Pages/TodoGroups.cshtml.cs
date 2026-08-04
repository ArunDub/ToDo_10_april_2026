using Application.Dtos;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using NToastNotify;
using WebApp.ServiceInterfaces;

namespace WebApp.Pages
{
    public class TodoGroupsModel : PageModel
    {
        
        private readonly IDataService _dataService;
        private readonly IToastNotification _toastr;
        
        public TodoGroupsModel(IDataService dataService, IToastNotification toastr)
        {
            _dataService = dataService;
            _toastr = toastr;
        }
        public List<TodoGroupVm> modelVm { get; set; }
        public async Task<IActionResult> OnGet() 
        {
            var response = await _dataService.TodoGroup.Get();
            var message = "Could not get response from API";
            if(response!=null)
            {
                if(response.StatusCode==200)
                {
                    modelVm = response.Data != null ? JsonConvert.DeserializeObject<List<TodoGroupVm>>(response.Data.ToString()) : null;
                    message = $"Message{response.Message}<br/>Description:{response.Description}";
                    _toastr.AddSuccessToastMessage(message);
                }
                else
                {
                    message = $"Title:{response.Title}<br/>Message:{response.Message}";
                    _toastr.AddErrorToastMessage(message);

                }

            }
            else
            {
                message = "Could not get response from API";
                _toastr.AddInfoToastMessage(message);

            }
            return Page();
        }

        public async Task<IActionResult> OnGetADD(string name)
        {
            var modelDto = new TodoGroupDto
            {
                GroupName = name,
                CreatedOn=DateTime.Now,
                
            };
            var response = await _dataService.TodoGroup.Create(modelDto);
            var message = "Could not get response from API";
            if (response != null)
            {
                if (response.StatusCode == 200)
                {
                   var  createdDto = response.Data != null ? JsonConvert.DeserializeObject<TodoGroupDto> (response.Data.ToString()) : null;
                    message = $"Message{response.Message}<br/>Description:{response.Description}";
                }
                else
                message = $"Title:{response.Title}<br/>Message:{response.Message}";
            }
            return new JsonResult(message);
        }
    }
}
