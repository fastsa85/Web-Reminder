using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Reminder.Models.DataModels
{
    public class UserReminderRelation
    {
        public int Id { get; set; }
        
        public string UserId { get; set; }
        
        public int ReminderId { get; set; }
    }
}