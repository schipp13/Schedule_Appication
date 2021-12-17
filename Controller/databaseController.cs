using MySql.Data.MySqlClient;
using Scheduling_App.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Scheduling_Application.Controller
{
    internal class databaseController
    {
        appointment[] upComming = null;
        string value;
        private MySqlConnection connection = new MySqlConnection("server=127.0.0.1;user id=sqlUser;password=Passw0rd!;database=client_schedule;");

        public bool existQuery(string query)
        {
            connection.Open();

            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    connection.Close();
                    return true;
                }
                else
                {
                    reader.Close();
                    reader.Dispose();
                }
            }
            connection.Close();

            return false;
        }

        // Populates list with appointents
        public appointment[] populateList(string query)
        {
            connection.Open();

            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                var appointmentList = new List<appointment>();
                while (reader.Read())
                {
                    appointmentList.Add(new appointment { title = reader.GetString(0), start = reader.GetDateTime(1) });
                }
                upComming = appointmentList.ToArray();
            }
            connection.Close();
            return upComming;
        }

        public string getValue(string query)
        {


            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                connection.Open();
                try
                {

                    value = cmd.ExecuteScalar().ToString();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            connection.Close();

            return value;
        }

        public void updateQuery(string query)
        {
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }

        public void insertQuery(string query)
        {
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }

        public void deleteQuery(string query)
        {
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }

    }
}
