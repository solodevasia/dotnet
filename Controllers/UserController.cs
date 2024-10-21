using simple_dotnet.Models;
using simple_dotnet.Repositories;
using simple_dotnet.Services;
using simple_dotnet.Filters;
using Microsoft.AspNetCore.Mvc;

namespace simple_dotnet.Controllers {
  [ApiController]
  [Route("api/")]
  public class UserController: ControllerBase { 
    private readonly UserService userService = new UserService();

    [HttpPost]
    [Route("login/access")]
    public string LoginAccess() {
      return "Login Access";
    }

    [HttpPost]
    [Route("user")]
    public string Created([FromBody] UserModel body) {
      return userService.created(body);
    }

    [HttpPost]
    [Route("user/update/{id}")]
    public string UpdateUser(int id) {
      return $"Account {id} has been updated";
    }

    [HttpGet]
    [Route("user")]
    public List<UserModel> All() {
      return UserRepository.find();
    }

    [HttpGet]
    [UserFilter]
    [Route("user/{id}")]
    public UserModel? Detail(int id) {
      return UserRepository.findOne(id);
    }

    [HttpPut]
    [Route("user/{id}")]
    public string Updated(int id, [FromBody] UserModel body) {
      return userService.updated(id, body);
    }

    [HttpDelete]
    [Route("user/{id}")]
    public string Destroy(int id) {
      return userService.destroy(id);
    } 
  }
}
