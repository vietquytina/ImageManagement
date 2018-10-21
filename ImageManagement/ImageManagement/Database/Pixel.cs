using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManagement.Database
{
    [Table("Pixels")]
    public class Pixel
    {
        [Required()]
        [ForeignKey("File")]
        public int FileId { get; set; }

        public ImageFile File { get; set; }

        [Required()]
        public int PixelX { get; set; }

        [Required()]
        public int PixelY { get; set; }

        [Required()]
        [Range(0, 255)]
        public int PixelR { get; set; }

        [Required()]
        [Range(0, 255)]
        public int PixelG { get; set; }

        [Required()]
        [Range(0, 255)]
        public int PixelB { get; set; }
    }
}