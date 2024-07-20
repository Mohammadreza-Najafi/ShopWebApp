using Microsoft.AspNetCore.Http;
namespace _0_Framwork.Application
{
    public interface IFileUploader
    {
        string Upload(IFormFile file,string path);
    }
}
