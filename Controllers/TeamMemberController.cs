using Microsoft.AspNetCore.Mvc;
using ZeyadRagyWebExam.Data;
using ZeyadRagyWebExam.Models;

namespace ZeyadRagyWebExam.Controllers
{
    public class TeamMemberController : Controller
    {
        public TaskManagementContext connection = new TaskManagementContext();
        public IActionResult Index()
        {
            var res = connection.TeamMembers.ToList();
            return View(res);
        }
        [HttpPost]
        public IActionResult Create(TeamMember teamMember)
        {
            var res = connection.TeamMembers.Add(teamMember);
            connection.SaveChanges(); 
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id, TeamMember team)
        {
            var res = connection.TeamMembers.Where(team => team.Id == id).FirstOrDefault();
            connection.Remove(res);
            connection.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var res = connection.TeamMembers.Where(team => team.Id == id).FirstOrDefault();
            return View(res);
        }
        [HttpPost]
        public IActionResult Edit(int id, TeamMember teamMember)
        {
            var res = connection.TeamMembers.Where(team => team.Id == id).FirstOrDefault();
            res.Name = teamMember.Name;
            res.Email = teamMember.Email;
            res.Role = teamMember.Role;
            connection.SaveChanges();
            return RedirectToAction("Index");
        }

                [HttpPost]

        public IActionResult View(int id) {
            var res = connection.Jobs.Where(jo => jo.TeamMemberId == id).ToList();
            return View(res);
        }
    }
}
