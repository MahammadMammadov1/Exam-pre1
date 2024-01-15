using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business.Helper
{
    public static class Helper
    {
        public  static string SaveFile(string root, string directory,IFormFile file)
        {
            string filepath = file.FileName.Length > 100 ? file.FileName.Substring(file.FileName.Length - 64,64) : file.FileName;

            string newFile = Guid.NewGuid().ToString() + filepath;

            string path = Path.Combine(root,directory, newFile);

            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return newFile;
        }
    }
}
