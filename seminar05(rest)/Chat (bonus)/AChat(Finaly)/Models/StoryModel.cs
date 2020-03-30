using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AChat_Finaly_.Models
{
    public class StoryModel
    {
        [Key]
        public int Id { get; set; }
        public int ChatId { get; set; }
        public List<Message> Messages {get;set;}
    }
}