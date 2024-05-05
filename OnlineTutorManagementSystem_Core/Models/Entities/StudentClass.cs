using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTutorManagmentSystem_Core.Models.Entities
{
    public class StudentClass
    {
        public int Id { get; set; }
        public virtual Student Student { get; set; }
        public virtual Class Class { get; set; }
    }
}
