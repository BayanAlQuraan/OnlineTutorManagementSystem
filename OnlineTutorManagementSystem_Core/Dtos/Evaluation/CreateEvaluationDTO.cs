using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTutorManagmentSystem_Core.Dtos.Evaluation
{
    public class CreateEvaluationDTO
    {
        
        public DateTime EvaluationDate { get; set; }
        public double QuzziesMark { get; set; }
        public double AttendanceMark { get; set; }
        public double ParticipantsMark { get; set; }
        public double AssignmentsMark { get; set; }
        public string Feedback { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set;}
    }
}
