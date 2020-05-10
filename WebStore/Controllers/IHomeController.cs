using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers
{
    public interface IHomeController
    {
        IActionResult Error();
        IActionResult ReportController();
        IActionResult ProductController();
    }
}