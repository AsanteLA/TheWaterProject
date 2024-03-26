using Microsoft.AspNetCore.Mvc;
using TheWaterProject.Models;

namespace TheWaterProject.Components;

public class ProjectTypesViewComponent : ViewComponent
{
    private IWaterRepository _repo;
    //Constructor
    public ProjectTypesViewComponent(IWaterRepository temp)
    {
        _repo = temp;
    }
    public  IViewComponentResult Invoke()
    {
        var projectTypes = _repo.Projects
            .Select(x => x.ProjectType)
            .Distinct()
            .OrderBy(x => x);
        
        return View(projectTypes);
    }
}