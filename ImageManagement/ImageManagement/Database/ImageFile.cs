using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManagement.Database
{
    [Table("ImageFile")]
    public class ImageFile
    {
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FileId { get; set; }

        [Required()]
        [StringLength(500)]
        public string FileName { get; set; }

        [Required()]
        public long FileSize { get; set; }

        public Collection<Pixel> Pixels { get; set; }
    }
}