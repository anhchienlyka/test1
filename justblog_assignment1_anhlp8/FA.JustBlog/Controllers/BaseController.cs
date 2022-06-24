using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Controllers
{
    public class BaseController : Controller
    {
        protected virtual void SetAlertInTempData(string actionName, bool state)
        {
            TempData["State"] = state;
            string tmp = state ? "successfully" : "failed";
            TempData["Message"] = $"{actionName} {tmp}";
        }
    }
}