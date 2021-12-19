using Scheduling_Application.Controller;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Scheduling_App.Views
{
    public partial class reportsForm : Form
    {
        int userId, customerId;
        string currentUser;
        string formatted = "yyyy-MM-dd hh:mm:ss";

        DateTime currentMonthStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1),

        currentMonthEnd;

        databaseController dbController = new databaseController();
        public reportsForm(string user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void reportsForm_Load(object sender, EventArgs e)
        {
            userNameLabel.Text = $"{currentUser}'s Report Options";

            // TODO: This line of code loads data into the 'client_scheduleDataSet.user' table. You can move, or remove it, as needed.
            this.userTableAdapter.Fill(this.client_scheduleDataSet.user);

            this.customerTableAdapter.Fill(this.client_scheduleDataSet.customer);

            this.appointmentTableAdapter.Fill(this.client_scheduleDataSet.appointment);

            currentMonthEnd = currentMonthStart.AddMonths(1).AddDays(-1);

            var typeAmount = client_scheduleDataSet.appointment.Where(a => a.start == currentMonthStart && a.start == currentMonthEnd)
                            .GroupBy(a => a.type)
                            .Select(apt => new {Type = apt.Key, Count = apt.Count()});

            apptsByType.DataSource = typeAmount.ToArray();
        }

        private void customerNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string customer = customerNameComboBox.Text;
            customerId = Convert.ToInt32(dbController.getValue($"SELECT customerId FROM customer WHERE customerName = '{customer}'"));

            var customerAppointment = client_scheduleDataSet.appointment.Where(x => x.customerId == customerId).ToList();

            customerApptsSchedule.DataSource = customerAppointment.ToArray();
        }

        private void reportsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            customerNameComboBox.SelectedIndexChanged -= customerNameComboBox_SelectedIndexChanged;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void reports_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentMonthEnd = currentMonthStart.AddMonths(1).AddDays(-1);

            // Used lambda and LINQ to get the appointments by type for the current month and return the amount of each type
            if (reports.SelectedTab == apptByType)
            {
                var typeAmount = client_scheduleDataSet.appointment.Where(a => a.start.Date >= currentMonthStart.Date && a.start.Date <= currentMonthEnd.Date)
                    .GroupBy(a => a.type)
                    .Select(apt => new { Type = apt.Key, Count = apt.Count() });

                apptsByType.DataSource = typeAmount.ToArray();
            }
            else if (reports.SelectedTab == userSchedule)
            {
                userId = Convert.ToInt32(dbController.getValue($"SELECT userId FROM user WHERE userName = '{currentUser}'"));

                var schedule = client_scheduleDataSet.appointment.Where(x => x.userId == userId).ToList();

                userApptsSchedule.DataSource = schedule.ToArray();
            }
            else
            {
                customerId = Convert.ToInt32(dbController.getValue($"SELECT customerId FROM customer WHERE customerName = '{customerNameComboBox.Text}'"));

                // Used a lambda for this to select the customersId to get the appointments for the selected customer from the combo box.
                var customerAppointment = client_scheduleDataSet.appointment.Where(x => x.customerId == customerId).ToList();

                customerApptsSchedule.DataSource = customerAppointment.ToArray();
            }
        }
    }
}
