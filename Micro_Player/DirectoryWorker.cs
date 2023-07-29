using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro_Player
{
    internal class DirectoryWorker: IDirectoryWorker, IDirectoryInformator
    {
        public string? GetDirName(string path)
        {
            if(!Directory.Exists(path)) return null;
            string? name = Path.GetFileName(Path.GetDirectoryName(path));
            return name;
        }

        public void CreateDirectory(string path)
        {
            if (!Directory.Exists(path) && !File.Exists(path))
            {
                Directory.CreateDirectory(path);
                return;
            }
            MessageBox.Show("Директория с таким названием уже существует");
        }

        public void DeleteDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                try
                {
                    Directory.Delete(path, true);
                    return;
                }
                catch
                {
                    MessageBox.Show("Ошибка удаления.");
                    return;
                }
            }
            MessageBox.Show("Директория не существует");
        }

        public string[]? GetAllFiles(string path, string type = "")
        {
            string[]? files = null;

            if (!Directory.Exists(path))
            {
                MessageBox.Show("Директория не существует.");
                return null;
            }
            try
            {
                files = Directory.GetFiles($@"{path}", type);
            }
            catch
            {
                MessageBox.Show("Директория недоступна.");
            }
            return files;
        }

        public string[]? GetAllDirs(string path, string type = "")
        {
            string[]? files = null;

            if (!Directory.Exists(path))
            {
                MessageBox.Show("Директория не существует.");
                return null;
            }
            try
            {
                files = Directory.GetDirectories($@"{path}", type);
            }
            catch
            {
                MessageBox.Show("Директория недоступна.");
            }
            return files;
        }

    }
}

