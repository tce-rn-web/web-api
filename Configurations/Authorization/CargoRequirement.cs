using Microsoft.AspNetCore.Authorization;

namespace api.Configurarions.Authorization {
    public class CargoRequirement : IAuthorizationRequirement {
        public int IdCargo { get; }
        public CargoRequirement(int idCargo) {
            this.IdCargo = idCargo;
        }
    }
}