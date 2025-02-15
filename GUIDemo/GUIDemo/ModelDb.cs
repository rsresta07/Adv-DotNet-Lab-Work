using System;
using System.Data;
using System.Data.SqlClient;

namespace GUIDemo
{
    class ModelDb
    {
        private static readonly string ConnectionString = @"data source=DESKTOP-TMA9H5P\SQLEXPRESS01; database=mydb; integrated security=true";

        public bool Insert(string name, int age, string address)
        {
            string sql = "INSERT INTO registration (name, age, address) VALUES (@name, @age, @address)";
            return ExecuteNonQuery(sql, new SqlParameter("@name", name), new SqlParameter("@age", age), new SqlParameter("@address", address));
        }

        public string View()
        {
            string sql = "SELECT name, age, address FROM registration";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    string msg = "";
                    while (reader.Read())
                    {
                        msg += $"{reader["name"]}, {reader["age"]}, {reader["address"]}\n";
                    }
                    return msg;
                }
            }
        }

        public bool Delete(string name)
        {
            string sql = "DELETE FROM registration WHERE name = @name";
            return ExecuteNonQuery(sql, new SqlParameter("@name", name));
        }

        public bool Update(string name, int age)
        {
            string sql = "UPDATE registration SET age = @age WHERE name = @name";
            return ExecuteNonQuery(sql, new SqlParameter("@name", name), new SqlParameter("@age", age));
        }

        private bool ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
