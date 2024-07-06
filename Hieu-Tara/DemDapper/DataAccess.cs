using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DemDapper
{
  
    public class DataAccess
    {
        private readonly string _connectingString;
        public DataAccess(string connectingString) {
            this._connectingString = connectingString;
        }
        public T QuerySingle<T, U>(string sql, U parameters)
        {
            using (IDbConnection conn = new SqlConnection(_connectingString))
            {
                return conn.QuerySingle<T>(sql, parameters);
            }
        }
        public T QueryFirst<T, U>(string sql, U parameters)
        {
            using (IDbConnection conn = new SqlConnection(_connectingString))
            {
                return conn.QueryFirst<T>(sql, parameters);
            }
        }
        public List<T> Query<T,U>(string sql, U parameters)
        {
            using (IDbConnection conn = new SqlConnection(_connectingString))
            {
                return conn.Query<T>(sql, parameters).ToList();
            }
        }
        public void ExecuteCommand<U>(string sql, U parameters)
        {
            using (IDbConnection conn = new SqlConnection(_connectingString))
            {
               conn.Execute(sql,parameters);
            }
        }
    }
}
