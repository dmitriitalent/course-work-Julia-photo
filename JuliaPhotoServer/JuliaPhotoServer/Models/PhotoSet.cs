

using System.ComponentModel.DataAnnotations.Schema;

namespace JuliaPhotoServer.Models
{
	public class PhotoSet
	{
		public PhotoSet() { 
			Photos = new List<Photo>();
		}
		public int Id { get; set; }
        public DateTime Date { get; set; }

        public int? PhotoSetTypeId { get; set; }
		public PhotoSetType PhotoSetType { get; set; }

		public ICollection<Photo> Photos { get; set; }

	}
}
