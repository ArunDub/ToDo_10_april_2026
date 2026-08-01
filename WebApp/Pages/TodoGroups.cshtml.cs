using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebApp.ServiceInterfaces;

namespace WebApp.Pages
{
    public class TodoGroupsModel : PageModel
    {
        
        private readonly IDataService _dataService;
        public TodoGroupsModel(IDataService dataService)
        {
            _dataService = dataService;
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
                   
                }
                else
                {
                    message = $"Title:{response.Title}<br/>Message:{response.Message}";
                    //Toaster.AddErrorToastMessage(message);
                  
                }

            }
            else
            {
                message = "Could not get response from API";
                //Toaster.AddInfoToastermessage(message);
               
            }
            return Page();
        }
    }
}
