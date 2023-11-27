using CardApp.Models;

namespace CardApp.Repository;

public interface ICreditCardRepository
{
    public IEnumerable<CreditCard>GetAll();
    public CreditCard GetById(int id);
    public void AddCard(CreditCard creditCard);
    public void DeleteCard(int id);
}
