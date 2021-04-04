using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var sourcepath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var stream = new FileStream(sourcepath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            var result = NewPath(file);
            File.Move(sourcepath, result);
            var filePath = result.Replace(@"\", "/");
            filePath = filePath.Replace("wwwroot", "");
            return filePath;
        }

        public static void Delete(string path)
        {
            File.Delete(path);
        }

        public static string Update(string sourcePath, IFormFile file)
        {
            var result = NewPath(file);
            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Delete(sourcePath);
            return result;
        }

        public static string NewPath(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;
            var newPath = Guid.NewGuid().ToString() + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Year + fileExtension;
            string result = $@"wwwroot\Images\{newPath}";
            return result;
        }
    }
}
