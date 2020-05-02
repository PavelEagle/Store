using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers
{
    public interface IHomeController
    {
        IActionResult Error();
        IActionResult Index();
        IActionResult Privacy();
    }
}