using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTutorManagmentSystem_Core.Models.Entities
{
    public class Subject
    {
        public int Id {  get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Class> Classes { get; set; }
        public virtual List<Certificate> Certificates { get; set; }
        
    }
}
