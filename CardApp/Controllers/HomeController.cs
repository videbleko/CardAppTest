using CardApp.DTO;
using CardApp.Models;
using CardApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CardApp.Controllers;

public class HomeController : Controller
{
    private readonly CreditCardRepository _repo;

    public HomeController(CreditCardRepository repo)
    {
        _repo = repo;   
    }

    [HttpGet]
    public IActionResult List()
    {
        var creditcards = _repo.GetAll();
        var cc = creditcards.Select(c => new

            CreditCardDTO
        {
            Id = c.Id,
            CardNumber = c.CardNumber,
            CardName = c.CardName,
            ExpirationDate = c.ExpirationDate,
            CVV = c.CVV
        }).ToList();

        return View("List",cc);
    }

    public IActionResult Index()
    {
        return View();
    }  
    
    public IActionResult IndexHome()
    {
        return View("Index");
    } 


    [HttpPost]
    public IActionResult Index(CreditCardDTO creditCard)
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
            return RedirectToAction("List");
        }
        return View(creditCard);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var creditCard = _repo.GetById(id);

        if(creditCard == null)
            return NotFound();
        var creditCardDto = new CreditCardDTO()
        {
            CardNumber = creditCard.CardNumber,
            CardName = creditCard.CardName,
            ExpirationDate = creditCard.ExpirationDate,
            CVV = creditCard.CVV
        };
        return View(creditCardDto);

    }

    [HttpPost]
    public IActionResult Edit(CreditCardDTO creditCardDTO)
    {
        if (ModelState.IsValid)
        {
            var existingCreditCard = _repo.GetById(creditCardDTO.Id);

            if (existingCreditCard == null)
            {
                return NotFound();
            }

            existingCreditCard.CardNumber = creditCardDTO.CardNumber;
            existingCreditCard.CardName = creditCardDTO.CardName;
            existingCreditCard.ExpirationDate = creditCardDTO.ExpirationDate;
            existingCreditCard.CVV = creditCardDTO.CVV;

            _repo.EditCard(existingCreditCard);
            return RedirectToAction("List");
        }
        return View(creditCardDTO);
    }
    public IActionResult Delete(int id)
    {
        var creditCard = _repo.GetById(id);

        if (creditCard == null)
            return NotFound();

        var creditCardDto = new CreditCardDTO()
        {
            CardNumber = creditCard.CardNumber,
            CardName = creditCard.CardName,
            ExpirationDate = creditCard.ExpirationDate,
            CVV = creditCard.CVV
        };
        return View(creditCardDto);

    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteCardConfirm(int id)
    {
        _repo.DeleteCard(id);
        return RedirectToAction("List");
    }

}
