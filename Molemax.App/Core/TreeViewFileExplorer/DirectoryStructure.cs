using Molemax.App.Core.TreeViewFileExplorer.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molemax.App.Core.TreeViewFileExplorer
{
    public static class DirectoryStructure
    {
        public static List<DataItem> GetLogicalDrives()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            // This is only called once so set FullPath with the VolumeLabel, in DataItemViewModel I substring the actual drive name for the expanded items...
            return drives.Select(drive => new DataItem { FullPath = drive.Name, Type = DataType.Drive, }).ToList();
        }

        public static string GetFileOrFolderName(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return string.Empty;
            }

            var normalizedPath = path.Replace('/', '\\');
            var lastIndex = normalizedPath.LastIndexOf('\\');

            if (lastIndex <= 0)
            {
                return path;
            }

            return path.Substring(lastIndex + 1);
        }

        public static List<DataItem> GetDirectoryContents(string fullPath)
        {
            var items = new List<DataItem>();

            try
            {
                var dirs = Directory.GetDirectories(fullPath);

                if (dirs.Length > 0)
                {
                    items.AddRange(dirs.Select(dir => new DataItem
                    {
                        FullPath = dir,
                        Type = DataType.FolderClosed
                    }));
                }
            }
            catch
            {
                //TODO: handle exception.
            }

            try
            {
                var files = Directory.GetFiles(fullPath);

                if (files.Length > 0)
                {
                    items.AddRange(files.Select(dir => new DataItem
                    {
                        FullPath = dir,
                        Type = DataType.File
                    }));
                }
            }
            catch
            {
                //TODO: handle exception.
            }

            return items;
        }
    }
}
