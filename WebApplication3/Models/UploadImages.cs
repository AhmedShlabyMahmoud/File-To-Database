using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class UploadImages
    {

        [Key]
        public int ID { get; set; }
        public string realpath { get; set; }
        [NotMapped]
        public IFormFile  files { get; set; }
    }
}
