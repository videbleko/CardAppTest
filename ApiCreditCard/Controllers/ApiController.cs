using Azure.Core;
using CardApp.DTO;
using CardApp.Models;
using CardApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiCreditCard.Controllers;

public class ApiController : ControllerBase
{

    private readonly CreditCardRepository _repo;

    public ApiController(CreditCardRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    [Route("/get")]
    public ActionResult<IEnumerable<CreditCardDTO>> Index()
    {
        var creditcards = _repo.GetAll();
        var cc = creditcards.Select(c => new CreditCardDTO
        {
            Id = c.Id,
            CardNumber = c.CardNumber,
            CardName = c.CardName,
            ExpirationDate = c.ExpirationDate,
            CVV = c.CVV
        }).ToList();

        if (cc.Any())
        {
            return Ok(cc); // Devuelve la lista de CreditCardDTO con código de estado 200 OK
        }
        else
        {
            return NoContent(); // Devuelve código de estado 204 No Content si no hay elementos
        }
    }



    [HttpGet("/get/{id}")]
    public ActionResult<CreditCardDTO> GeftById(int id)
    {
        var creditCard = _repo.GetById(id);
        if (creditCard == null)
            return NotFound("Registro no encontrado");        
          else return Ok(creditCard);     
    }

    [HttpPut("/get/{id}")]
    public IActionResult Update(int id, [FromBody] CreditCardDTO creditCardDto)
    {
        var existingCreditCard = _repo.GetById(id);

        if (existingCreditCard == null)
            return NotFound("Registro no encontrado");
        if (ModelState.IsValid)
        {
            existingCreditCard.CardNumber = creditCardDto.CardNumber;
            existingCreditCard.CardName = creditCardDto.CardName;
            existingCreditCard.ExpirationDate = creditCardDto.ExpirationDate;
            existingCreditCard.CVV = creditCardDto.CVV;

            _repo.EditCard(existingCreditCard);

            return Ok(existingCreditCard);
        }
        else
        {
            return BadRequest(ModelState);
        }
    }



    [HttpPost]
    [Route("create")]
    public IActionResult Index([FromBody] CreditCardDTO creditCard)
    {
        if (ModelState.IsValid)
        {
            var cc = new CreditCard()
            {

                CardNumber = creditCard.CardNumber,
                CardName = creditCard.CardName,
                ExpirationDate = creditCard.ExpirationDate,
                CVV = creditCard.CVV
            };
            _repo.AddCard(cc);
            return Ok(cc);
        }
        return BadRequest(ModelState);
    }

    [HttpDelete]
    [Route("/get/{id}")]
    public IActionResult Delete(int id)
    {
        var creditCard = _repo.GetById(id);

        if (creditCard == null)
            return NotFound("Registro no encontrado");

        _repo.DeleteCard(id);
        return Ok(creditCard);
    }
}
