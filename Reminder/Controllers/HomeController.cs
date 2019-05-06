using System;
using Reminder.Models.Interfaces;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Reminder.Models;
using Reminder.Models.DataModels;
using Reminder.ViewModels;

namespace Reminder.Controllers
{
    public class HomeController : Controller
    {
        private readonly IReminderRepository _reminderRepository;
        private readonly IUserReminderRelationsRepository _userReminderRelationsRepository;

        public HomeController()
        {
            _reminderRepository = new ReminderRepository(new ReminderDbContext());
            _userReminderRelationsRepository =
                new UserReminderRelationsRepository(new UserReminderRelationsDbContext());
        }
        
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult MyReminders()
        {
            var myRemindersViewModel = new MyRemindersViewModel()
            {
                MyReminders = _reminderRepository.GetReminders()
                    .Join(_userReminderRelationsRepository.GetUserReminderRelations().Where(r => r.UserId == User.Identity.GetUserId()), 
                        reminder => reminder.Id, 
                        relation =>relation.ReminderId,
                        (reminder, relation) => reminder).OrderBy(r => r.DueDate)
                
            };
            return View(myRemindersViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}