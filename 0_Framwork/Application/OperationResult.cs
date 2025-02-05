﻿
namespace _0_Framwork.Application
{
    public class OperationResult
    {
        public bool IsSuccedded { get; set; }
        public string Message { get; set; }

        public OperationResult()
        {
            IsSuccedded = false;
        }

        public OperationResult Succedded(string message = "the operation is succsessfull")
        {
            IsSuccedded = true;
            Message = message;
            return this;
        }

        public OperationResult Failed(string message = "faild , try again")
        {
            IsSuccedded = false;
            Message = message;
            return this;
        }

    }
}
