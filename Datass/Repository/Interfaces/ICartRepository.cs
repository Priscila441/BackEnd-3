using Models.Entity;


namespace Datass.Repository.Interfaces
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        Task<Cart?> GetActiveCartAsync();

    }
}
