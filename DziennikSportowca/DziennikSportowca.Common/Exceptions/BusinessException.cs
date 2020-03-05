using System;
using System.Collections.Generic;
using System.Text;

namespace DziennikSportowca.Common.Exceptions
{
    public enum BusinessExceptionType
    {

    }

    public class BusinessException : Exception
    {
        public new string Message { get; set; }
        public BusinessExceptionType Type { get; set; }

        public BusinessException() : base()
        {
        }

        public BusinessException(string message)
        {
            Message = message;
        }

        public BusinessException(BusinessExceptionType type)
        {
            Type = type;
        }

        public BusinessException(BusinessExceptionType type, string message)
        {
            Type = type;
            Message = message;
        }
    }
}
