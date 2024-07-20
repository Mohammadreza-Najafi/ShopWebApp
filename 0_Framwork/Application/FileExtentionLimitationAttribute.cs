
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace _0_Framwork.Application
{
 
    public class FileExtentionLimitationAttribute : ValidationAttribute
    {
        private readonly string[] _validExtentions;

        public FileExtentionLimitationAttribute(string[] validExtentions)
        {
            _validExtentions = validExtentions;
        }

        public override bool IsValid(object value)
        {
            var file = value as IFormFile;
            if (file == null) 
                return true;

            var fileExtention = Path.GetExtension(file.FileName);

            return _validExtentions.Contains(fileExtention);
        }
    }
}
