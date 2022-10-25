using Entities;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace BoxAPI.Controllers;

[ApiController]
[Route("[Controller]")]
public class BoxController : ControllerBase
{

    private BoxesRepository _boxesRepository;
    private BoxValidator _boxValidator;
    public BoxController(BoxesRepository repository)
    {
        _boxesRepository = repository;
        _boxValidator = new BoxValidator();
    }


    [HttpGet]
    public List<Boxes> GetBoxes()
    {
        return _boxesRepository.getAllBoxes();
    }

    // has the same "Http" so we need ti out it inside a route.
    [HttpGet]
    [Route("CreateDb")]
    public string CreateDb()
    {   
        _boxesRepository.CreateDB();
        return "db has been created";
    }

    [HttpPost]
    public ActionResult AddBoxes(Boxes boxes)
    {   
        // the local variable "validation" is there to make sure the boxes obj is a valid obj.
        var validation = _boxValidator.Validate(boxes).IsValid;
        // if the validation is true, it will create the box and insert into the dp and return a OK request
        if (validation)
        {
            return Ok(_boxesRepository.InsertProduct(boxes));
        }
        // else it will return a "BadRequest" along with what the issues was.
        return BadRequest(validation.ToString());

    }

    [HttpDelete]
    [Route("{Id}")]
    public void DeleteSuperHero(int id)
    {
        _boxesRepository.DeleteBoxes(id);
    }

    [HttpPut]
    public ActionResult<Boxes> Updateboxes([FromBody] Boxes boxToUpdate)
    {
        try
        {
            return Ok(_boxesRepository.UpdateBoxes(boxToUpdate));
        }
        catch (Exception e)
        {
            return BadRequest("failed to update body");
        }
    }

}