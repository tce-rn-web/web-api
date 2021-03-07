using Microsoft.AspNetCore.Authorization;

namespace api.Configurarions.Authorization {
    public class CargoRequirement : IAuthorizationRequirement {
        public int CargoId { get; }
        public CargoRequirement(int cargoId) {
            this.CargoId = cargoId;
        }
    }
}