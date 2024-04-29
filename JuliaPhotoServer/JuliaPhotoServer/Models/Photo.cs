
namespace JuliaPhotoServer.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Filename { get; set; }
        public string Path { get; set; }
        public string Alt { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public int? PhotoSetId { get; set; }
        public PhotoSet PhotoSet { get; set; }
    }
}
