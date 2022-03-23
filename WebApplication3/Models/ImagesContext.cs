using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models
{
    public class ImagesContext :DbContext
    {
        public ImagesContext(DbContextOptions contextOptions) : base(contextOptions)
        {


        }
        public virtual DbSet<UploadImages> uploads { get; set; }
    }
}

