using minimal_api.domain.dtos;
using minimal_api.domain.entities;
using minimal_api.domain.infrastructure.Database;
using Namespace.Domain.Interfaces;

namespace MinimalApi.domain.services
{
    public class AdminService : IAdminService
    {
        private readonly DatabaseContent _databaseContent;
        public AdminService(DatabaseContent databaseContent){
            _databaseContent = databaseContent;
        }
        public Admin? Login(LoginDto loginDto)
        {
            var validUser = _databaseContent.Admins.Where(admin => admin.Email == loginDto.Email && admin.Password == loginDto.Password).FirstOrDefault();    
            return validUser;
            
        }
    }
}