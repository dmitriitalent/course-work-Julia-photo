using JuliaPhotoServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Newtonsoft.Json;

namespace JuliaPhotoServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        public DatabaseContext db;
        public IHostEnvironment env;

        public AboutController(
            IHostEnvironment _env,
            DatabaseContext _db
        )
        {
            db = _db;
            env = _env;
        }

        [HttpGet]
        public string Get()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(
                db.Abouts.Include(a => a.Photo).ToList(),
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }
            );
        }

        [HttpPost]
        public string Post(PostedAbout pa) 
        {
            About about = new About()
            {
                Article = pa.Article,
                Text = pa.Text,
                PhotoId = db.Photos.FirstOrDefault(p => p.Filename == pa.PhotoName)?.Id,
                Photo = db.Photos.FirstOrDefault(p => p.Filename == pa.PhotoName)
            };
            db.Abouts.Add(about);
            db.SaveChanges();

            return "OK";
        }
        [HttpDelete("{AboutId}")]
        public void Delete(int AboutId)
        {
            if (db.Abouts.Include(a => a.Photo).FirstOrDefault(a => a.Id == AboutId).PhotoId != null) {
                FileManager.DeletePhoto(db.Abouts.Include(a => a.Photo).FirstOrDefault(a => a.Id == AboutId).Photo?.Path);
                db.Photos.Remove(db.Abouts.Include(a => a.Photo).FirstOrDefault(a => a.Id == AboutId).Photo);
            }
            db.Abouts.Remove(db.Abouts.FirstOrDefault(a => a.Id == AboutId));
            db.SaveChanges();
        }

        [Route("edit")]
        [HttpPost]
        public void Edit(PostedAbout item)
        {
            About itemDB = db.Abouts.FirstOrDefault(a => a.Id == item.Id);
            itemDB.Text = item.Text;
            itemDB.Article = item.Article;
            db.SaveChanges();
        }
    }
    public class PostedAbout
    {
        public int? Id { get; set; }
        public string Article { get; set; }
        public string Text { get; set; }
        public string PhotoName { get; set; }
    }
}
