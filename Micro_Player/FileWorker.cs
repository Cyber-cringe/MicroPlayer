using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro_Player
{
    internal class FileWorker: IFileWorker, IFileInformator
    {
        public void DeleteFile(string path)
        {
            if (!File.Exists(path)) return;
            try 
            {
                File.Delete(path);
            }
            catch
            {
                MessageBox.Show("Ошибка удаления");
            }
        }

        public string? GetFileName(string path)
        {
            if (!File.Exists(path)) return null; 
            string? fileNameWithExtension = Path.GetFileName(path);
            string? extension = Path.GetExtension(path);
            if (extension == null) return fileNameWithExtension;
            string fileName = fileNameWithExtension.Replace(extension, "");
            return fileName;
        }

    }
}
