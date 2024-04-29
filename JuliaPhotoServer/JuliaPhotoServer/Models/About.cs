using Microsoft.Identity.Client;

namespace JuliaPhotoServer.Models
{
    public class About
    {
        public int Id { get; set; }
        public string Article { get; set; }
        public string Text { get; set; }

        public int? PhotoId { get; set; }
        public Photo? Photo { get; set; }
    }
}
