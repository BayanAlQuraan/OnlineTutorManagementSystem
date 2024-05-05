using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTutorManagmentSystem_Core.Dtos.Invoice
{
   public class InvoiceInfoDTO
    {
        public double Amount { get; set; }
        public string Details { get; set; }
        public int StudentId { get; set; }
    }
}
