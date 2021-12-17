using Scheduling_App.Models;
using Scheduling_Application.Controller;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Scheduling_Application.Views
{
    public partial class customerForm : Form
    {
        int countryId, cityId, addressId, customerId;
        private string currentUser;
        databaseController dbController = new databaseController();


        string path = string.Format($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\Scheudling_Application\\Scheduling_App\\Temp\\Timestamp.txt");
        public customerForm(string user)
        {
            InitializeComponent();
            currentUser = user;
        }


        private void customerInfoValidator()
        {
            if (String.IsNullOrEmpty(customerNameTextBox.Text))
            {
                MessageBox.Show("Please enter a name for the customer"); 
            }
            if (String.IsNullOrEmpty(phoneTextBox.Text))
            {
                MessageBox.Show("Please enter a phone for the customer");
            }
            if (String.IsNullOrEmpty(cityComboBox.Text))
            {
                MessageBox.Show("Please select or enter a city name for the customer");
            }
            if (String.IsNullOrEmpty(countryComboBox.Text))
            {
                MessageBox.Show("Please select or enter a country for the customer");
            }
            if (String.IsNullOrEmpty(postalCodeTextBox.Text))
            {
                MessageBox.Show("Please enter a postal code for the customer");
            }
            if (String.IsNullOrEmpty(addressTextBox.Text))
            {
                MessageBox.Show("Please enter a address for the customer");
            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            bool found = false, active = true;
            string formated = "yyyy-MM-dd hh:mm:ss";

            if (isActiveRadio.Checked)
            {
                active = false;
                MessageBox.Show("Customer has been disabled. Please uncheck the disabled box before continuing.");
            }
            else
            {
                // If customers selected then make changes
                // else create new customer
                if (customerDataGridView.SelectedRows.Count > 0)
                {


                    customerId = (int)customerDataGridView.CurrentRow.Cells[0].Value;
                    addressId = (int)customerDataGridView.CurrentRow.Cells[2].Value;

                    customer updatedCustomer = new customer();
                    address updatedAddress = new address();
                    city updatedCity = new city();
                    country updatedCountry = new country();

                    updatedCustomer.customerName = customerNameTextBox.Text;
                    updatedCustomer.active = active;
                    updatedCustomer.lastUpdate = DateTime.Now;
                    updatedCustomer.lastUpdateBy = currentUser;

                    dbController.updateQuery($"UPDATE customer SET customerName = '{updatedCustomer.customerName}', active = '{Convert.ToInt32(updatedCustomer.active)}', " +
                        $"lastUpdate = '{updatedCustomer.lastUpdate.ToString(formated)}', lastUpdateBy = '{updatedCustomer.lastUpdateBy}'" +
                    $" WHERE customerId = {customerId}");


                    updatedAddress.address1 = addressTextBox.Text;
                    updatedAddress.address2 = address2TextBox.Text;
                    updatedAddress.phone = phoneTextBox.Text;
                    updatedAddress.postalCode = postalCodeTextBox.Text;
                    dbController.updateQuery($"UPDATE address SET address = '{updatedAddress.address1}', address2 = '{updatedAddress.address2}', phone = '{updatedAddress.phone}'," +
                        $" postalCode = '{updatedAddress.postalCode}', lastUpdate = '{updatedCustomer.lastUpdate.ToString(formated)}', lastUpdateBy = '{updatedCustomer.lastUpdateBy}'" +
                        $" WHERE addressId = {addressId}");

                    // Get the cityId
                    cityId = Convert.ToInt32(dbController.getValue($"SELECT cityId FROM city WHERE city = '{cityComboBox.Text}'"));

                    updatedCity.city1 = cityComboBox.Text;
                    dbController.updateQuery($"UPDATE city SET city = '{updatedCity.city1}', lastUpdate = '{updatedCustomer.lastUpdate.ToString(formated)}', lastUpdateBy = '{updatedCustomer.lastUpdateBy}'" +
                  $" WHERE cityId = {cityId}");


                    countryId = Convert.ToInt32(dbController.getValue($"SELECT countryId FROM country WHERE country = '{countryComboBox.Text}'"));
                    updatedCountry.country1 = countryComboBox.Text;
                    dbController.updateQuery($"UPDATE country SET country = '{updatedCountry.country1}', lastUpdate = '{updatedCustomer.lastUpdate.ToString(formated)}', lastUpdateBy = '{updatedCustomer.lastUpdateBy}'" +
                   $" WHERE countryId = {countryId}");

                    customerDataGridView.Update();
                    customerDataGridView.Refresh();

                    this.customerTableAdapter.Fill(this.client_scheduleDataSet.customer);

                    // append to file
                    using (StreamWriter writer = File.AppendText(path))
                    {
                        writer.WriteLine($"{currentUser} updated {updatedCustomer} at {DateTime.Now.ToLocalTime()}");
                    }
                }
                else
                {

                    // Check if customer exists
                    found = dbController.existQuery($"SELECT * FROM customer WHERE customerName = '{customerNameTextBox.Text}'");
                    if (found == true)
                    {
                        MessageBox.Show($"Customer, {customerNameTextBox.Text} Already exists in the database.");
                    }
                    else
                    {
                        // Check if country exists
                        found = dbController.existQuery($"SELECT * FROM country WHERE country = '{countryComboBox.Text}'");
                        if (found == true)
                        {
                            // Get the countryId
                            countryId = Convert.ToInt32(dbController.getValue($"SELECT countryId FROM country WHERE country = '{countryComboBox.Text}'"));
                        }
                        else
                        {
                            // Create new country
                            country Country = new country();
                            Country.country1 = countryComboBox.Text;
                            Country.createDate = DateTime.Now;
                            Country.createdBy = currentUser;
                            Country.lastUpdate = DateTime.Now;
                            Country.lastUpdateBy = currentUser;
                            dbController.insertQuery($"INSERT INTO country (country, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES " +
                            $" ('{Country.country1}', '{ Country.createDate.ToString(formated)}', '{Country.createdBy}', '{Country.lastUpdate.ToString(formated)}', '{Country.lastUpdateBy}')");
                            // Get the countryId
                            countryId = Convert.ToInt32(dbController.getValue($"SELECT countryId FROM country WHERE country = '{countryComboBox.Text}'"));
                            this.countryTableAdapter.Fill(this.client_scheduleDataSet.country);
                        }

                        // Check if city exists
                        found = dbController.existQuery($"SELECT * FROM city WHERE city = '{cityComboBox.Text}'");
                        if (found == true)
                        {
                            // Get the cityId
                            cityId = Convert.ToInt32(dbController.getValue($"SELECT cityId FROM city WHERE city = '{cityComboBox.Text}'"));
                        }
                        else
                        {
                            // Create new city
                            city City = new city();
                            City.city1 = cityComboBox.Text;
                            City.countryId = countryId;
                            City.createDate = DateTime.Now;
                            City.createdBy = currentUser;
                            City.lastUpdate = DateTime.Now;
                            City.lastUpdateBy = currentUser;
                            dbController.insertQuery($"INSERT INTO city (city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES " +
                            $" ('{City.city1}', '{City.countryId}', '{ City.createDate.ToString(formated)}', '{City.createdBy}', '{City.lastUpdate.ToString(formated)}', '{City.lastUpdateBy}')");
                            // Get the cityId
                            cityId = Convert.ToInt32(dbController.getValue($"SELECT cityId FROM city WHERE city = '{cityComboBox.Text}'"));
                            this.cityTableAdapter.Fill(this.client_scheduleDataSet.city);
                        }

                        // Check if address exists
                        found = dbController.existQuery($"SELECT * FROM address WHERE address = '{addressTextBox.Text}'");
                        if (found == true)
                        {
                            // Get the addressId
                            addressId = Convert.ToInt32(dbController.getValue($"SELECT addressId FROM address WHERE address = '{addressTextBox.Text}'"));
                        }
                        else
                        {
                            // Create new address
                            address address = new address();
                            address.address1 = addressTextBox.Text;
                            address.address2 = address2TextBox.Text;
                            address.cityId = cityId;
                            address.postalCode = postalCodeTextBox.Text;
                            address.phone = phoneTextBox.Text;
                            address.createDate = DateTime.Now;
                            address.createdBy = currentUser;
                            address.lastUpdate = DateTime.Now;
                            address.lastUpdateBy = currentUser;
                            dbController.insertQuery($"INSERT INTO address (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES " +
                            $" ('{address.address1}', '{address.address2}', '{address.cityId}', '{address.postalCode}', '{address.phone}', " +
                            $"'{ address.createDate.ToString(formated)}', '{address.createdBy}', '{address.lastUpdate.ToString(formated)}', '{address.lastUpdateBy}')");
                            // Get the addressId
                            addressId = Convert.ToInt32(dbController.getValue($"SELECT addressId FROM address WHERE address = '{addressTextBox.Text}'"));
                        }


                        // Create new Customer
                        customer cust = new customer();
                        cust.customerName = customerNameTextBox.Text;
                        cust.addressId = addressId;
                        cust.active = active;
                        cust.createDate = DateTime.Now;
                        cust.createdBy = currentUser;
                        cust.lastUpdate = DateTime.Now;
                        cust.lastUpdateBy = currentUser;
                        dbController.insertQuery($"INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES " +
                        $" ('{cust.customerName}', '{cust.addressId}', '{Convert.ToInt32(cust.active)}', '{ cust.createDate.ToString(formated)}'," +
                        $" '{cust.createdBy}', '{cust.lastUpdate.ToString(formated)}', '{cust.lastUpdateBy}')");


                        // append to file
                        using (StreamWriter writer = File.AppendText(path))
                        {
                            writer.WriteLine($"{currentUser} created {cust.customerName} at {DateTime.Now.ToLocalTime()}");
                        }
                    }
                }
            }
            customerDataGridView.Update();
            customerDataGridView.Refresh();
            // TODO: This line of code loads data into the 'client_scheduleDataSet.customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.client_scheduleDataSet.customer);

        }

        private void customerForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'client_scheduleDataSet.address' table. You can move, or remove it, as needed.
            this.addressTableAdapter.Fill(this.client_scheduleDataSet.address);
            // TODO: This line of code loads data into the 'client_scheduleDataSet.customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.client_scheduleDataSet.customer);
            // TODO: This line of code loads data into the 'client_scheduleDataSet.country' table. You can move, or remove it, as needed.
            this.countryTableAdapter.Fill(this.client_scheduleDataSet.country);
            // TODO: This line of code loads data into the 'client_scheduleDataSet.city' table. You can move, or remove it, as needed.
            this.cityTableAdapter.Fill(this.client_scheduleDataSet.city);
        }

        private void customerDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            this.customerDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void customerDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            customerDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Set the customer Textbox
            customerNameTextBox.Text = customerDataGridView.CurrentRow.Cells[1].Value.ToString();
            // Set the address Textboxs
            addressId = (int)customerDataGridView.CurrentRow.Cells[2].Value;

            var addressQuery = from address in client_scheduleDataSet.address
                               where address.addressId == addressId
                               select new { address = address.address, address2 = address.address2, phone = address.phone, zip = address.postalCode, cityId = address.cityId };

            foreach (var address in addressQuery)
            {
                addressTextBox.Text = address.address;
                address2TextBox.Text = address.address2;
                phoneTextBox.Text = address.phone;
                postalCodeTextBox.Text = address.zip;
                cityId = address.cityId;
            }

            var cityQuery = from city in client_scheduleDataSet.city
                            where city.cityId == cityId
                            select new { city = city.city, countryId = city.countryId };


            foreach (var city in cityQuery)
            {
                cityComboBox.Text = city.city;
                countryId = city.countryId;
            }

            var countryQuery = from country in client_scheduleDataSet.country
                               where country.countryId == countryId
                               select new { country = country.country };

            foreach (var country in countryQuery)
            {
                countryComboBox.Text = country.country;
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            this.customerDataGridView.ClearSelection();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string custName;
            // Get selected row from datagrid
            if (customerDataGridView.SelectedRows.Count > 0)
            {
                custName = customerDataGridView.SelectedRows[0].Cells[1].Value.ToString();
                // Todo: Finish delete button and add to appointmentForm
                MessageBox.Show($"Are you sure you want to delete {custName} from the table?");
                // Get the customerId
                customerId = Convert.ToInt32(dbController.getValue($"SELECT customerId FROM customer WHERE customerName = '{custName}'"));
                dbController.deleteQuery($"DELETE FROM customer WHERE customerId = {customerId}");

                customerDataGridView.Update();
                customerDataGridView.Refresh();
                this.customerTableAdapter.Fill(this.client_scheduleDataSet.customer);
                // append to file
                using (StreamWriter writer = File.AppendText(path))
                {
                    writer.WriteLine($"{currentUser} deleted {custName} at {DateTime.Now.ToLocalTime()}");
                }
            }

        }
    }
}