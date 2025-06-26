using minimal_api.domain.entities;

namespace Test.Domain.Entities;

[TestClass]
public sealed class AdminEntityTest
{
    [TestMethod]
    public void GetSetPropertiesTest()
    {
        //Arrange
        var admin = new Admin();

        admin.Id = 3;
        admin.Email = "mathesuteste@teste.com";
        admin.Password = "teste123.43";
        admin.Profile = "Admin";

        //Assert
        Assert.AreEqual(3, admin.Id);
        Assert.AreEqual("mathesuteste@teste.com", admin.Email);
        Assert.AreEqual("teste123.43", admin.Password);
        Assert.AreEqual("Admin", admin.Profile);

    }
}
