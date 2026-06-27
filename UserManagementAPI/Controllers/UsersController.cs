using Microsoft.AspNetCore.Mvc;
using
    UserManagementAPI.Models;
namespace UserManagementAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    // Temp in memory Db
    private static readonly List<User> _users = new();

    [HttpGet]
    public ActionResult<IEnumerable<User>> GetAllUsers(int id)
    {
        return Ok(_users);
        }

    [HttpGet("{id}")]
    public ActionResult<User> GetUserById(int id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();
            return Ok(user);
    }

    [HttpPost]
    public ActionResult<User> CreateUser(User newUser)
    {
        newUser.Id = _users.Count > 0 ? _users.Max(u => u.Id) + 1 : 1;
        _users.Add(newUser);
        return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateUser(int id, User updatedUser)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user == null) return NotFound();

        user.FirstName = updatedUser.FirstName;
        user.LastName = updatedUser.LastName;
        user.Email = updatedUser.Email;
        user.Department = updatedUser.Department;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteUser(int id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user == null) return NotFound();

        _users.Remove(user);

        return NoContent();
    }
    
}