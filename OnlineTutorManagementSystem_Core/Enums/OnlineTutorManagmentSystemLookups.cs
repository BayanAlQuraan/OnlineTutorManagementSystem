using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTutorManagmentSystem_Core.Enums
{
   public class OnlineTutorManagmentSystemLookups
    {
        public enum PaymentMethod
        {
            PayPal,
            Visa,
            Cash,
            Wallet 
        }
        public enum InvoiceStatus
        {
           Paid = 1,
           UnPaid = -1
        }
        public enum eResult
        {
            Success = 0,
            Failed = -1,
            NotFound = -100
        }

        public enum ErrorCode
        {
            NoError = 0,
            GeneralError = -1,
            NotFound = -100,
            UnpaidInvoices = -101,
            PasswordNotMatch=-102,
            EmailOrPhoneShouldBeFilled = -103,
            InsufficientAmount=-104,
        }

    }
}
