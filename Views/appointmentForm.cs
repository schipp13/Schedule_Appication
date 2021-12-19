using Scheduling_App.Models;
using Scheduling_Application.Controller;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Scheduling_Application.Views
{
    public partial class appointmentForm : Form
    {
        private string currentUser;
        int appointmentId, customerId, userId;
        bool editMode;
        databaseController dbController = new databaseController();
        string path = string.Format($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\Scheudling_Application\\Scheduling_App\\Temp\\Timestamp.txt");
        string start, end;
        string[] startDateTimeSplit;
        string[] endDateTimeSplit;

        DateTime startDay, endDay;
        TimeSpan startTime, endTime;
        DateTime combinedStartDateTime, combinedEndDateTime;

        public appointmentForm(int apptId, int custId, string user, bool editable)
        {
            InitializeComponent();
            currentUser = user;
            customerId = custId;
            editMode = editable;
            appointmentId = apptId;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            calendarForm calendar = new calendarForm(currentUser, now);
            calendar.Show();
            this.Close();
        }

        public void appointmentInfoValidator()
        {
            if (String.IsNullOrEmpty(titleTextBox.Text))
            {
                MessageBox.Show("Please enter a title for the appointment");
            }
            if (String.IsNullOrEmpty(customerComboBox.Text))
            {
                MessageBox.Show("Please select or enter a customer name for the appointment");
            }
            if (String.IsNullOrEmpty(typeComboBox.Text))
            {
                MessageBox.Show("Please select or enter a type for the appointments");
            }
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            string minTimeValue = "08:00:00", maxTimeValue = "17:00:00";
            string formatted = "yyyy-MM-dd hh:mm:ss";
            bool found = false;
            bool withinBusinessHours = false;

            appointmentInfoValidator();

            // Get the customerId
            customerId = Convert.ToInt32(dbController.getValue($"SELECT customerId FROM customer WHERE customerName = '{customerComboBox.Text}'"));

            // Get the userId
            userId = Convert.ToInt32(dbController.getValue($"SELECT userId FROM user WHERE userName = '{currentUser}'"));

            // Check to see if appointment is within buisness hours
            withinBusinessHours = validHours(startTimeDatePicker.Value, endTimeDatePicker.Value);
            if (withinBusinessHours == true)
            {
                // Check if appointment exists between start and end time
                if (startTimeDatePicker.Value.TimeOfDay < TimeSpan.Parse(minTimeValue) ||
                startTimeDatePicker.Value.TimeOfDay > TimeSpan.Parse(maxTimeValue) || endTimeDatePicker.Value.TimeOfDay > TimeSpan.Parse(maxTimeValue) || found == true)
                {
                    MessageBox.Show("The appointment already exists");
                }
                else
                {
                    // Combine the start date and time
                    startDay = startDateTimePicker.Value.Date;
                    startTime = startTimeDatePicker.Value.TimeOfDay;
                    combinedStartDateTime = startDay + startTime;

                    // Combine the end date and time
                    endDay = endDateTimePicker.Value.Date;
                    endTime = endTimeDatePicker.Value.TimeOfDay;
                    combinedEndDateTime = endDay + endTime;

                    // Check to see if appointment exists at appointmentId
                    found = dbController.existQuery($"SELECT * FROM appointment WHERE appointmentId = '{appointmentId}'");

                    if (found == true)
                    {
                        // Make changes to the appointment
                        appointment updatedAppointment = new appointment();

                        updatedAppointment.title = titleTextBox.Text;
                        updatedAppointment.customerId = customerId;
                        updatedAppointment.userId = userId;
                        updatedAppointment.description = descriptionTextBox.Text;
                        updatedAppointment.location = locationTextBox.Text;
                        updatedAppointment.contact = contactComboBox.Text;
                        updatedAppointment.type = typeComboBox.Text;
                        updatedAppointment.url = urlTextBox.Text;
                        updatedAppointment.start = combinedStartDateTime;
                        updatedAppointment.end = combinedEndDateTime;
                        updatedAppointment.lastUpdate = DateTime.Now;
                        updatedAppointment.lastUpdateBy = currentUser;

                        dbController.updateQuery($"UPDATE appointment SET customerId = '{updatedAppointment.customerId}', userId = '{updatedAppointment.userId}', title = '{updatedAppointment.title}'," +
                            $" description = '{updatedAppointment.description}', location = '{updatedAppointment.location}', contact= '{updatedAppointment.contact}', type = '{updatedAppointment.type}'," +
                            $" url = '{updatedAppointment.url}', start = '{updatedAppointment.start.ToUniversalTime().ToString(formatted)}', end = '{updatedAppointment.end.ToUniversalTime().ToString(formatted)}', lastUpdate = '{updatedAppointment.lastUpdate.ToString(formatted)}', lastUpdateBy = '{updatedAppointment.lastUpdateBy}'" +
                            $" WHERE appointmentId = {appointmentId}");

                        MessageBox.Show("The appointment was updated");
                        // append to file
                        using (StreamWriter writer = File.AppendText(path))
                        {
                            writer.WriteLine($"{currentUser} updated {updatedAppointment.title} at {DateTime.Now.ToLocalTime()}");
                        }
                    }
                    else
                    {
                        //Create new appointment
                        appointment newAppointment = new appointment();

                        newAppointment.title = titleTextBox.Text;
                        newAppointment.customerId = customerId;
                        newAppointment.userId = userId;
                        newAppointment.description = descriptionTextBox.Text;
                        newAppointment.location = locationTextBox.Text;
                        newAppointment.contact = contactComboBox.Text;
                        newAppointment.type = typeComboBox.Text;
                        newAppointment.url = urlTextBox.Text;
                        newAppointment.start = combinedStartDateTime;
                        newAppointment.end = combinedEndDateTime;
                        newAppointment.createDate = DateTime.Now;
                        newAppointment.createdBy = currentUser;
                        newAppointment.lastUpdate = DateTime.Now;
                        newAppointment.lastUpdateBy = currentUser;

                        // Insert appointment into Database
                        dbController.insertQuery($"INSERT INTO appointment (customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES " +
                               $" ('{newAppointment.customerId}', '{newAppointment.userId}', '{newAppointment.title}', '{newAppointment.description}', " +
                               $"'{newAppointment.location}', '{newAppointment.contact}', '{newAppointment.type}', '{newAppointment.url}', '{newAppointment.start.ToUniversalTime().ToString(formatted)}', '{newAppointment.end.ToUniversalTime().ToString(formatted)}'," +
                               $"'{ newAppointment.createDate.ToString(formatted)}', '{newAppointment.createdBy}', '{newAppointment.lastUpdate.ToString(formatted)}', '{newAppointment.lastUpdateBy}')");


                        MessageBox.Show("The appointment was created");

                        using (StreamWriter writer = File.AppendText(path))
                        {
                            writer.WriteLine($"{currentUser} created {newAppointment.title} at {DateTime.Now.ToLocalTime()}");
                        }

                    }

                }

            }
            else
            {
                MessageBox.Show("The appointment times are not within the valid hours. (8 am - 5 pm)");
            }
        }

        private bool validHours(DateTime startTime, DateTime endTime)
        {
            bool valid = false;

            TimeSpan minTime = new TimeSpan(8, 0, 0), maxTime = new TimeSpan(17, 0, 0);

            TimeSpan appointmentStart = startTime.TimeOfDay;
            TimeSpan appointmentEnd = endTime.TimeOfDay;

            int startBeforeOpened = TimeSpan.Compare(appointmentStart, minTime);

            int startAfterClose = TimeSpan.Compare(appointmentStart, maxTime);

            int endResult = TimeSpan.Compare(appointmentEnd, maxTime);


            if (startBeforeOpened < 0) // Checks to see if start time is before 8am
            {
                valid = false;
            }
            else if (startBeforeOpened >= 0 && endResult <= 0) // Checks to see if start time is within 8 and 5
            {
                valid = true;
            }
            else // start time is past 5pm
            {
                valid = false;
            }

            return valid;
        }

        private void appointmentForm_Load(object sender, EventArgs e)
        {

            // TODO: This line of code loads data into the 'client_scheduleDataSet.customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.client_scheduleDataSet.customer);
            // TODO: This line of code loads data into the 'client_scheduleDataSet.appointment' table. You can move, or remove it, as needed.
            this.appointmentTableAdapter.Fill(this.client_scheduleDataSet.appointment);

            if (editMode == true)
            {
                // Set all textfields 
                var appointmentQuery = from appointment in client_scheduleDataSet.appointment
                                       where appointment.appointmentId == appointmentId
                                       select new
                                       {
                                           title = appointment.title,
                                           description = appointment.description,
                                           location = appointment.location,
                                           contact = appointment.contact,
                                           type = appointment.type,
                                           url = appointment.url,

                                       };

                foreach (var appt in appointmentQuery)
                {
                    titleTextBox.Text = appt.title;
                    descriptionTextBox.Text = appt.description;
                    locationTextBox.Text = appt.location;
                    contactComboBox.Text = appt.contact;
                    typeComboBox.Text = appt.type;
                    urlTextBox.Text = appt.url;

                }

                var customerQuery = from cust in client_scheduleDataSet.customer
                                    where cust.customerId == customerId
                                    select new { Name = cust.customerName };

                foreach (var cust in customerQuery)
                {
                    customerComboBox.Text = cust.Name;
                }

                start = dbController.getValue($"SELECT start FROM appointment WHERE appointmentId = '{appointmentId}'");
                end = dbController.getValue($"SELECT end FROM appointment WHERE appointmentId = '{appointmentId}'");


                startDateTimeSplit = start.Split(' ');
                endDateTimeSplit = end.Split(' ');

                startDateTimePicker.Value = Convert.ToDateTime(startDateTimeSplit[0]);
                startTimeDatePicker.Value = Convert.ToDateTime(startDateTimeSplit[1]).AddHours(12).ToLocalTime();

                endDateTimePicker.Value = Convert.ToDateTime(endDateTimeSplit[0]);
                endTimeDatePicker.Value = Convert.ToDateTime(endDateTimeSplit[1]).AddHours(12).ToLocalTime();

            }
        }
    }
}