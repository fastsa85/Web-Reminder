using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Reminder.Models;
using Reminder.Models.DataModels;

namespace Reminder.ViewModels
{
    public class MyRemindersViewModel
    {
        public IEnumerable<ReminderItemModel> MyReminders { get; set; }
    }
}