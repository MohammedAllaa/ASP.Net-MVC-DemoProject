using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Common.Services.Attachments
{
    public class AttachmentServices : IAttachmentServices
    {
        private readonly List<string> _allowedExtensions = new List<string> { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };

        private const long _maxFileSizeInBytes = 5 * 1024 * 1024; // 5 MB
        public string UploadAImage(IFormFile File, string folderName)
        {
            var fileExtension = Path.GetExtension(File.FileName).ToLower();
            if (!_allowedExtensions.Contains(fileExtension))
            {
                throw new InvalidOperationException("Unsupported file type.");
            }
            if (File.Length > _maxFileSizeInBytes)
            {
                throw new InvalidOperationException("File size exceeds the maximum limit.");
            }

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot", "files", folderName);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var uniqueFileName = $"{Guid.NewGuid()}_{fileExtension}";
            var filePath = Path.Combine(folderPath, uniqueFileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                File.CopyTo(stream);
            }
            return uniqueFileName;
        }
        public bool DeleteImage(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }
            return false;
        }

    }
}
