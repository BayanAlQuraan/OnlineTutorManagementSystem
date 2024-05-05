using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OnlineTutorManagmentSystem_Core.Enums.OnlineTutorManagmentSystemLookups;

namespace OnlineTutorManagementSystem_Core.Models.Shared
{
    public class ResponseMessage
    {
        public eResult Result { get; set; }
        public string ErrorMessage { get; set; }
        public ErrorCode ErrorCode { get; set; }
        public object Payload { get; set; }
        
        public ResponseMessage() {
            this.Result = eResult.Failed;
            this.ErrorCode = ErrorCode.NoError;
        }

        public ResponseMessage(Exception ex)
        {
            this.Result = eResult.Failed;
            this.ErrorCode = ErrorCode.GeneralError;
            this.ErrorMessage = ex.Message;
        }
    }
}
