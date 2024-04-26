using System.Data.SqlClient;
using AnimalApi.Dto;
using AnimalApi.Model;

namespace AnimalApi.Repository;

public class AnimalRepository(IConfiguration configuration) : IAnimalRepository
{
    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        using var con = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        con.Open();
        var command = new SqlCommand($"SELECT * FROM Animal ORDER BY {orderBy}", con);
        var reader = command.ExecuteReader();
        var animals = new List<Animal>();
        while (reader.Read())
        {
            animals.Add(new Animal(
                reader.GetInt32(0),
                reader.IsDBNull(1) ? null : reader.GetString(1),
                reader.IsDBNull(2) ? null : reader.GetString(2),
                reader.IsDBNull(3) ? null : reader.GetString(3),
                reader.IsDBNull(4) ? null : reader.GetString(4)
            ));
        }
        con.Close();
        return animals;
    }

    public void AddAnimal(AnimalDto animalDto)
    {
        using var con = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        con.Open();
        var command = new SqlCommand("INSERT INTO Animal VALUES (@name, @description, @category, @area)", con);
        command.Parameters.AddWithValue("@name", animalDto.Name);
        command.Parameters.AddWithValue("@description", animalDto.Description);
        command.Parameters.AddWithValue("@category", animalDto.Category);
        command.Parameters.AddWithValue("@area", animalDto.Area);
        command.ExecuteNonQuery();
        con.Close();
    }

    public void UpdateAnimal(Animal animal)
    {
        using var con = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        con.Open();
        var command = new SqlCommand("UPDATE Animal SET Name = @name, Description = @description, Category = @category, Area = @area WHERE IdAnimal = @id", con);
        command.Parameters.AddWithValue("@name", animal.Name);
        command.Parameters.AddWithValue("@description", animal.Description);
        command.Parameters.AddWithValue("@category", animal.Category);
        command.Parameters.AddWithValue("@area", animal.Area);
        command.Parameters.AddWithValue("@id", animal.Id);
        command.ExecuteNonQuery();
        con.Close();
    }

    public void DeleteAnimal(int id)
    {
        using var con = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        con.Open();
        var command = new SqlCommand("DELETE FROM Animal WHERE IdAnimal = @id", con);
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
        con.Close();
    }
    
    public bool AnimalIdExists(int id)
    {
        using var con = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        con.Open();
        var command = new SqlCommand("SELECT COUNT(*) FROM Animal WHERE IdAnimal = @id", con);
        command.Parameters.AddWithValue("@id", id);
        var count = (int) command.ExecuteScalar();
        con.Close();
        return count > 0;
    }
}