using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartMonitoringSystem.Interface;
using SmartMonitoringSystem.Models;
using SmartMonitoringSystem.Repositories;

namespace SmartMonitoringSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeywordController : ControllerBase
    {
        private readonly IKeywordRepository keywordRepository;
        public KeywordController(IKeywordRepository keywordRepository)
        {
            this.keywordRepository = keywordRepository;
        }
        [HttpGet]
        public IEnumerable<Keyword> Get()
        {
            return keywordRepository.GetAll();
        }

        [HttpPost]
        public void Post([FromBody] Keyword keyword)
        {
            keywordRepository.Add(keyword);
            keywordRepository.Save();
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Keyword keyword = new()
            {
                KeywordId = id
            };
           
            keywordRepository.Delete(keyword);
            keywordRepository.Save();
        }
    }
}
