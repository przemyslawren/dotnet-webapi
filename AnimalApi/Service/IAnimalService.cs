using AnimalApi.Dto;
using AnimalApi.Model;

namespace AnimalApi.Service;

public interface IAnimalService
{
    IEnumerable<Animal> GetAnimals(string orderBy);
    void AddAnimal(AnimalDto animalDto);
    void UpdateAnimal(int id, Animal animal);
    void DeleteAnimal(int id);
}