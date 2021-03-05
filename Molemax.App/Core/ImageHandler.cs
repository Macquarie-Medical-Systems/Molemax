using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Media;

namespace Molemax.App.Core
{
    public class ImageHandler
    {
        //if it is container image, then Id is container image (makro or closeup or mikro) Id
        //if it is not container image, then Id is (makro or closeup or mikro) Id
        public int Id { get; set; }
        public string CreateDate { get; set; }
        //Relative Image table id
        public int ImageId { get; set; }
        //If it has container Image, then this is container image Id
        public KIND_ENUM ContainerImageKind { get; set; }
        public int ContainerImageId { get; set; }
        public double ContainerImageWidth { get; set; }
        public double ContainerImageHeight { get; set; }
        public BitmapImage Image { get; set; }
        public BitmapImage SmallKen { get; set; }
        public int Kenpos { get; set; }
        public string Loctext { get; set; }
        //Rectangle position in container image
        public double FullPicRectangleX { get; set; }
        public double FullPicRectangleY { get; set; }
        public double FullPicRectangleWidth { get; set; }
        public double FullPicRectangleHeight { get; set; }
        //container image real size
        public double FullPicActualWidth { get; set; }
        public double FullPicActualHeight { get; set; }
        //Point positon in container image
        public double FullPicPointX { get; set; }
        public double FullPicPointY { get; set; }
        //Ratio between Rectangle size and container image 
        public double ImageAndRectangleXRatio { get; set; }
        public double ImageAndRectangleYRatio { get; set; }
        public double ImageAndRectangleWidthRatio { get; set; }
        public double ImageAndRectangleHeightRatio { get; set; }
        public Visibility FullPicPointVisible { get; set; }
        public string Title { get; set; }
        public Brush ImageHistoryTextBackground { get; set; }
        public List<ImageHandler> SelectedHistoryImageList { get; set; }
    }
}
