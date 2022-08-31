/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using System.IO;

namespace BakerMate.Services
{
    /// <summary>
    /// class to hold file data with file processing function. primairly used for file uploads
    /// </summary>
    public class FileData
    {
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }

        public string WriteFile(string directoryPath)
        {
            var fullPath = Path.Combine(directoryPath, FileName);
            File.WriteAllBytes(fullPath, FileContent);

            return fullPath;
        }
    }
}
