using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Reminder.Models.Interfaces;

namespace Reminder.Models.DataModels
{
    public class UserReminderRelationsRepository : IUserReminderRelationsRepository
    {
        private readonly UserReminderRelationsDbContext _userReminderRelationsDbContext;

        public UserReminderRelationsRepository(UserReminderRelationsDbContext userReminderRelationsDbContext)
        {
            _userReminderRelationsDbContext = userReminderRelationsDbContext;
        }

        public void CreateRelation(string userId, int reminderId)
        {
            _userReminderRelationsDbContext.UserReminderRelations.Add(
                new UserReminderRelation()
                {
                    UserId = userId,
                    ReminderId = reminderId
                });
            _userReminderRelationsDbContext.SaveChanges();
        }

        public void DeleteRelation(string userId, int reminderId)
        {
            var relation = _userReminderRelationsDbContext.UserReminderRelations
                .Where(x => x.UserId == userId)
                .Where(x => x.ReminderId == reminderId).FirstOrDefault();
            _userReminderRelationsDbContext.UserReminderRelations.Remove(relation);
            _userReminderRelationsDbContext.SaveChanges();
        }

        public IEnumerable<UserReminderRelation> GetUserReminderRelations()
        {
            return _userReminderRelationsDbContext.UserReminderRelations;
        }

        public bool IsUserHasAccessToReminder(string userId, int reminderId)
        {
            return GetUserReminderRelations()
                .Where(r => r.UserId == userId)
                .Where(r => r.ReminderId == reminderId).ToList().Count > 0;
        }
    }
}