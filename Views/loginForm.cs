using Scheduling_App.Properties;
using Scheduling_Application.Controller;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Scheduling_Application.Views
{
    public partial class loginForm : Form
    {
        databaseController dbController = new databaseController();

        public loginForm()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(CultureInfo.CurrentCulture.Name, false);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(CultureInfo.CurrentCulture.Name, false);

            InitializeComponent();
        }

        /*
         * Allows the user to login
         */
        private void loginButton_Click(object sender, EventArgs e)
        {
            bool found = false;
            DateTime loginTime = DateTime.Now.ToUniversalTime();

            // Path to the logfile
            string path = string.Format($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\Scheudling_Application\\Scheduling_App\\Temp\\Timestamp.txt");

            found = dbController.existQuery($"SELECT * FROM user WHERE userName = '{userNameTextBox.Text}' AND " +
                $"password = '{passwordTextBox.Text}'");

            if (found == true)
            {
                this.Hide();
                calendarForm calender = new calendarForm(userNameTextBox.Text, loginTime.ToLocalTime());
                calender.Show();



                if (File.Exists(path))
                {
                    // append to file
                    using (StreamWriter writer = File.AppendText(path))
                    {
                        writer.WriteLine($"{userNameTextBox.Text} logged in at {loginTime.ToLocalTime()}");
                    }
                }
                else
                {
                    // Log user log-in
                    Directory.CreateDirectory($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\Scheudling_Application\\Scheduling_App\\Temp");
                    using (StreamWriter writer = File.CreateText(path))
                    {


                        writer.WriteLine($"{userNameTextBox.Text} logged in at {loginTime.ToLocalTime()}");
                    }
                }
            }
            else
            {
                List<string> errorMessage = ("The username or password is incorrect. Please try again.").Split(' ').ToList();
                string error = string.Empty;

                // If the region is set to france, change the message text
                if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "fr")
                {
                    foreach (string word in errorMessage)
                    {
                        error += fr_lang.ResourceManager.GetString(word) + ' ';
                    }
                    MessageBox.Show(error);
                }
                else
                {
                    MessageBox.Show("The username or password is incorrect. Please try again.");
                }
            }
        }

        /*
         * Closes out the application
         */
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void userBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.userBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.client_scheduleDataSet);
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'client_scheduleDataSet.user' table. You can move, or remove it, as needed.
            this.userTableAdapter.Fill(this.client_scheduleDataSet.user);

        }
    }
}
