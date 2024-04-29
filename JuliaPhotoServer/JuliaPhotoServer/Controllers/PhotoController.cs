using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JuliaPhotoServer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Drawing;

namespace JuliaPhotoServer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PhotoController : ControllerBase
	{
		public DatabaseContext db;
		public IHostEnvironment env;

		public PhotoController(
			IHostEnvironment _env,
			DatabaseContext _db
		)
		{
			db = _db;
			env = _env;
		}

		[Route("files")]
		[HttpPost]
		public string Post(List<IFormFile> files)
		{
			foreach (IFormFile file in files)
			{
				string path = Path.Combine(env.ContentRootPath, "files", "photos", file.FileName + ".png");
				FileManager.UploadPhoto(file, path);
			}
			return "OK";
		}
		[HttpPost]
		public string Post(IList<PostedPhoto> photos)
		{
			IList<Photo> values = new List<Photo>();
			foreach (PostedPhoto photo in photos)
			{
				string path = Path.Combine(env.ContentRootPath, "files", "photos", photo.Filename + ".png");
                int width;
                int height;
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    using (Image image = Image.FromStream(fs))
                    {
                        width = image.Width;
                        height = image.Height;
                    }

                }
				Photo photoDB = new()
				{
					Alt = photo.Alt,
					Filename = photo.Filename,
					PhotoSetId = photo.PhotoSetId,
					Path = path,
					Height = height,
					Width = width
				};
				photoDB.PhotoSet = db.PhotoSets.FirstOrDefault(ps => ps.Id == photoDB.PhotoSetId); 
				values.Add(photoDB);
			}
			db.Photos.AddRange(values);
            db.SaveChanges();
            return "OK";
		}

		[HttpGet("{count}")]
		public string Get(int count)
		{
			Random random = new Random();
			var photos = db.Photos.Include(p => p.PhotoSet).ToList();
			IList<Photo> photosGet = new List<Photo>();
			ICollection<int> ints = new List<int>();

			for (int i = 0; i < count; i++)
			{
                
                int elem = random.Next(db.Photos.Count());
				if (ints.Contains(elem) )
				{
					i--;
					continue;
				}
				else
				{
                    ints.Add(elem);
                    photosGet.Add(photos[elem]);
                }
            }

			return Newtonsoft.Json.JsonConvert.SerializeObject(photosGet, Formatting.Indented,
				new JsonSerializerSettings
				{
					ReferenceLoopHandling = ReferenceLoopHandling.Ignore
				});
		}

		[HttpDelete("{photoId}")]
		public string Delete(int photoId)
		{
			Photo photo = db.Photos.FirstOrDefault(p => p.Id == photoId);
            db.Photos.Remove(
				photo
			);
			db.SaveChanges();
			FileManager.DeletePhoto(photo.Path);

			return "OK";
		}
	}

	public class PostedPhoto
	{
		public int Id { get; set; }
		public string? Filename { get; set; }
		public string? Path { get; set; }
		public string? Alt { get; set; }

		public int? PhotoSetId { get; set; }
	}

}
