using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace api.Configurarions.Authorization {
    public class CargoRequirementHandler : AuthorizationHandler<CargoRequirement> {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, 
            CargoRequirement requirement
        ) {
            if(context.User.HasClaim(c => c.Type == "CargoId")) {
                int cargoId = int.Parse(context.User
                    .FindFirst(c => c.Type == "CargoId")
                    .Value
                );

                if(cargoId == requirement.CargoId)
                    context.Succeed(requirement);
                else
                    context.Fail();
            }
            else
                context.Fail();

            return Task.FromResult(0);
        }
    }
}