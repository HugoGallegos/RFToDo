using System.ComponentModel.DataAnnotations.Schema;

namespace RFToDo.Shared.Models
{
    public class Goal
    {
        public Goal()
        {
            Tasks = new HashSet<Tasks>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        [NotMapped]
        public decimal Percentage { get; set; }
        [NotMapped]
        public int CompleteTasks { get; set; }
        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}
