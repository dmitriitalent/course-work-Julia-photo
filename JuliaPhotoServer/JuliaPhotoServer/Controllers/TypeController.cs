using JuliaPhotoServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace JuliaPhotoServer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TypeController : ControllerBase
	{
		DatabaseContext db;
		public TypeController(DatabaseContext _db)
		{
			db = _db;
		}

		[HttpGet]
		public string Get() {
			return Newtonsoft.Json.JsonConvert.SerializeObject(
				db.PhotoSetTypes.Include(pst => pst.PhotoSets).ThenInclude(ps => ps.Photos).ToList(),
				new JsonSerializerSettings {
					ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
				}
			);
		}

		[HttpPost]
		public string Post(PostedType item)
		{
			PhotoSetType pst = new PhotoSetType()
			{
				Description = item.Description,
				Type = item.Type,
				PhotoSets = new List<PhotoSet>()
			};

			db.PhotoSetTypes.Add(pst);
			db.SaveChanges();
			return "OK";
		}
        
        [HttpDelete("{TypeId}")]
        public void Delete(int TypeId)
        {
            db.PhotoSetTypes.Remove(db.PhotoSetTypes.FirstOrDefault(pst => pst.Id == TypeId));
            db.SaveChanges();
        }

        [Route("edit")]
        [HttpPost]
        public void Edit(PostedType item)
        {
            PhotoSetType itemDB = db.PhotoSetTypes.FirstOrDefault(pst => pst.Id == item.Id);
            itemDB.Type = item.Type;
            itemDB.Description = item.Description;
            db.SaveChanges();
        }
    }

	public class PostedType
	{
		public int Id { get; set; }
		public string Type { get; set; }
		public string Description { get; set; }
	}
}
