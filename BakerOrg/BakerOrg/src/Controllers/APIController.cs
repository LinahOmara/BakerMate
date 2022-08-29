/*
 * Copyright (c) 2019-present RaisaEnergy. All Rights Reserved.
 * 
 * Licensed Material - Property of RaisaEnergy.
 */

using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Abrar.BakerOrg.Filters;
using Abrar.BakerOrg.Services;

namespace Abrar.BakerOrg.Controllers
{
    [ApiController, TypeFilter(typeof(ExceptionFilter))]
    public class APIController : ControllerBase
    {
        protected JsonResult Json(object data)
        {
            return new JsonResult(data);
        }

        protected FileContentResult File(FileData file)
        {
            var provider = new FileExtensionContentTypeProvider();
            if (provider.TryGetContentType(file.FileName, out string contentType) == false)
            {
                contentType = "application/octet-stream"; // Default https://developer.mozilla.org/en-US/docs/Web/HTTP/Basics_of_HTTP/MIME_types/Common_types
            }

            return File(
                fileContents: file.FileContent,
                fileDownloadName: file.FileName,
                contentType: contentType
            );
        }

        protected FileData ReadFile(IFormFile file)
        {
            if (file == null)
            {
                throw new ArgumentNullException("Input file cannot be null.");
            }

            using (var fileStream = file.OpenReadStream())
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                var fileContent = memoryStream.ToArray();

                return new FileData
                {
                    FileName = file.FileName,
                    FileContent = fileContent
                };
            }
        }
    }
}
