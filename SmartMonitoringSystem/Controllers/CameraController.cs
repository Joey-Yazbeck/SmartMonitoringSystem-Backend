using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartMonitoringSystem.Interface;
using SmartMonitoringSystem.Models;

namespace SmartMonitoringSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CameraController : ControllerBase
    {
        private readonly ICameraRepository cameraRepository;
        public CameraController(ICameraRepository cameraRepository)
        {
            this.cameraRepository = cameraRepository;
        }
        [HttpGet]
        public IEnumerable<Camera> Get()
        {
            return cameraRepository.GetAll();
        }

        [HttpPost]
        public void Post([FromBody] Camera camera)
        {
            cameraRepository.Add(camera);
            cameraRepository.Save();
        }
    }
}
