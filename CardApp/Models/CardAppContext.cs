using Microsoft.EntityFrameworkCore;

namespace CardApp.Models;

public class CardAppContext: DbContext
{
    public CardAppContext(DbContextOptions<CardAppContext> context) : base(context) { }

    public DbSet<CreditCard> CreditCards => Set<CreditCard>();
}