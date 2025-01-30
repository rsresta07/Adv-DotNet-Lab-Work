using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIDemo
{
    class ModelDb
    {
        static string ConnectionString = @"data source=DESKTOP-TMA9H5P\SQLEXPRESS01; database=mydb; integrated security=true";
        SqlConnection connection = new SqlConnection(ConnectionString);


        public bool Insert(string name , int age, string address)
        {
            try
            {
                connection.Open();
                string sql = "INSERT INTO registration VALUES('" + name + "','" + age + "','" + address + "')";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch(SqlException se)
            {
                Console.WriteLine(se);
            }        

            return true;
        }

        public string View()
        {
            string sql = "select* from registration";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, connection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            string msg = null;
            
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                msg += row["name"] + ",  " + row["age"] + ",  " + row["address"] + "\n";
            }
            return msg;

        }

        public bool Delete(string name)
        {
            try
            {
                connection.Open();
                string sql = "DELETE FROM registration WHERE name ='"+name+"'";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (SqlException se)
            {
                Console.WriteLine(se);
            }

            return true;
        }

        public bool Update(string name,int age)
        {
            try
            {
                connection.Open();
                string sql = "UPDATE registration SET age ='"+age+"' WHERE name ='" + name + "'";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (SqlException se)
            {
                Console.WriteLine(se);
            }

            return true;
        }


    }
}
