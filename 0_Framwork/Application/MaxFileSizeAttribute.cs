using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace _0_Framwork.Application
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;

        public MaxFileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        public override bool IsValid(object value)
        {
            var file = value as IFormFile;

            if (file == null)
                return true;

            return file.Length <= _maxFileSize;

        }

    }
}
