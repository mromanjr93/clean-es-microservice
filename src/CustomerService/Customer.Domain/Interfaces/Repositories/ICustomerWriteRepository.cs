using System.Threading.Tasks;

namespace Customer.Domain.Interfaces.Repositories
{
    public interface ICustomerWriteRepository
    {
        Task AddAsync(Entities.Customer customer);

        Task UpdateAsync();
    }
}
