using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTutorManagmentSystem_Core.Models.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public DateTime CreationDate { get; set; }
        public string Details { get; set; }
        public int Status { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual Student Student { get; set; }


    }
}
