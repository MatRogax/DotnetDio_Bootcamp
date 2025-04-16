using minimal_api.domain.dtos;
using minimal_api.domain.entities;

namespace Namespace.Domain.Interfaces;

public interface IAdminService
{
    Admin? Login(LoginDto loginDto);
    Admin? Create(Admin admin);
    List<Admin> AllAdmins(int? page);
    Admin? FindById(int id);

}