using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Reminder.Models.DataModels
{
    public class ReminderDbContext : IdentityDbContext<ApplicationUser>
    {
        public ReminderDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<ReminderItemModel> Reminders { get; set; }
    }
}