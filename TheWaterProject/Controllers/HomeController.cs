using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TheWaterProject.Models;
using TheWaterProject.Models.ViewModels;

namespace TheWaterProject.Controllers;

public class HomeController : Controller
{
    private IWaterRepository _repo;
    public HomeController(IWaterRepository temp)
    {
        _repo = temp;
    }
    
    public IActionResult Index(int pageNum)
    {
        int pageSize = 2;

        var blah = new ProjectListViewModel
        {
            Projects = _repo.Projects
                .OrderBy(x => x.ProjectName)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

            PaginationInfo = new PaginationInfo
            {
                currentPage = pageNum,
                itemsPerPage = pageSize,
                totalItems = _repo.Projects.Count()
            }
        };
        
        return View(blah);
    }
}