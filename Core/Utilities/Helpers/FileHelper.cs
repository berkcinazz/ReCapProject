using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Utilities.Helpers
{
    public static class FileHelper 
    {
        public static string UploadImage(IFormFile image)
        {
            string path = Path.GetTempFileName();
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                image.CopyTo(fileStream);
            }
            string newPath = NewPath(image);
            File.Move(path, @"wwwroot\images\"+newPath);
            return newPath;
        }
        public static IResult DeleteImage(string path)
        {
            path = Environment.CurrentDirectory + @"\wwwroot\images\" + path;
            if (!File.Exists(path))
            {
                return new ErrorResult("File not found.");
            }
            File.Delete(path);
            return new SuccessResult("File deleted succesfully.");
        }

        private static string NewPath(IFormFile image)
        {
            FileInfo fileInfo = new FileInfo(image.FileName);
            string fileExtension = fileInfo.Extension;
            return Guid.NewGuid() + fileExtension;
        }
    }
}
