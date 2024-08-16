using Microsoft.AspNetCore.Mvc;
using task_day5.Controllers;

namespace MVCCoreDay5.ViewComponents
{
    public class GetCompComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(CompanyController.companies);
        }
    }
}
