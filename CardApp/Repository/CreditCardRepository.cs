using CardApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CardApp.Repository;

public class CreditCardRepository : ICreditCardRepository
{

    private readonly CardAppContext _db;

    public CreditCardRepository(CardAppContext db)
    {
        _db = db;
    }
    public IEnumerable<CreditCard> GetAll()
    {
        return _db.CreditCards.ToList();
    }

    public CreditCard GetById(int id)
    {
        var creditCard = _db.CreditCards.FirstOrDefault(cc => cc.Id == id);

        if (creditCard != null)
        {
            return creditCard;
        }

        return null;
    }

    public void AddCard(CreditCard creditCard)
    {
        _db.CreditCards.Add(creditCard);
        _db.SaveChanges();
    }

    public void EditCard(CreditCard creditCard)
    {
        _db.CreditCards.Update(creditCard);
        _db.SaveChanges();
    }

    public void DeleteCard(int id)
    {
        var creditCard = _db.CreditCards.Find(id);

        if (creditCard != null)
        {
            _db.CreditCards.Remove(creditCard);
            _db.SaveChanges();
        }
    }
}
