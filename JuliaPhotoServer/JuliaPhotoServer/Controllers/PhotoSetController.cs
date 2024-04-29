using JuliaPhotoServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Reflection.PortableExecutable;
using System.Drawing;

namespace JuliaPhotoServer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PhotoSetController : ControllerBase
	{
		public DatabaseContext db;
		public IHostEnvironment env;

		public PhotoSetController(
			IHostEnvironment _env,
			DatabaseContext _db
		)
		{
			db = _db;
			env = _env;
		}

		[Route("SystemPhotoSet")]
		[HttpGet]
		public int GetSystem()
		{
			PhotoSet photoSet = db.PhotoSets.Include(ps => ps.PhotoSetType).FirstOrDefault(ps => ps.PhotoSetType.Type == "System");
			return photoSet.Id;
		}

        [Route("All")]
        [HttpGet]
		public string Get()
		{
			return Newtonsoft.Json.JsonConvert.SerializeObject(db.PhotoSets.Include(ps => ps.Photos).Include(ps => ps.PhotoSetType).ToList(),
				new JsonSerializerSettings
				{
					ReferenceLoopHandling= ReferenceLoopHandling.Ignore
				});
		}

		[HttpPost("{typeName}")]
		public string Post(List<PostedPhoto> photos, string typeName)
		{

			IList<Photo> photosDB = new List<Photo>();

			PhotoSet photoSet = new()
			{
				Date = DateTime.Now,
				Photos = photosDB,
				PhotoSetType = db.PhotoSetTypes.FirstOrDefault(pst => pst.Type == typeName)
			};

			db.PhotoSets.Add(photoSet);
			db.SaveChanges();

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
					Path = path,
					Width = width,
					Height = height,
					PhotoSetId = db.PhotoSets.FirstOrDefault(ps => ps.Date == photoSet.Date).Id,
					PhotoSet = db.PhotoSets.FirstOrDefault(ps => ps.Date == photoSet.Date)
				};
				photosDB.Add(photoDB);
			}

			db.Photos.AddRange(photosDB);
			db.SaveChanges();
			return "OK";
		}

		[HttpGet("{id}")]
		public string Get(int id)
		{
			return Newtonsoft.Json.JsonConvert.SerializeObject(
				db.PhotoSets.Include(ps => ps.Photos).FirstOrDefault(ps => ps.Id == id),
				new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }
			);
		}

		[HttpDelete("{photoSetId}")]
		public string Delete(int photoSetId)
		{
			IList<Photo> photos = db.Photos.Where(p => p.PhotoSetId == photoSetId).ToList();
			db.Photos.RemoveRange(
                photos
			);
			foreach (Photo photo in photos)
			{
				FileManager.DeletePhoto(photo.Path);
			}

			db.PhotoSets.Remove(
				db.PhotoSets.FirstOrDefault(ps => ps.Id == photoSetId)
			);
			db.SaveChanges();
			return "OK";
		}
	}
}
