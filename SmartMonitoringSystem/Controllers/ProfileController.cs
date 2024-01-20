using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using SmartMonitoringSystem.DTO;
using SmartMonitoringSystem.Interface;
using SmartMonitoringSystem.Models;

namespace SmartMonitoringSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileRepository profileRepository;
        public ProfileController(IProfileRepository profileRepository)
        {
            this.profileRepository = profileRepository;
        }
        [HttpGet("DTO")]
        public List<ProfileDTO> GetProfilesDTO()
        {
            return profileRepository.GetProfilesDto();
        }
        [HttpGet]
        public List<Profile> Get()
        {
            return profileRepository.GetProfilesWithWarrants();
        }

        [HttpGet("base")]
        public IEnumerable<Profile> BaseGet()
        {
            return profileRepository.GetAll();
        }
        [HttpPost]
        public void Post([FromBody] AddProfileDTO profileDTO)
        {
            Profile profile = new()
            {
                DateOfBirth= profileDTO.DateOfBirth,
                FamilyStatusId= profileDTO.FamilyStatusId,
                GenderId= profileDTO.GenderId,
                NationalityId= profileDTO.NationalityId,
                FullName= profileDTO.FullName,
                MotherName = profileDTO.MotherName
            };
            profileRepository.Add(profile);
            profileRepository.Save();            
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Profile profile = new() 
            { 
                ProfileId=id 
            };
            profileRepository.Delete(profile);
            profileRepository.Save();

        }
        [HttpPut()]
        public void Update(Profile profile)
        {
            profileRepository.Update(profile);
            profileRepository.Save();

        }
    }
}

