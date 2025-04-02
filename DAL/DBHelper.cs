using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MachineTest.DAL
{
	public class DBHelper
	{
        private readonly string _dbConnectionString;

        public DBHelper()
        {
            _dbConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        }
        public SqlConnection GetConnection()
        {
            return new SqlConnection(_dbConnectionString);
        }
    }
}