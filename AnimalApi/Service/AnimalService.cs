using AnimalApi.Dto;
using AnimalApi.Model;
using AnimalApi.Repository;

namespace AnimalApi.Service;

public class AnimalService(IAnimalRepository animalRepository) : IAnimalService
{
    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        string orderByValidated = ValidateOrderBy(orderBy);
        IEnumerable<Animal> animals = animalRepository.GetAnimals(orderByValidated);
        return animals;
    }

    public void AddAnimal(AnimalDto animalDto)
    {
        animalRepository.AddAnimal(animalDto);
    }

    public void UpdateAnimal(int id, Animal animal)
    {
        if(!animalRepository.AnimalIdExists(id))
        {
            throw new ArgumentException("Animal with given id does not exist");
        }
        animal.Id = id;
        animalRepository.UpdateAnimal(animal);
    }

    public void DeleteAnimal(int id)
    {
        animalRepository.DeleteAnimal(id);
    }
    
    private string ValidateOrderBy(string orderBy)
    {
        if(orderBy == null)
        {
            return "Please provide orderBy parameter";
        }
        if (orderBy != "name" && orderBy != "category" && orderBy != "description" && orderBy != "area")
        {
            throw new ArgumentException("Invalid orderBy parameter");
        }
        return orderBy;
    }
}