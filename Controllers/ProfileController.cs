using Microsoft.AspNetCore.Mvc;
using TattooBackend.Models;
using TattooBackend.Services;

namespace TattooBackend.Controllers;


[ApiController]
[Route("api/[Controller]")]
public class ProfileController : ControllerBase {

    private readonly ProfileService _profileService;

    public ProfileController(ProfileService profileService) => _profileService = profileService;

    [HttpPost]
    public async Task<IActionResult> Post(Profile newProfile)
    {
        await _profileService.CreateAsync(newProfile);

        return CreatedAtAction(nameof(Get), new { id = newProfile.ID }, newProfile);
    }

    [HttpGet]
    public async Task<List<Profile>> Get(){
        return await _profileService.GetAsync();
    }

    [HttpGet("{id}")]
    public async Task<Profile> GetByUser(string id){
        return await _profileService.GetByUser(id);
    }

}