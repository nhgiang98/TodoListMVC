using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoListMVC.Models
{
    public class Task
    {
        [Key]
        public string Id { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public StatusProgress Status { get; set; }
        public string StatusTask { get; set; }
    }

    public enum StatusProgress
    {
        New,
        Todo,
        Done
    }
}