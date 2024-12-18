using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common_Helper.AppCode
{
    public class CommonConnectionHelper
    {
        protected CommonConnectionHelper()
        { }
        public static IDbConnection GetCommonDbConnection()
        {
            IDbConnection connection = new SqlConnection
            {
                ConnectionString = GetCommonMasterConnectionString()
            };
            return connection;
        }

        [return: MaybeNull]
        public static string GetCommonMasterConnectionString()
        {
            string? masterconn = string.Empty;
            try
            {
                masterconn = Environment.GetEnvironmentVariable("ProjectConnection");
            }
            catch (SqlException sqlEx)
            {
                throw new ArgumentNullException(sqlEx.Message);
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException($"Configuration Error: {ex.Message}");
            }
            return masterconn;
        }
    }
}
