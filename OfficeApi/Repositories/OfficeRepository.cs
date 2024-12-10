using Dapper;
using Microsoft.Data.SqlClient;
using OfficeApi.Domain;
using OfficeApi.Interfaces;
using System.Data;

namespace OfficeApi.Repositories
{
    public class OfficeRepository : IOfficeRepository
    {
        readonly string _conStr;
        public OfficeRepository(string conStr)
        {
            _conStr = conStr;
        }
        public async Task<Office> CreateAsync(Office office, CancellationToken token)
        {
            string query = "INSERT INTO Offices VALUES(@Id, @City, @Street, @HouseNumber, @OfficeNumber, @RegistryPhoneNumber, @Status);";
            using (IDbConnection db = new SqlConnection(_conStr))
            {
                office.Id = Guid.NewGuid();

                db.Query(query, office);
            }
            return office;
        }

        public async Task DeleteByIdAsync(Guid id, CancellationToken token)
        {
            string query = "DELETE FROM Offices WHERE Id = '@id';";

            using (IDbConnection db = new SqlConnection(_conStr))
            {
                db.Query(query, id);
            }
        }

        public async Task<IEnumerable<Office>> GetAllAsync(CancellationToken token)
        {
            string query = "SELECT * FROM Offices;";
            IEnumerable<Office> offices;

            using (IDbConnection db = new SqlConnection(_conStr))
            {
                offices = db.Query<Office>(query);
            }
            return offices;
        }

        public async Task<Office> GetByIdAsync(Guid id, CancellationToken token)
        {
            string query = "SELECT o FROM Offices WHERE o.Id = '@Id'";
            Office office;

            using (IDbConnection db = new SqlConnection(_conStr))
            {
                office = db.Query(query, id).FirstOrDefault();
            }
            return office;
        }

        public async Task<Office> UpdateAsync(Office office, CancellationToken token)
        {
            string query = "UPDATE Offices SET City = @City, Street = @Street, HouseNumber = @HouseNumber, OfficeNumber = @OfficeNumber, RegistryPhoneNumber = @RegistryPhoneNumber WHERE Id = @Id";

            using (IDbConnection db = new SqlConnection(_conStr))
            {
                db.Query(query, office);
            }
            return office;
        }
    }
}
