using ImageManagement.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManagement.Repository
{
    public class ImageFileRepository : Repository<ImageFile>, IImageFileRepository
    {
        public ImageFileRepository(ImageContext context) : base(context)
        {
        }
    }
}
