using simple_dotnet.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace simple_dotnet.Filters {
  public class UserFilter: ActionFilterAttribute {

    public override void OnActionExecuting(ActionExecutingContext context) {
      base.OnActionExecuting(context);
      var inputs = context.ActionArguments["id"] as int?;
      var exist = UserRepository.findOne(inputs.Value);
      if(exist == null) {
        context.ModelState.AddModelError("message", "Account not found");
        context.Result = new BadRequestObjectResult(new {message = context.ModelState["message"].Errors[0]});
      }
    }
  }
}
