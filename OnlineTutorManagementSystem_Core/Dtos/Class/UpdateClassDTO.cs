using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTutorManagmentSystem_Core.Dtos.Class
{
   public class UpdateClassDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
        public string? Address { get; set; }
        public int? Capacity { get; set; }
        public int? NumberOfStudents { get; set; }
    }
}
