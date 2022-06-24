using FA.JustBlog.Core.Base.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BaseController : Controller
    {
        protected virtual void SetAlertInTempData(string actionName, bool state, string message = null)
        {
            TempData["State"] = state;
            string tmp = state ? "successfully" : "failed";
            if (message != null)
                tmp += ". " + message;
            TempData["Message"] = $"{actionName} {tmp}";
        }
    }
}