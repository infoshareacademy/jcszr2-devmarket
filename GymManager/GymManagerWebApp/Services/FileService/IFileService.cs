using GymManagerWebApp.Models;
using Microsoft.AspNetCore.Http;

namespace GymManagerWebApp.Services.FileService
{
    public interface IFileService
    {
        string UploadFile(dynamic model);
    }
}