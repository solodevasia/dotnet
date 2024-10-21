using simple_dotnet.Models;

namespace simple_dotnet.Repositories {
  public class UserRepository {
    public static List<UserModel> lists = new List<UserModel>() {
      new UserModel {id = 1, username = "Pickahu", email = "Pickahu@yahoo.com" },
      new UserModel {id = 2, username = "Doraemon", email = "Doraemon@yahoo.com" }
    };

    public static List<UserModel> find() {
      return lists;
    }

    public static UserModel findOne(int id) {
      return lists.FirstOrDefault(item => item.id == id);
    }
  }
}
