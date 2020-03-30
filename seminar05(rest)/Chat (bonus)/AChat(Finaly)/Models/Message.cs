using System;
using System.ComponentModel.DataAnnotations;

namespace AChat_Finaly_.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public string Name { get; set; }
        public DateTime TimeStamp { get; set; } 
        public int StoryModel_Id { get; set; }
    }
}