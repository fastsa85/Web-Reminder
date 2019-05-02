using Reminder.Models;
using Reminder.Models.DataModels;
using Reminder.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin;
using Reminder.ViewModels;

namespace Reminder.Controllers
{
    public class RemindersController : Controller
    {
        private readonly IReminderRepository _reminderRepository;

        public RemindersController()
        {
            _reminderRepository = new ReminderRepository(new ReminderDbContext());
        }

        public ActionResult Details(int id)
        {
            var reminderItem = new ReminderDetailsViewModel()
            {
                ReminderItem = _reminderRepository.GetReminder(id)
            };

            return View(reminderItem);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ReminderItemModel reminderItem)
        {
            _reminderRepository.CreateReminder(reminderItem);
            return RedirectToAction("MyReminders", "Home");
        }

        public ActionResult Edit(int id)
        {
            var reminderItem = new ReminderDetailsViewModel()
            {
                ReminderItem = _reminderRepository.GetReminder(id)
            };

            return View(reminderItem);
        }

        [HttpPost]
        public ActionResult Edit(int id, ReminderItemModel reminderItem)
        {
            _reminderRepository.UpdateReminder(id, reminderItem);
            return RedirectToAction("MyReminders", "Home");
        }

        public ActionResult Delete(int id)
        {
            _reminderRepository.DeleteReminder(id);
            return RedirectToAction("MyReminders", "Home");

        }
    }
}