using minimal_api.domain.dtos;
using minimal_api.domain.entities;
using minimal_api.domain.infrastructure.Database;
using Namespace.Domain.Interfaces;

namespace MinimalApi.domain.services
{
    public class AdminService : IAdminService
    {
        private readonly DatabaseContent _databaseContent;
        public AdminService(DatabaseContent databaseContent)
        {
            _databaseContent = databaseContent;
        }

        public List<Admin> AllAdmins(int? page)
        {
            const int pageSize = 10;
            var adminsQuery = _databaseContent.Admins.AsQueryable();

            if (page.HasValue && page > 0)
            {
                adminsQuery = adminsQuery
                    .Skip((page.Value - 1) * pageSize)
                    .Take(pageSize);
            }

            return adminsQuery.ToList();
        }


        public Admin? Create(Admin admin)
        {
            _databaseContent.Add(admin);
            _databaseContent.SaveChanges();

            return admin;
        }

        public Admin? FindById(int id)
        {
            var admin = _databaseContent.Admins.Where(admin => admin.Id == id).FirstOrDefault();
            return admin;

        }

        public Admin? Login(LoginDto loginDto)
        {
            var validUser = _databaseContent.Admins.Where(
                admin => admin.Email == loginDto.Email &&
                admin.Password == loginDto.Password)
                .FirstOrDefault();

            return validUser;

        }

    }
}