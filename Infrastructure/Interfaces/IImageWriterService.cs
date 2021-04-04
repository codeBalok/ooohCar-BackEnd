using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IImageWriterService
    {
        Task<string> UploadImage(IFormFile file);
    }
}
