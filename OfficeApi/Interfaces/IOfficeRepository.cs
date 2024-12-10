using OfficeApi.Domain;

namespace OfficeApi.Interfaces
{
    public interface IOfficeRepository
    {
        Task<Office> GetByIdAsync(Guid id, CancellationToken token);
        Task<IEnumerable<Office>> GetAllAsync(CancellationToken token);
        Task<Office> CreateAsync(Office office, CancellationToken token);
        Task<Office> UpdateAsync(Office office, CancellationToken token);
        Task DeleteByIdAsync(Guid id, CancellationToken token);
    }
}
