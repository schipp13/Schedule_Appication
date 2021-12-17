namespace Scheduling_Application.Views
{
    partial class appointmentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(appointmentForm));
            this.cancelButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.endTimeDatePicker = new System.Windows.Forms.DateTimePicker();
            this.startTimeDatePicker = new System.Windows.Forms.DateTimePicker();
            this.customerComboBox = new System.Windows.Forms.ComboBox();
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.client_scheduleDataSet = new Scheduling_App.client_scheduleDataSet();
            this.customerLabel = new System.Windows.Forms.Label();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.appointmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contactComboBox = new System.Windows.Forms.ComboBox();
            this.endLabel = new System.Windows.Forms.Label();
            this.startLabel = new System.Windows.Forms.Label();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.urlLabel = new System.Windows.Forms.Label();
            this.typeLabel = new System.Windows.Forms.Label();
            this.contactLabel = new System.Windows.Forms.Label();
            this.locationTextBox = new System.Windows.Forms.TextBox();
            this.locationLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.appointmentBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.appointmentTableAdapter = new Scheduling_App.client_scheduleDataSetTableAdapters.appointmentTableAdapter();
            this.tableAdapterManager = new Scheduling_App.client_scheduleDataSetTableAdapters.TableAdapterManager();
            this.customerTableAdapter = new Scheduling_App.client_scheduleDataSetTableAdapters.customerTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.client_scheduleDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // applyButton
            // 
            resources.ApplyResources(this.applyButton, "applyButton");
            this.applyButton.Name = "applyButton";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // titleLabel
            // 
            resources.ApplyResources(this.titleLabel, "titleLabel");
            this.titleLabel.Name = "titleLabel";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.endTimeDatePicker);
            this.panel1.Controls.Add(this.startTimeDatePicker);
            this.panel1.Controls.Add(this.customerComboBox);
            this.panel1.Controls.Add(this.customerLabel);
            this.panel1.Controls.Add(this.endDateTimePicker);
            this.panel1.Controls.Add(this.startDateTimePicker);
            this.panel1.Controls.Add(this.typeComboBox);
            this.panel1.Controls.Add(this.contactComboBox);
            this.panel1.Controls.Add(this.endLabel);
            this.panel1.Controls.Add(this.startLabel);
            this.panel1.Controls.Add(this.urlTextBox);
            this.panel1.Controls.Add(this.urlLabel);
            this.panel1.Controls.Add(this.typeLabel);
            this.panel1.Controls.Add(this.contactLabel);
            this.panel1.Controls.Add(this.locationTextBox);
            this.panel1.Controls.Add(this.locationLabel);
            this.panel1.Controls.Add(this.descriptionTextBox);
            this.panel1.Controls.Add(this.descriptionLabel);
            this.panel1.Controls.Add(this.titleTextBox);
            this.panel1.Controls.Add(this.titleLabel);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // endTimeDatePicker
            // 
            resources.ApplyResources(this.endTimeDatePicker, "endTimeDatePicker");
            this.endTimeDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.endTimeDatePicker.Name = "endTimeDatePicker";
            this.endTimeDatePicker.ShowUpDown = true;
            // 
            // startTimeDatePicker
            // 
            resources.ApplyResources(this.startTimeDatePicker, "startTimeDatePicker");
            this.startTimeDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.startTimeDatePicker.Name = "startTimeDatePicker";
            this.startTimeDatePicker.ShowUpDown = true;
            // 
            // customerComboBox
            // 
            this.customerComboBox.DataSource = this.customerBindingSource;
            this.customerComboBox.DisplayMember = "customerName";
            this.customerComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.customerComboBox, "customerComboBox");
            this.customerComboBox.Name = "customerComboBox";
            this.customerComboBox.ValueMember = "customerName";
            // 
            // customerBindingSource
            // 
            this.customerBindingSource.DataMember = "customer";
            this.customerBindingSource.DataSource = this.client_scheduleDataSet;
            // 
            // client_scheduleDataSet
            // 
            this.client_scheduleDataSet.DataSetName = "client_scheduleDataSet";
            this.client_scheduleDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // customerLabel
            // 
            resources.ApplyResources(this.customerLabel, "customerLabel");
            this.customerLabel.Name = "customerLabel";
            // 
            // endDateTimePicker
            // 
            resources.ApplyResources(this.endDateTimePicker, "endDateTimePicker");
            this.endDateTimePicker.Name = "endDateTimePicker";
            // 
            // startDateTimePicker
            // 
            resources.ApplyResources(this.startDateTimePicker, "startDateTimePicker");
            this.startDateTimePicker.Name = "startDateTimePicker";
            // 
            // typeComboBox
            // 
            this.typeComboBox.DataSource = this.appointmentBindingSource;
            this.typeComboBox.DisplayMember = "type";
            this.typeComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.typeComboBox, "typeComboBox");
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.ValueMember = "type";
            // 
            // appointmentBindingSource
            // 
            this.appointmentBindingSource.DataMember = "appointment";
            this.appointmentBindingSource.DataSource = this.client_scheduleDataSet;
            // 
            // contactComboBox
            // 
            this.contactComboBox.DataSource = this.appointmentBindingSource;
            this.contactComboBox.DisplayMember = "contact";
            this.contactComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.contactComboBox, "contactComboBox");
            this.contactComboBox.Name = "contactComboBox";
            this.contactComboBox.ValueMember = "contact";
            // 
            // endLabel
            // 
            resources.ApplyResources(this.endLabel, "endLabel");
            this.endLabel.Name = "endLabel";
            // 
            // startLabel
            // 
            resources.ApplyResources(this.startLabel, "startLabel");
            this.startLabel.Name = "startLabel";
            // 
            // urlTextBox
            // 
            resources.ApplyResources(this.urlTextBox, "urlTextBox");
            this.urlTextBox.Name = "urlTextBox";
            // 
            // urlLabel
            // 
            resources.ApplyResources(this.urlLabel, "urlLabel");
            this.urlLabel.Name = "urlLabel";
            // 
            // typeLabel
            // 
            resources.ApplyResources(this.typeLabel, "typeLabel");
            this.typeLabel.Name = "typeLabel";
            // 
            // contactLabel
            // 
            resources.ApplyResources(this.contactLabel, "contactLabel");
            this.contactLabel.Name = "contactLabel";
            // 
            // locationTextBox
            // 
            resources.ApplyResources(this.locationTextBox, "locationTextBox");
            this.locationTextBox.Name = "locationTextBox";
            // 
            // locationLabel
            // 
            resources.ApplyResources(this.locationLabel, "locationLabel");
            this.locationLabel.Name = "locationLabel";
            // 
            // descriptionTextBox
            // 
            resources.ApplyResources(this.descriptionTextBox, "descriptionTextBox");
            this.descriptionTextBox.Name = "descriptionTextBox";
            // 
            // descriptionLabel
            // 
            resources.ApplyResources(this.descriptionLabel, "descriptionLabel");
            this.descriptionLabel.Name = "descriptionLabel";
            // 
            // titleTextBox
            // 
            resources.ApplyResources(this.titleTextBox, "titleTextBox");
            this.titleTextBox.Name = "titleTextBox";
            // 
            // appointmentBindingSource1
            // 
            this.appointmentBindingSource1.DataMember = "appointment";
            this.appointmentBindingSource1.DataSource = this.client_scheduleDataSet;
            // 
            // appointmentTableAdapter
            // 
            this.appointmentTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.addressTableAdapter = null;
            this.tableAdapterManager.appointmentTableAdapter = this.appointmentTableAdapter;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.cityTableAdapter = null;
            this.tableAdapterManager.countryTableAdapter = null;
            this.tableAdapterManager.customerTableAdapter = this.customerTableAdapter;
            this.tableAdapterManager.UpdateOrder = Scheduling_App.client_scheduleDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.userTableAdapter = null;
            // 
            // customerTableAdapter
            // 
            this.customerTableAdapter.ClearBeforeFill = true;
            // 
            // appointmentForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "appointmentForm";
            this.Load += new System.EventHandler(this.appointmentForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.client_scheduleDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Label urlLabel;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label contactLabel;
        private System.Windows.Forms.TextBox locationTextBox;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label endLabel;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.ComboBox contactComboBox;
        private Scheduling_App.client_scheduleDataSet client_scheduleDataSet;
        private System.Windows.Forms.BindingSource appointmentBindingSource;
        private Scheduling_App.client_scheduleDataSetTableAdapters.appointmentTableAdapter appointmentTableAdapter;
        private System.Windows.Forms.BindingSource appointmentBindingSource1;
        private Scheduling_App.client_scheduleDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.Label customerLabel;
        private System.Windows.Forms.ComboBox customerComboBox;
        private Scheduling_App.client_scheduleDataSetTableAdapters.customerTableAdapter customerTableAdapter;
        private System.Windows.Forms.BindingSource customerBindingSource;
        private System.Windows.Forms.DateTimePicker startTimeDatePicker;
        private System.Windows.Forms.DateTimePicker endTimeDatePicker;
    }
}