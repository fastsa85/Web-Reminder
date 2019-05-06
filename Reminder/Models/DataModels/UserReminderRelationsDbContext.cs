using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Reminder.Models.DataModels
{
    public class UserReminderRelationsDbContext : IdentityDbContext<ApplicationUser>
    {
        public UserReminderRelationsDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<UserReminderRelation> UserReminderRelations { get; set; }
    }
}