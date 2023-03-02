using Microsoft.AspNetCore.Mvc;
using TattooBackend.Models;
using TattooBackend.Services;

namespace TattooBackend.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class UserController : ControllerBase {

    private readonly UserService _userService;

    public UserController(UserService userService) => _userService = userService; 

    [HttpPost]
    public async Task<IActionResult> Post(User newUser)
    {
        await _userService.CreateAsync(newUser);

        return CreatedAtAction(nameof(Get), new { id = newUser.ID }, newUser);
    }

    [HttpGet(Name = "GetAllUsers")]
    public async Task<List<User>> Get() {
        return await _userService.GetAsync(); 
    }

}