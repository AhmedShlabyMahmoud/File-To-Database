using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/Upload")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        public static IWebHostEnvironment _webHostEnvironment;
        public ImagesContext DBcontext;

        public UploadController(ImagesContext ctr,IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment=webHostEnvironment;
            DBcontext=ctr;
        }
        [HttpPost]
        public string Post([FromForm] UploadImages uploadImages)
        {
            try
            {
                if (uploadImages.files.Length >0 )
                {

                    string path = _webHostEnvironment.WebRootPath + "\\upload\\" + DateTime.Now.TimeOfDay.Milliseconds;
                    if (!Directory.Exists(path))
                    {

                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream = System.IO.File.Create(path+ uploadImages.files.FileName))
                    {
                        uploadImages.files.CopyTo(fileStream);
                        fileStream.Flush();
                       
                    }
                    UploadImages imageUpload = new UploadImages();
                    imageUpload.realpath = path;
                    DBcontext.uploads.Add(imageUpload);
                    DBcontext.SaveChanges();
                    return "Upload Pic";
                }
                else
                {
                    return "Not Uploaded";
                
                }

            }
            catch (Exception ex)
            {

              return  ex.Message;
            }
             
        }


        [HttpGet]
        public ActionResult<List<UploadImages>> GetImagesUpload()
        {
            var result = DBcontext.uploads.ToList();
            return result;
        }
    }
}
