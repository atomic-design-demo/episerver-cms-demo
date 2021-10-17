using AtomicDesignDemo.Models;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;

namespace AtomicDesignDemo.Features.Image.Models
{
    [ContentType(GUID = "13689148-a4c5-4971-9d0c-b0409bcd0864",
        DisplayName = "Image File",
        Description = "The media asset image file type.")]
    [MediaDescriptor(ExtensionString = "jpg,jpeg,jpe,ico,gif,bmp,png,tiff,tif")]
    public class ImageFile : BaseImageFile
    {
    }
}
