using simple_dotnet.Validations;

namespace simple_dotnet.Models {
  public class UserModel {
    public int id {get; set;}
    public string username {get; set;}
    [EmailValidation]
    public string email {get; set;}
  }
}
