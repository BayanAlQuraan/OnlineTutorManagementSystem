using OnlineTutorManagmentSystem_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTutorManagmentSystem_Core.Dtos.Payment
{
    public class GeneratPaymentLinkDTO
    {
       
        public string PaymentMethod { get; set; }
        public double Amount { get; set; }
        public GeneratPaymentLinkDTO(Models.Entities.Payment payment)
        {
            this.PaymentMethod = payment.PaymentMethod;
            this.Amount = payment.Amount;
        }
    }
}
