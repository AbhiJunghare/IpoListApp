namespace IpoList
{
    using Dapper;
    using IpoList.Models;
    using System.Collections.Generic;
    using Microsoft.Data.SqlClient;
    using System.Threading.Tasks;
    using System.Data;

    public class IpoRepository
    {
        private readonly string _connectionString;

        public IpoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<IpoModel>> GetAllIposAsync()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var parameters = new { @FLAG = "Get" };
                    return await db.QueryAsync<IpoModel>("USP_IPO_CRUD_OP", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw;

            }
        }

        public async Task AddIpoDetailAsync(IpoModel ipo)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var parameters = new
                    {
                        @FLAG = "ADD",
                        ipo.StockName,
                        ipo.ListingPrice,
                        ipo.ListingDate
                    };

                    await db.ExecuteAsync("USP_IPO_CRUD_OP", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception EX)
            {
                throw;
                
            }
        }
        public async Task EditIpoDetailAsync(IpoModel ipo)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var parameters = new
                    {
                        @FLAG = "UPDATE",
                        ipo.StockName,
                        ipo.ListingPrice,
                        ipo.ListingDate,
                        ipo.Id
                    };

                    await db.ExecuteAsync("USP_IPO_CRUD_OP", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IpoModel> GetIpoByIdAsync(int id)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var parameters = new { Id = id, FLAG = "EDIT" };

                    var ipo = await db.QuerySingleOrDefaultAsync<IpoModel>("USP_IPO_CRUD_OP", parameters, commandType: CommandType.StoredProcedure);
                    return ipo;
                }
            }
            catch (Exception EX)
            {
                throw;

            }
        }

        public async Task DeleteIpoAsync(int id)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var parameters = new { @Id = id, FLAG = "DELETE" };
                    await db.ExecuteAsync("USP_IPO_CRUD_OP", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw;
                
            }
        }


    }
}
