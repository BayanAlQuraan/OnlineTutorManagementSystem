using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTutorManagmentSystem_Core.Models.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
        public virtual List<Invoice> Invoices { get; set; }
        public virtual List<Payment> Payments { get; set; }
        public virtual List<StudentClass> StudentClasses { get; set; }
        public virtual List<Evaluation> Evaluations { get; set; }
        public virtual List<Certificate> Certificates { get; set; }
    }
}
