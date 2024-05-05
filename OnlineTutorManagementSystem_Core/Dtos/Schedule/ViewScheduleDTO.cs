using OnlineTutorManagmentSystem_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTutorManagmentSystem_Core.Models.Entities
{
    public class ViewScheduleDTO
    {
        public  string StudentName { get; set; }
        public  string ClassName { get; set; }
        public  string SubjectName { get; set; }

        public ViewScheduleDTO(StudentClass studentClass) {
            this.StudentName = studentClass.Student.FirstName + " " + studentClass.Student.LastName;
            this.ClassName = studentClass.Class.Name;
            this.SubjectName = studentClass.Class.Subject.Name;
        }
    }
}
