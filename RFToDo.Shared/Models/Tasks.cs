namespace RFToDo.Shared.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public int GoalId { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Status { get; set; }
        public bool Importance { get; set; }
        public virtual Goal Goal { get; set; }
    }
}
