using System;
using System.IO;

namespace ModExtractorPro.ModExtraction.System
{
    /// <summary>
    /// Makes folders
    /// </summary>
    public class CreateFolders
    {
        /// <summary>
        /// Makes a folder
        /// </summary>
        /// <param name="FolderLocation">The path of the folder</param>
        /// <returns>The folder.exists</returns>
        [STAThread]
        public static bool MakeFolder(string FolderLocation)
        {
            DirectoryInfo Folder = Directory.CreateDirectory(FolderLocation);

            return Folder.Exists;
        }
    }
}