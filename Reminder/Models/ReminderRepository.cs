using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Reminder.Models.DataModels;
using Reminder.Models.Interfaces;

namespace Reminder.Models
{
    public class ReminderRepository : IReminderRepository
    {
        private readonly ReminderDbContext _reminderDbContext;

        public ReminderRepository(ReminderDbContext reminderDbContext)
        {
            _reminderDbContext = reminderDbContext;
        }

        public void CreateReminder(ReminderItemModel reminderItem)
        {
            reminderItem.CreationDate = DateTime.Now.Date;
            _reminderDbContext.Reminders.Add(reminderItem);
            _reminderDbContext.SaveChanges();
        }

        public ReminderItemModel GetReminder(int id)
        {
            return _reminderDbContext.Reminders.Where(r => r.Id == id).FirstOrDefault();
        }

        public IEnumerable<ReminderItemModel> GetReminders()
        {
            return _reminderDbContext.Reminders;
        }

        public void UpdateReminder(int id, ReminderItemModel reminderItem)
        {
            ReminderItemModel item = _reminderDbContext.Reminders.Where(x => x.Id == id).FirstOrDefault();
            item.Title = reminderItem.Title;
            item.Description = reminderItem.Description;
            item.DueDate = reminderItem.DueDate;
            _reminderDbContext.SaveChanges();
        }

        public void DeleteReminder(int id)
        {
            ReminderItemModel item = _reminderDbContext.Reminders.Where(x => x.Id == id).FirstOrDefault();
            _reminderDbContext.Reminders.Remove(item);
            _reminderDbContext.SaveChanges();
        }
    }
}