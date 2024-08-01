using RFToDo.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFToDo.Shared.DTO
{
    public class GoalDTO
    {
        public Goal Goal{ get; set; } = new Goal();
        public int TotalTasks { get; set; }
        public int CompleteTasks { get; set; }
        public double Percentage { get; set; }
    }
}
