using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Dapper
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration; // Reads appsettings.json
        private readonly string _connectionString;     // Stores DB connection string

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        // Creates PostgreSQL database connection
        public IDbConnection CreateConnection()
            => new NpgsqlConnection(_connectionString);
    }
}
