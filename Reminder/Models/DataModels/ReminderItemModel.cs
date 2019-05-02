using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reminder.Models.DataModels
{
    public class ReminderItemModel
    {
        [Column(TypeName = "int")]
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime DueDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreationDate { get; set; }
    }
}