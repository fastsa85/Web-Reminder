using Reminder.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Reminder.Models;
using Reminder.Models.DataModels;
using Reminder.ViewModels;

namespace Reminder.Controllers
{
    public class HomeController : Controller
    {
        private readonly IReminderRepository _reminderRepository;
        
        public HomeController()
        {
            _reminderRepository = new ReminderRepository(new ReminderDbContext());
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyReminders()
        {
            var myRemindersViewModel = new MyRemindersViewModel()
            {
                MyReminders = _reminderRepository.GetReminders().OrderBy(x => x.DueDate)
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