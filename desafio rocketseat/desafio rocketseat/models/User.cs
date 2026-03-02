namespace desafio_rocketseat.models;

public class User
{
    public string? Name { get; set; }
    public string? LasName { get; set; }

    public User(string? name, string? lasName)
    {
        Name = name;
        LasName = lasName;
    }

    public void SetFullName()
    {
        Console.WriteLine(Name + " " + LasName);
    }
}