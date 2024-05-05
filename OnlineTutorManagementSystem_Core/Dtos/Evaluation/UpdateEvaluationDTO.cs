using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTutorManagmentSystem_Core.Dtos.Evaluation
{
    public class UpdateEvaluationDTO
    {
        public int Id { get; set; }
        public DateTime? EvaluationDate { get; set; }
        public string? Feedback { get; set; }
        public double? QuzziesMark { get; set; }
        public double? AttendanceMark { get; set; }
        public double? ParticipantsMark { get; set; }
        public double? AssignmentsMark { get; set; }
    }
}
