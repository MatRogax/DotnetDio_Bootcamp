using minimal_api.domain.entities;

namespace minimal_api.domain.interfaces
{
    public interface IVehicleService
    {
        List<Vehicle> AllVehicles(int page, string? name = null, string? mark = null);
        Vehicle? GetVehicle(int id);
        void IncludeVehicle(Vehicle vehicle);
        void UpdateVehicle(Vehicle vehicle);
        void DeleteVehicle(Vehicle vehicle);

    }
}