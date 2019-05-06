using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Reminder.Models.DataModels;

namespace Reminder.Models.Interfaces
{
    public interface IUserReminderRelationsRepository
    {
        IEnumerable<UserReminderRelation> GetUserReminderRelations();
        bool IsUserHasAccessToReminder(string userId, int reminderId);
        void CreateRelation(string userId, int reminderId);
        void DeleteRelation(string userId, int reminderId);
    }
}