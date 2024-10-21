using simple_dotnet.Repositories;
using simple_dotnet.Models;

namespace simple_dotnet.Services {
  public class UserService {

    public string created(UserModel body) {
      var exist = UserRepository.lists.FirstOrDefault(item => 
          item.username == body.username ||
          item.email == body.email
      );
      if(exist != null) {
        return "Username or email address already exists";
      }
      body.id = UserRepository.lists.Count + 1;
      UserRepository.lists.Add(body);
      return "Account has been created";
    }

    public string updated(int id, UserModel body) {
      var findOne = UserRepository.findOne(id);
      var exist = UserRepository.lists.FirstOrDefault(item => 
          item.username == body.username ||
          item.email == body.email
      );
      if(exist != null) {
        return "Username or email address already exists";
      }
      findOne.username = body.username;
      findOne.email = body.email;
      return "Account has been updated";
    }

    public string destroy(int id) {
      var exist = UserRepository.lists.FirstOrDefault(item => item.id == id);
      if(exist == null) {
        return "Account not found";
      }
      UserRepository.lists.Remove(exist);
      return "Account has been deleted";
    }
  }
}
