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
using Microsoft.AspNet.Identity;

namespace Reminder.Controllers
{
    [Authorize]
    public class RemindersController : Controller
    {
        private readonly IReminderRepository _reminderRepository;
        private readonly IUserReminderRelationsRepository _userReminderRelationsRepository;

        public RemindersController()
        {
            _reminderRepository = new ReminderRepository(new ReminderDbContext());
            _userReminderRelationsRepository =
                new UserReminderRelationsRepository(new UserReminderRelationsDbContext());
        }
        
        public ActionResult Details(int id)
        {
            if (_userReminderRelationsRepository.IsUserHasAccessToReminder(User.Identity.GetUserId(), id))
            {
                var reminderItem = new ReminderDetailsViewModel()
                {
                    ReminderItem = _reminderRepository.GetReminder(id)
                };
                return View(reminderItem);
            }
            else
            {
                return RedirectToAction("MyReminders", "Home");
            }
        }
        
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(ReminderItemModel reminderItem)
        {
            _reminderRepository.CreateReminder(reminderItem);
            var reminderId =_reminderRepository.GetReminderId(reminderItem);
            _userReminderRelationsRepository.CreateRelation(User.Identity.GetUserId(), reminderId);
            return RedirectToAction("MyReminders", "Home");
        }
        
        public ActionResult Edit(int id)
        {
            if (_userReminderRelationsRepository.IsUserHasAccessToReminder(User.Identity.GetUserId(), id))
            {
                var reminderItem = new ReminderDetailsViewModel()
                {
                    ReminderItem = _reminderRepository.GetReminder(id)
                };
                return View(reminderItem);
            }
            else
            {
                return RedirectToAction("MyReminders", "Home");
            }
        }
        
        [HttpPost]
        public ActionResult Edit(int id, ReminderItemModel reminderItem)
        {
            if (_userReminderRelationsRepository.IsUserHasAccessToReminder(User.Identity.GetUserId(), id))
            {
                _reminderRepository.UpdateReminder(id, reminderItem);
            }
            return RedirectToAction("MyReminders", "Home");
        }
        
        public ActionResult Delete(int id)
        {
            if (_userReminderRelationsRepository.IsUserHasAccessToReminder(User.Identity.GetUserId(), id))
            {
                _reminderRepository.DeleteReminder(id);
                _userReminderRelationsRepository.DeleteRelation(User.Identity.GetUserId(), id);
            }
            return RedirectToAction("MyReminders", "Home");
        }
    }
}