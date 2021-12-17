namespace Scheduling_Application.Views
{
    partial class calendarForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(calendarForm));
            this.appointmentButton = new System.Windows.Forms.Button();
            this.customerButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.reportButton = new System.Windows.Forms.Button();
            this.appointmentContainer = new System.Windows.Forms.TabControl();
            this.weeklyView = new System.Windows.Forms.TabPage();
            this.weeklyAppointmentsDGV = new System.Windows.Forms.DataGridView();
            this.monthlyView = new System.Windows.Forms.TabPage();
            this.monthlyAppointmentsDGV = new System.Windows.Forms.DataGridView();
            this.appointmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.client_scheduleDataSet = new Scheduling_App.client_scheduleDataSet();
            this.removeButton = new System.Windows.Forms.Button();
            this.appointmentTableAdapter = new Scheduling_App.client_scheduleDataSetTableAdapters.appointmentTableAdapter();
            this.appointmentContainer.SuspendLayout();
            this.weeklyView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weeklyAppointmentsDGV)).BeginInit();
            this.monthlyView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monthlyAppointmentsDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.client_scheduleDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // appointmentButton
            // 
            resources.ApplyResources(this.appointmentButton, "appointmentButton");
            this.appointmentButton.Name = "appointmentButton";
            this.appointmentButton.UseVisualStyleBackColor = true;
            this.appointmentButton.Click += new System.EventHandler(this.appointmentButton_Click);
            // 
            // customerButton
            // 
            resources.ApplyResources(this.customerButton, "customerButton");
            this.customerButton.Name = "customerButton";
            this.customerButton.UseVisualStyleBackColor = true;
            this.customerButton.Click += new System.EventHandler(this.customerButton_Click);
            // 
            // logoutButton
            // 
            resources.ApplyResources(this.logoutButton, "logoutButton");
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // reportButton
            // 
            resources.ApplyResources(this.reportButton, "reportButton");
            this.reportButton.Name = "reportButton";
            this.reportButton.UseVisualStyleBackColor = true;
            this.reportButton.Click += new System.EventHandler(this.reportButton_Click);
            // 
            // appointmentContainer
            // 
            this.appointmentContainer.Controls.Add(this.weeklyView);
            this.appointmentContainer.Controls.Add(this.monthlyView);
            resources.ApplyResources(this.appointmentContainer, "appointmentContainer");
            this.appointmentContainer.Name = "appointmentContainer";
            this.appointmentContainer.SelectedIndex = 0;
            this.appointmentContainer.SelectedIndexChanged += new System.EventHandler(this.appointmentContainer_SelectedIndexChanged);
            this.appointmentContainer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.appointmentContainer_MouseDown);
            // 
            // weeklyView
            // 
            this.weeklyView.Controls.Add(this.weeklyAppointmentsDGV);
            resources.ApplyResources(this.weeklyView, "weeklyView");
            this.weeklyView.Name = "weeklyView";
            this.weeklyView.UseVisualStyleBackColor = true;
            // 
            // weeklyAppointmentsDGV
            // 
            this.weeklyAppointmentsDGV.AllowUserToAddRows = false;
            this.weeklyAppointmentsDGV.AllowUserToDeleteRows = false;
            this.weeklyAppointmentsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.weeklyAppointmentsDGV, "weeklyAppointmentsDGV");
            this.weeklyAppointmentsDGV.Name = "weeklyAppointmentsDGV";
            this.weeklyAppointmentsDGV.ReadOnly = true;
            this.weeklyAppointmentsDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.weeklyAppointmentsDGV_CellClick);
            this.weeklyAppointmentsDGV.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.weeklyAppointmentsDGV_CellFormatting);
            // 
            // monthlyView
            // 
            this.monthlyView.Controls.Add(this.monthlyAppointmentsDGV);
            resources.ApplyResources(this.monthlyView, "monthlyView");
            this.monthlyView.Name = "monthlyView";
            this.monthlyView.UseVisualStyleBackColor = true;
            // 
            // monthlyAppointmentsDGV
            // 
            this.monthlyAppointmentsDGV.AllowUserToAddRows = false;
            this.monthlyAppointmentsDGV.AllowUserToDeleteRows = false;
            this.monthlyAppointmentsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.monthlyAppointmentsDGV, "monthlyAppointmentsDGV");
            this.monthlyAppointmentsDGV.Name = "monthlyAppointmentsDGV";
            this.monthlyAppointmentsDGV.ReadOnly = true;
            this.monthlyAppointmentsDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.monthlyAppointmentsDGV_CellClick);
            this.monthlyAppointmentsDGV.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.monthlyAppointmentsDGV_CellFormatting);
            // 
            // appointmentBindingSource
            // 
            this.appointmentBindingSource.DataMember = "appointment";
            this.appointmentBindingSource.DataSource = this.client_scheduleDataSet;
            // 
            // client_scheduleDataSet
            // 
            this.client_scheduleDataSet.DataSetName = "client_scheduleDataSet";
            this.client_scheduleDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // removeButton
            // 
            resources.ApplyResources(this.removeButton, "removeButton");
            this.removeButton.Name = "removeButton";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // appointmentTableAdapter
            // 
            this.appointmentTableAdapter.ClearBeforeFill = true;
            // 
            // calendarForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.appointmentContainer);
            this.Controls.Add(this.reportButton);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.customerButton);
            this.Controls.Add(this.appointmentButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "calendarForm";
            this.Load += new System.EventHandler(this.calendarForm_Load);
            this.Click += new System.EventHandler(this.calendarForm_Click);
            this.appointmentContainer.ResumeLayout(false);
            this.weeklyView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.weeklyAppointmentsDGV)).EndInit();
            this.monthlyView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.monthlyAppointmentsDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.client_scheduleDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button appointmentButton;
        private System.Windows.Forms.Button customerButton;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Button reportButton;
        private System.Windows.Forms.TabControl appointmentContainer;
        private System.Windows.Forms.TabPage weeklyView;
        private System.Windows.Forms.DataGridView weeklyAppointmentsDGV;
        private System.Windows.Forms.TabPage monthlyView;
        private System.Windows.Forms.DataGridView monthlyAppointmentsDGV;
        private Scheduling_App.client_scheduleDataSet client_scheduleDataSet;
        private System.Windows.Forms.BindingSource appointmentBindingSource;
        private Scheduling_App.client_scheduleDataSetTableAdapters.appointmentTableAdapter appointmentTableAdapter;
        private System.Windows.Forms.Button removeButton;
    }
}