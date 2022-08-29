/*
 * Copyright (c) 2019-present RaisaEnergy. All Rights Reserved.
 * 
 * Licensed Material - Property of RaisaEnergy.
 */

using System.IO;

namespace Abrar.BakerOrg.Services
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
