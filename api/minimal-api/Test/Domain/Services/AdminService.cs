using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using minimal_api.domain.entities;
using minimal_api.domain.infrastructure.Database;
using MinimalApi.domain.services;

namespace Test.Domain.Services;

[TestClass]
public sealed class AdminServiceTest
{
    private DatabaseContent CreateContextDatabase()
    {
        var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.test.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();

        var configuration = builder.Build();

        return new DatabaseContent(configuration);
    }

    [TestCleanup]
    public void Cleanup()
    {
        var context = CreateContextDatabase();
        context.Dispose();
    }

    [TestMethod]
    public void ToSaveAdmin()
    {
        var context = CreateContextDatabase();
        var admin = new Admin();

        admin.Id = 5;
        admin.Email = "Teste@teste.com";
        admin.Password = "teste";
        admin.Profile = "Admin";

        var adminService = new AdminService(context);
        var createdAdmin = adminService.Create(admin);

        Assert.IsNotNull(createdAdmin, "O método Create não deveria retornar nulo.");
        Assert.IsTrue(createdAdmin.Id > 0, "O ID do admin deveria ser gerado pelo banco de dados.");

        var totalAdminsInDb = context.Admins.Count();
        var adminInDb = context.Admins.Find(createdAdmin.Id);

        Assert.AreEqual(5, totalAdminsInDb, "Deveria haver exatamente 1 admin no banco de dados.");
        Assert.IsNotNull(adminInDb, "O admin não foi encontrado no banco de dados após a criação.");
        Assert.AreEqual("Teste@teste.com", adminInDb.Email);

    }
}
