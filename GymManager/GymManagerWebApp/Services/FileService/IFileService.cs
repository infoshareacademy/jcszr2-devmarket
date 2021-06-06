using GymManagerWebApp.Models;

namespace GymManagerWebApp.Services.FileService
{
    public interface IFileService
    {
        string UploadFile(SignInUserViewModel model);
    }
}