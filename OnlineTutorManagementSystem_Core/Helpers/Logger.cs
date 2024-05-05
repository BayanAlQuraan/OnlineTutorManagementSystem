using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTutorManagementSystem_Core.Helpers
{
    public static class Logger
    {
        public static void LogError(Exception ex)
        {
            Log.Error(ex.Message);
        }
    }
}
