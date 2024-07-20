using _0_Framwork.Application;

namespace ShopWebApp
{
    public class FileUploader : IFileUploader
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUploader(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string Upload(IFormFile file,string path)
        {
            if (file == null) return "";

            var directoryPath = $"{_webHostEnvironment.WebRootPath}//ProductPictures//{path}";

            if(!Directory.Exists(directoryPath)) 
            {
                Directory.CreateDirectory(directoryPath);
            }

            var fileName = $"{ToFileName(DateTime.Now)}-{file.FileName}";

            var filePath = $"{directoryPath}//{fileName}";

            using (var output = File.Create(filePath))
            {
                file.CopyTo(output);
            }

            return $"{path}/{fileName}";
        }
        public string ToFileName(DateTime date)
        {

            return $"{date.Year:0000}-{date.Month:00}-{date.Day:00}-{date.Hour:00}-{date.Minute:00}-{date.Second:00}";

        }
    }
}
