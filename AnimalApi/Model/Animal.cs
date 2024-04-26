namespace AnimalApi.Model;

public class Animal(int id, string name, string? description, string? category, string? area)
{
    public int Id {get => id; set => id = value; }
    public string Name {get => name; set => name = value;}
    public string? Description {get => description; set => description = value;}
    public string? Category {get => category; set => category = value;}
    public string? Area {get => area; set => area = value;}
}