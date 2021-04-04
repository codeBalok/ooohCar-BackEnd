
using Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Common.Enums;

namespace CarsbyServices.Services
{
    public class ImageWriterService : IImageWriterService
    {
        private readonly IHostingEnvironment _env;
        public ImageWriterService(IHostingEnvironment env)
        {
            _env = env;
        }
        public async Task<string> UploadImage(IFormFile file)
        {
            if (file == null)
                return null;
            if (CheckIfImageFile(file))
            {
                return await WriteFile(file).ConfigureAwait(false);
            }

            return "Invalid image file";
        }

        public async Task<string> UploadDoc(IFormFile file)
        {
            if (file == null)
                return null;
            if (CheckIfImageFile(file))
            {
                return await WriteDocs(file).ConfigureAwait(false);
            }

            return "Invalid image file";
        }

        /// <summary>
        /// Method to check if file is image file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private bool CheckIfImageFile(IFormFile file)
        {
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileBytes = ms.ToArray();
            }

            return GetImageFormat(fileBytes) != ImageFormat.unknown;
        }

        /// <summary>
        /// Method to write file onto the disk
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private async Task<string> WriteFile(IFormFile file)
        {
            if (file == null)
                return null;
            var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
            string fileName = Guid.NewGuid().ToString() + extension;
            if (!Directory.Exists(Path.Combine(_env.WebRootPath, "Images")))
            {
                Directory.CreateDirectory(Path.Combine(_env.WebRootPath, "Images"));
            }
            string directoryPath = Path.Combine(_env.WebRootPath, "Images");
            var filePath = Path.Combine(directoryPath, fileName);
            using (var bits = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(bits).ConfigureAwait(false);
            }
            return filePath;
        }


        private async Task<string> WriteDocs(IFormFile file)
        {
            if (file == null)
                return null;
            var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
            string fileName = Guid.NewGuid().ToString() + extension;
            if (!Directory.Exists(Path.Combine(_env.WebRootPath, "docs")))
            {
                Directory.CreateDirectory(Path.Combine(_env.WebRootPath, "docs"));
            }
            string directoryPath = Path.Combine(_env.WebRootPath, "docs");
            var filePath = Path.Combine(directoryPath, fileName);
            using (var bits = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(bits).ConfigureAwait(false);
            }
            return filePath;
        }

        private ImageFormat GetImageFormat(byte[] bytes)
        {
            var bmp = Encoding.ASCII.GetBytes("BM");     // BMP
            var gif = Encoding.ASCII.GetBytes("GIF");    // GIF
            var png = new byte[] { 137, 80, 78, 71 };              // PNG
            var tiff = new byte[] { 73, 73, 42 };                  // TIFF
            var tiff2 = new byte[] { 77, 77, 42 };                 // TIFF
            var jpeg = new byte[] { 255, 216, 255, 224 };          // jpeg
            var jpeg2 = new byte[] { 255, 216, 255, 225 };         // jpeg canon
            var pdf = new byte[] { 37, 80, 68, 70 };         // png

            if (bmp.SequenceEqual(bytes.Take(bmp.Length)))
                return ImageFormat.bmp;

            if (gif.SequenceEqual(bytes.Take(gif.Length)))
                return ImageFormat.gif;

            if (png.SequenceEqual(bytes.Take(png.Length)))
                return ImageFormat.png;

            if (tiff.SequenceEqual(bytes.Take(tiff.Length)))
                return ImageFormat.tiff;

            if (tiff2.SequenceEqual(bytes.Take(tiff2.Length)))
                return ImageFormat.tiff;

            if (jpeg.SequenceEqual(bytes.Take(jpeg.Length)))
                return ImageFormat.jpeg;

            if (jpeg2.SequenceEqual(bytes.Take(jpeg2.Length)))
                return ImageFormat.jpeg;
            if (pdf.SequenceEqual(bytes.Take(pdf.Length)))
                return ImageFormat.pdf;

            return ImageFormat.unknown;
        }
    }
}

