using AnimalApi.Dto;
using Microsoft.AspNetCore.Mvc;
using AnimalApi.Model;
using AnimalApi.Service;

namespace AnimalApi.Controller;

[Route("api/animals")]
[ApiController]
public class AnimalController(IAnimalService animalService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAnimals([FromQuery] string orderBy="name")
    {
        var animals = animalService.GetAnimals(orderBy);
        return Ok(animals);
    }
    
    [HttpPost]
    public IActionResult AddAnimal(AnimalDto animalDto)
    {
        animalService.AddAnimal(animalDto);
        return StatusCode((StatusCodes.Status201Created));
    }
    
    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, [FromBody] Animal animal)
    {
        animalService.UpdateAnimal(id, animal);
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        animalService.DeleteAnimal(id);
        return NoContent();
    }
}