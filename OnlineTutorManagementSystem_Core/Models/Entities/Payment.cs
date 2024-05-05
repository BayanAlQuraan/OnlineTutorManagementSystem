using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTutorManagmentSystem_Core.Models.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public string PaymentMethod { get; set; }
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

    }
}
