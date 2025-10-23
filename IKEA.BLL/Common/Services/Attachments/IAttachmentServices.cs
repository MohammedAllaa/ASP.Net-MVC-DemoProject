using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Common.Services.Attachments
{
    public interface IAttachmentServices
    {
        public string UploadAImage(IFormFile File, string folderName);
        public bool DeleteImage(string filePath);
    }
}
