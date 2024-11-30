using Microsoft.AspNetCore.Mvc;
using PcStore.Models;

namespace PcStore.Web.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HandleErrorCode(int statusCode)
        {
            var errorViewModel = new ErrorViewModel
            {
                StatusCode = statusCode,
                Message = statusCode switch
                {
                    404 => "The page you are looking for could not be found.",
                    500 => "An unexpected server error occurred.",
                    _ => "An unexpected error occurred."
                },
                Details = statusCode == 500 ? "Please contact support if the issue persists." : null
            };

            return View("Error", errorViewModel);
        }
    }
}
