namespace JuliaPhotoServer.Models
{
    public class PhotoSetType
    {
        public PhotoSetType()
        {
            PhotoSets = new List<PhotoSet>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public ICollection<PhotoSet> PhotoSets { get; set; }
    }
}
