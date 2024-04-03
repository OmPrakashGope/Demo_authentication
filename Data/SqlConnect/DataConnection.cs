using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.SqlConnect
{
    public class DataConnection : IDataConnection
    {
        private readonly string connectionString;
        public DataConnection(IConfiguration config)
        {
            connectionString = config.GetConnectionString("demo_db");
        }
        public async Task<dynamic> GetData(string proc, Object parameters)
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            return connection.QueryMultipleAsync(proc, parameters, commandType: CommandType.StoredProcedure).Result;
        }

        public async Task<dynamic> InsertData<T>(string proc, Object parameters)
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            return connection.QueryAsync<T>(proc, parameters, commandType: CommandType.StoredProcedure).Result;
        }
    }
}
