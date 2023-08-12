using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro_Player
{
    interface IFileWorker
    {
        void DeleteFile(string path);
    }

    interface IFileInformator
    {
        string? GetFileName(string path);
    }

    interface IDirectoryWorker
    {
        void CreateDirectory(string path);
        void DeleteDirectory(string path);
    }

    interface IDirectoryInformator
    {
        string? GetDirName(string path);
        string[]? GetAllFiles(string path, string type);
        //полные имена директорий
        string[]? GetAllDirs(string path, string type);
        //названия директорий
        string[]? GetDirNames(string[] files);
    }

}
