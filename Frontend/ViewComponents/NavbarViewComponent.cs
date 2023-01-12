using Microsoft.AspNetCore.Mvc;

namespace Frontend.ViewComponents;
public class NavbarViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
