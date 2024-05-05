using OnlineTutorManagmentSystem_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTutorManagmentSystem_Core.Dtos.Evaluation
{
   public class ViewEvaluationDTO
    {
        public double Score { get; set; }
        public double QuzziesMark { get; set; }
        public double AttendanceMark { get; set; }
        public double ParticipantsMark { get; set; }
        public double AssignmentsMark { get; set; }
        public DateTime EvaluationDate { get; set; }

        public ViewEvaluationDTO(Models.Entities.Evaluation evaluation)
        {
            this.Score = evaluation.Score;
            this.EvaluationDate = evaluation.EvaluationDate;
            this.AttendanceMark = evaluation.AttendanceMark;
            this.ParticipantsMark = evaluation.ParticipantsMark;
            this.QuzziesMark = evaluation.QuzziesMark;
            this.AssignmentsMark = evaluation.AssignmentsMark;
        }
    }
}
