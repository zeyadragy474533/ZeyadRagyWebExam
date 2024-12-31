using Microsoft.AspNetCore.Mvc;
using ZeyadRagyWebExam.Data;
using ZeyadRagyWebExam.Models;

namespace ZeyadRagyWebExam.Controllers
{
    public class ProjectController : Controller
    {
        public TaskManagementContext connection = new TaskManagementContext();
        public IActionResult Index()
        {
            var res= connection.Projects.ToList();
            return View(res);
        }
        [HttpPost]
        public IActionResult Create(Project project)
        {
            var res = connection.Projects.Add(project);
            connection.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]

        public IActionResult Delete(int id,Project project)
        {
           var res = connection.Projects.Where(pro => pro.Id == id).FirstOrDefault();
           connection.Remove(res);
           connection.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
           var res = connection.Projects.Where(pro => pro.Id == id).FirstOrDefault();
           return View(res);
        }
        [HttpPost]
        public IActionResult Edit(int id ,Project project)
        {
            if (ModelState.IsValid)
            {
                var res = connection.Projects.Where(pro => pro.Id == id).FirstOrDefault();
                res.Name = project.Name;
                res.Description = project.Description;
                res.StartDate = project.StartDate;
                res.EndDate = project.EndDate;
                connection.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]

        public IActionResult View(int id) {
            var res = connection.Jobs.Where(jo => jo.ProjectId == id).ToList();
            return View(res);
        }
    }
}
