namespace Unlocker.Domain.Contact.Entities;

public class Contact
{
    public int Id { get; private set; }
    public string Name { get; private set; } = null!;
    public string Phone { get; private set; } = null!;
    public bool Active { get; private set; }

    protected Contact() { }

    public Contact(string name, string phone)
    {
        Name = name;
        Phone = phone;
        Active = true;
    }
    public void Disable() => Active = false;
}