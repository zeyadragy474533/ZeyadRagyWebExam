using Microsoft.AspNetCore.Mvc;
using ZeyadRagyWebExam.Data;
using ZeyadRagyWebExam.Models;

namespace ZeyadRagyWebExam.Controllers
{
    public class JobController : Controller
    {
        public TaskManagementContext connection = new TaskManagementContext();
        public IActionResult Index()
        {
            var res = connection.Jobs.ToList();
            return View(res);
        }
        [HttpPost]
        public IActionResult Create(Job job)
        {
            var res = connection.Jobs.Add(job);
            connection.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Delete(int id, Job job)
        {
            var res = connection.Jobs.Where(jo => jo.Id == id).FirstOrDefault();
            connection.Remove(res);
            connection.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var res = connection.Jobs.Where(jo => jo.Id == id).FirstOrDefault();
            return View(res);
        }
        [HttpPost]
        public IActionResult Edit(int id, Job job)
        {
            var res = connection.Jobs.Where(jo => jo.Id == id).FirstOrDefault();
            res.Status = job.Status;
            connection.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
