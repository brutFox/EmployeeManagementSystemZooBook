using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementZooBookApi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger/index.html");
        }
    }
}
