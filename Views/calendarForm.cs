using Scheduling_App.Views;
using Scheduling_Application.Controller;
using System;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace Scheduling_Application.Views
{
    public partial class calendarForm : Form
    {
        databaseController dbController = new databaseController();
        DateTime loggedIn, weekStart, monthStart, end;
        DayOfWeek day;
        int days;
        private string currentUser;
        string formatted = "yyyy-MM-dd";
        string startDate;
        string endDate;
        string[] startSplitter;
        string[] endSplitter;
        string filter;

        string path = string.Format($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\Scheudling_Application\\Scheduling_App\\Temp\\Timestamp.txt");

        public calendarForm(string user, DateTime loginTime)
        {
            InitializeComponent();

            loggedIn = loginTime.AddMinutes(15);

            currentUser = user;

            getUpComingAppointment();

        }

        // Gets upcoming appointments in 15 minutes

        public void getUpComingAppointment()
        {
            var reminder = dbController.populateList($"SELECT title, customerId, start FROM appointment WHERE start = '{loggedIn.ToString("yyyy-MM-dd hh:mm")}%'");

            foreach (var appt in reminder)
            {
                string customerName = client_scheduleDataSet.customer.Where(c => c.customerId == appt.customerId).ToString();

                MessageBox.Show($"You have an appointment: {appt.title} with {customerName} at {appt.start}");
            }

        }

        /*
         * Logs the user out and goes back to the login form
         */
        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.Close();
            loginForm login = new loginForm();
            login.Show();
        }

        /*
         * Opens the appointments form
         */
        private void appointmentButton_Click(object sender, EventArgs e)
        {
            int appointmentId, customerId;
            bool edit;

            // Set the form to modify
            if (appointmentButton.Text == "Modify Appointment")
            {
                if (weeklyAppointmentsDGV.SelectedRows.Count > 0 && appointmentContainer.SelectedTab.Text == "Weekly")
                {
                    appointmentId = (int)weeklyAppointmentsDGV.CurrentRow.Cells[0].Value;
                    customerId = (int)weeklyAppointmentsDGV.CurrentRow.Cells[1].Value;
                    edit = true;
                    appointmentForm appointmentForm = new appointmentForm(appointmentId, customerId, currentUser, edit);
                    appointmentForm.Show();

                }
                else
                {
                    appointmentId = (int)monthlyAppointmentsDGV.CurrentRow.Cells[0].Value;
                    customerId = (int)monthlyAppointmentsDGV.CurrentRow.Cells[1].Value;
                    edit = true;
                    appointmentForm appointmentForm = new appointmentForm(appointmentId, customerId, currentUser, edit);
                    appointmentForm.Show();

                }
            }
            else
            {
                edit = false;
                appointmentId = 0;
                customerId = 0;
                appointmentForm appointmentForm = new appointmentForm(appointmentId, customerId, currentUser, edit);
                appointmentForm.Show();
                this.Close();
            }

            this.appointmentTableAdapter.Fill(this.client_scheduleDataSet.appointment);
        }
        /*
         * Opens the customer form
         */
        private void customerButton_Click(object sender, EventArgs e)
        {
            customerForm customerForm = new customerForm(currentUser);
            customerForm.Show();
        }

        /* 
         * Opens a list of different reports
         */
        private void reportButton_Click(object sender, EventArgs e)
        {
            reportsForm report = new reportsForm(currentUser);
            report.Show();
        }

        private void calendarForm_Load(object sender, EventArgs e)
        {

            this.appointmentTableAdapter.Fill(this.client_scheduleDataSet.appointment);

        }


        private void removeButton_Click(object sender, EventArgs e)
        {
            int appointmentId;
            string appointmentTitle;

            // Get selected row from datagrid
            if (weeklyAppointmentsDGV.SelectedRows.Count > 0 && appointmentContainer.SelectedTab.Text == "Weekly")
            {
                appointmentTitle = weeklyAppointmentsDGV.SelectedRows[0].Cells[3].Value.ToString();

                MessageBox.Show($"Are you sure you want to delete {appointmentTitle} from the table?");

                // Get the userId
                appointmentId = Convert.ToInt32(dbController.getValue($"SELECT appointmentId FROM appointment WHERE title = '{appointmentTitle}'"));

                dbController.deleteQuery($"DELETE FROM appointment WHERE appointmentId = {appointmentId}");

            }
            else
            {
                appointmentTitle = monthlyAppointmentsDGV.SelectedRows[0].Cells[3].Value.ToString();

                MessageBox.Show($"Are you sure you want to delete {appointmentTitle} from the table?");
                // Get the userId
                appointmentId = Convert.ToInt32(dbController.getValue($"SELECT appointmentId FROM appointment WHERE title = '{appointmentTitle}'"));

                dbController.deleteQuery($"DELETE FROM appointment WHERE appointmentId = {appointmentId}");
            }

            this.appointmentTableAdapter.Fill(this.client_scheduleDataSet.appointment);
            // append to file
            using (StreamWriter writer = File.AppendText(path))
            {
                writer.WriteLine($"{currentUser} deleted {appointmentTitle} at {DateTime.Now.ToLocalTime()}");
            }

        }

        private void weeklyAppointmentsDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            weeklyAppointmentsDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            appointmentButton.Text = "Modify Appointment";
            removeButton.Visible = true;
        }

        private void monthlyAppointmentsDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            monthlyAppointmentsDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            appointmentButton.Text = "Modify Appointment";
            removeButton.Visible = true;
        }


        private void calendarForm_Click(object sender, EventArgs e)
        {
            this.weeklyAppointmentsDGV.ClearSelection();
            this.monthlyAppointmentsDGV.ClearSelection();
            appointmentButton.Text = "New Appointment";
            removeButton.Visible = false;
        }

        private void appointmentContainer_MouseDown(object sender, MouseEventArgs e)
        {
            this.weeklyAppointmentsDGV.ClearSelection();
            this.monthlyAppointmentsDGV.ClearSelection();
            appointmentButton.Text = "New Appointment";
            removeButton.Visible = false;
        }

        private void appointmentContainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string formatted = "yyyy-MM-dd";

            day = DateTime.Now.DayOfWeek;
            days = day - DayOfWeek.Monday;
            weekStart = DateTime.Now.AddDays(-days);
            monthStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);



            // Filters appointment by week
            if (appointmentContainer.SelectedTab.Text == "Weekly")
            {
                end = weekStart.AddDays(6);
                startDate = weekStart.ToString(formatted);
                endDate = end.ToString(formatted);
                startSplitter = startDate.Split(' ');
                endSplitter = endDate.Split(' ');

                filter = $"start >= '{Convert.ToDateTime(startSplitter[0])}' AND end <=  '{Convert.ToDateTime(endSplitter[0])}'";

                this.appointmentBindingSource.Filter = filter;
                weeklyAppointmentsDGV.DataSource = this.appointmentBindingSource;

            }
            // Filters appoinment by month
            else
            {
                end = monthStart.AddMonths(1).AddDays(-1);
                startDate = monthStart.ToString(formatted);
                endDate = end.ToString(formatted);
                startSplitter = startDate.Split(' ');
                endSplitter = endDate.Split(' ');

                filter = $"start >= '{Convert.ToDateTime(startSplitter[0])}' AND end <=  '{Convert.ToDateTime(endSplitter[0])}'";

                this.appointmentBindingSource.Filter = filter;
                monthlyAppointmentsDGV.DataSource = this.appointmentBindingSource;
            }

            this.appointmentTableAdapter.Fill(this.client_scheduleDataSet.appointment);
        }

        // Convert Times to current time zone
        private void weeklyAppointmentsDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is DateTime)
            {
                // Get UTC time
                DateTime value = (DateTime)e.Value;

                /* e.Value = DateTime.SpecifyKind(value, DateTimeKind.Local).ToUniversalTime();*/
                TimeZoneInfo.ClearCachedData();

                // Convert to new local time
                e.Value = TimeZoneInfo.ConvertTimeFromUtc(value, TimeZoneInfo.Local).AddHours(12);

            }
        }
        private void monthlyAppointmentsDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is DateTime)
            {
                // Get UTC time
                DateTime value = (DateTime)e.Value;

                /* e.Value = DateTime.SpecifyKind(value, DateTimeKind.Local).ToUniversalTime();*/
                TimeZoneInfo.ClearCachedData();

                // Convert to new local time
                e.Value = TimeZoneInfo.ConvertTimeFromUtc(value, TimeZoneInfo.Local).AddHours(12);

            }
        }
    }
}