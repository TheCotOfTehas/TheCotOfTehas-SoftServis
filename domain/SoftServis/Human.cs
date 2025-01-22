namespace SoftServis;

public class Human : IHuman
{
    public string Name { get; set; }
    public string SurName { get; set; }
    public string Patronymic { get; set; }
    public Human()
    {
        Name = string.Empty;
        SurName = string.Empty;
        Patronymic = string.Empty;
    }

    public Human(string name):this()
    {
        Name = name;
    }

    public Human(string name, string surName):this(name)
    {
        SurName = surName;
    }

    public Human(string name, string surName, string patronymic) : this(name, surName)
    {
        SurName = surName;
    }
}
