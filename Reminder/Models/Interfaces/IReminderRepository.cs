using Reminder.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reminder.Models.Interfaces
{
    public interface IReminderRepository
    {
        IEnumerable<ReminderItemModel> GetReminders();
        ReminderItemModel GetReminder(int id);
        void CreateReminder(ReminderItemModel reminderItem);
        void UpdateReminder(int id, ReminderItemModel reminderItem);
        void DeleteReminder(int id);
    }
}