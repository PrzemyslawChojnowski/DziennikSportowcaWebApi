using System;
using System.Collections.Generic;
using System.Text;

namespace DziennikSportowca.Common.Interfaces
{
    public interface ILogger
    {
        void Debug(string msg);
        void Error(string msg);
        void Error(string msg, Exception ex);
        void Info(string msg);
        void Warning(string msg);       
    }
}
