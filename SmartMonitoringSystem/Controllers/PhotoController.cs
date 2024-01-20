using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartMonitoringSystem.Interface;
using SmartMonitoringSystem.Models;

namespace SmartMonitoringSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoRepository photoRepository;
        public PhotoController(IPhotoRepository photoRepository)
        {
            this.photoRepository = photoRepository;
        }
        [HttpGet]
        public IEnumerable<Photo> Get()
        {
            return photoRepository.GetAll();
        }

        [HttpPost]
        public void Post([FromBody] Photo photo)
        {
            photoRepository.Add(photo);
            photoRepository.Save();
        }
    }
}
