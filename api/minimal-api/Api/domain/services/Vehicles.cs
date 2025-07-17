
using System.Security.Cryptography.X509Certificates;
using minimal_api.domain.entities;
using minimal_api.domain.infrastructure.Database;
using minimal_api.domain.interfaces;
using minimal_api.Migrations;

namespace MinimalApi.domain.services
{
    public class VehicleService : IVehicleService
    {
        private readonly DatabaseContent _databaseContent;
        public VehicleService(DatabaseContent databaseContent)
        {
            _databaseContent = databaseContent;
        }

        public List<Vehicle> AllVehicles(int? page, string? name = null, string? mark = null)
        {
            var vehicles = _databaseContent.Vehicles.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                vehicles = vehicles.Where(vehicle => vehicle.Name.ToLower().Contains(name.ToLower()));
            }

            if (!string.IsNullOrEmpty(mark))
            {
                vehicles = vehicles.Where(vehicle => vehicle.Mark.ToLower().Contains(mark.ToLower()));
            }

            int pageSize = 10;
            if (page != null)
            {

                vehicles = vehicles.Skip(((int)page - 1) * pageSize).Take(pageSize);
            }

            return vehicles.ToList();
        }

        public void DeleteVehicle(Vehicle vehicle)
        {
            _databaseContent.Remove(vehicle);
            _databaseContent.SaveChanges();
        }

        public Vehicle? GetVehicle(int id)
        {
            var findVehicle = _databaseContent.Vehicles.Where(vehicle => vehicle.Id == id).FirstOrDefault();
            return findVehicle;
        }

        public void IncludeVehicle(Vehicle vehicle)
        {
            _databaseContent.Add(vehicle);
            _databaseContent.SaveChanges();
        }

        public void IncludeVehicles(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            _databaseContent.Update(vehicle);
            _databaseContent.SaveChanges();
        }
    }
}