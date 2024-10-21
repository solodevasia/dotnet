using System;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using simple_dotnet.Models;

namespace simple_dotnet.Validations {
  public class EmailValidation: ValidationAttribute {
    protected override ValidationResult? IsValid(object? values, ValidationContext validationContext) {
      var inputs = validationContext.ObjectInstance as UserModel;
      Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
      Console.Write(regex.IsMatch(inputs.email));
      if(regex.IsMatch(inputs.email) == false) {
        return new ValidationResult("Invalid email address");
      }
      return ValidationResult.Success;
    }
  }
}
