using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF_watermarker.Models
{
    public class PageViewModel
    {
        public PageViewModel(Image originalImage, PictureBox pictureBox, Panel panel)
        {
            OriginalImage = originalImage;
            PictureBox = pictureBox;
            Panel = panel;
        }

        public Image OriginalImage { get; set; }
        public PictureBox PictureBox { get; set; }
        public Panel Panel { get; set; }
        public bool Marked { get; set; } = true;
    }
}
