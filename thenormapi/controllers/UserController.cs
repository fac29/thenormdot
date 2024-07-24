using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using domain.interfaces;

namespace thenormapi.controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<IUser>> GetAllUsers()
    {
        var users = _userRepository.GetAllUsers();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public ActionResult<IUser> GetUser(Guid id)
    {
        var user = _userRepository.GetUserById(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPost]
    public ActionResult<IUser> CreateUser([FromBody] IUser user)
    {
        if (user == null)
        {
            return BadRequest();
        }

        _userRepository.AddUser(user);
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(Guid id, [FromBody] IUser user)
    {
        if (user == null || id != user.Id)
        {
            return BadRequest();
        }

        var existingUser = _userRepository.GetUserById(id);
        if (existingUser == null)
        {
            return NotFound();
        }

        _userRepository.UpdateUser(user);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(Guid id)
    {
        var user = _userRepository.GetUserById(id);
        if (user == null)
        {
            return NotFound();
        }

        _userRepository.RemoveUser(user);
        return NoContent();
    }
}