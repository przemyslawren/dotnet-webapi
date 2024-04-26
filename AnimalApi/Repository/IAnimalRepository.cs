using AnimalApi.Dto;
using AnimalApi.Model;

namespace AnimalApi.Repository;

public interface IAnimalRepository
{
    IEnumerable<Animal> GetAnimals(string orderBy);
    void AddAnimal(AnimalDto animalDto);
    void UpdateAnimal(Animal animal);
    void DeleteAnimal(int id);
    bool AnimalIdExists(int id);
    
}