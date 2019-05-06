using Reminder.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            //TODO: implement with LINQ
            var userReminderRelations = _userReminderRelationsRepository.GetUserReminderRelations().Where(r => r.UserId == User.Identity.GetUserId());
            var reminders = new List<ReminderItemModel>();

            foreach (var relation in userReminderRelations)
            {
                reminders.Add(_reminderRepository.GetReminder(relation.ReminderId));
            }
            //

            var myRemindersViewModel = new MyRemindersViewModel()
            {
                //MyReminders = _reminderRepository.GetReminders().OrderBy(x => x.DueDate)
                //MyReminders = _reminderRepository.GetReminders()
                //    .Join(_userReminderRelationsRepository.GetUserReminderRelations().Where(r => r.UserId == User.Identity.GetUserId()), 
                //        x => x.Id, y =>y.ReminderId, (x, y) => { return x.Id == y.ReminderId; })
                MyReminders = reminders
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