using MathNet.Numerics.Statistics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPABD_Forms
{
    class DatabaseConnection
    {
        private static string connectionString = "Data Source=PAVILIONGAME\\YUDHA_PUTRA_RAMA;Initial Catalog=Management_Komunitas;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public static DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        public static int ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
           int rowsAffected = 0;
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }

        public static object ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            object result = null;
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    connection.Open();
                    result = command.ExecuteScalar();
                }
            }
            return result;
        }

        public static bool TestConnection()
        {
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();
                    return true; // Connection successful
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection failed: " + ex.Message);
                return false; // Connection failed
            }
        }
    }
    public static class UserSession
    {
        public static string UserId { get; set; }

        public static string Username { get; set; }
        public static string RoleName { get; set; }
        public static string KomunitasId { get; set; }
        public static bool IsLoggedIn { get; set; }
        public static void ClearSession()
        {
            UserId = string.Empty;
            Username = string.Empty;
            RoleName = string.Empty;
            KomunitasId = string.Empty;
            IsLoggedIn = false;
        }

    }
}
