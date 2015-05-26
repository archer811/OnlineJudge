using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using OnlineJudge;
using System.Data;
using OnlineJudge.Models;

namespace OnlineJudge
{
    public class ConnnectDatabase
    {
        private const string connString = "server=localhost;user id=root;persistsecurityinfo=True;database=onlinejudge";

        public static void ExecSql(string query)
        {
            var myConnection = new MySqlConnection(connString);

            try
            {

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myConnection.Open();
                myCommand.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                myConnection.Close();
            }

        }
        public static MySqlDataReader ExecQuery(string query)
        {
            var myConnection = new MySqlConnection(connString);
            MySqlDataReader myDataReader = null;
            try
            {
                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myConnection.Open();
                myDataReader = myCommand.ExecuteReader();
            }
            catch { }
            finally
            {
                myConnection.Close();

            }

            return myDataReader;
        }


        public static DataTable QueryDataTable(string sql)
        {
            var myConnection = new MySqlConnection(connString);
            DataTable dt = new DataTable();
            try
            {
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, myConnection);
                myConnection.Open();
                dataAdapter.Fill(dt);
            }
            finally
            {
                myConnection.Close();
            }

            return dt;
        }

    }
}