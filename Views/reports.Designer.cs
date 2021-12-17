
namespace Scheduling_App.Views
{
    partial class reportsForm
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
            System.Windows.Forms.Label customerNameLabel;
            this.reports = new System.Windows.Forms.TabControl();
            this.apptByType = new System.Windows.Forms.TabPage();
            this.apptsByType = new System.Windows.Forms.DataGridView();
            this.userSchedule = new System.Windows.Forms.TabPage();
            this.userApptsSchedule = new System.Windows.Forms.DataGridView();
            this.customerAppts = new System.Windows.Forms.TabPage();
            this.customerNameComboBox = new System.Windows.Forms.ComboBox();
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.client_scheduleDataSet = new Scheduling_App.client_scheduleDataSet();
            this.customerApptsSchedule = new System.Windows.Forms.DataGridView();
            this.tableAdapterManager = new Scheduling_App.client_scheduleDataSetTableAdapters.TableAdapterManager();
            this.appointmentTableAdapter = new Scheduling_App.client_scheduleDataSetTableAdapters.appointmentTableAdapter();
            this.backButton = new System.Windows.Forms.Button();
            this.customerTableAdapter = new Scheduling_App.client_scheduleDataSetTableAdapters.customerTableAdapter();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userTableAdapter = new Scheduling_App.client_scheduleDataSetTableAdapters.userTableAdapter();
            this.userNameLabel = new System.Windows.Forms.Label();
            customerNameLabel = new System.Windows.Forms.Label();
            this.reports.SuspendLayout();
            this.apptByType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.apptsByType)).BeginInit();
            this.userSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userApptsSchedule)).BeginInit();
            this.customerAppts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.client_scheduleDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerApptsSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // customerNameLabel
            // 
            customerNameLabel.AutoSize = true;
            customerNameLabel.Location = new System.Drawing.Point(411, 38);
            customerNameLabel.Name = "customerNameLabel";
            customerNameLabel.Size = new System.Drawing.Size(84, 13);
            customerNameLabel.TabIndex = 1;
            customerNameLabel.Text = "customer Name:";
            // 
            // reports
            // 
            this.reports.Controls.Add(this.apptByType);
            this.reports.Controls.Add(this.userSchedule);
            this.reports.Controls.Add(this.customerAppts);
            this.reports.Location = new System.Drawing.Point(12, 42);
            this.reports.Name = "reports";
            this.reports.SelectedIndex = 0;
            this.reports.Size = new System.Drawing.Size(715, 512);
            this.reports.TabIndex = 0;
            this.reports.SelectedIndexChanged += new System.EventHandler(this.reports_SelectedIndexChanged);
            // 
            // apptByType
            // 
            this.apptByType.Controls.Add(this.apptsByType);
            this.apptByType.Location = new System.Drawing.Point(4, 22);
            this.apptByType.Name = "apptByType";
            this.apptByType.Padding = new System.Windows.Forms.Padding(3);
            this.apptByType.Size = new System.Drawing.Size(707, 486);
            this.apptByType.TabIndex = 0;
            this.apptByType.Text = "Appointments By Month";
            this.apptByType.UseVisualStyleBackColor = true;
            // 
            // apptsByType
            // 
            this.apptsByType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.apptsByType.Location = new System.Drawing.Point(3, 59);
            this.apptsByType.Name = "apptsByType";
            this.apptsByType.Size = new System.Drawing.Size(701, 424);
            this.apptsByType.TabIndex = 0;
            // 
            // userSchedule
            // 
            this.userSchedule.Controls.Add(this.userApptsSchedule);
            this.userSchedule.Location = new System.Drawing.Point(4, 22);
            this.userSchedule.Name = "userSchedule";
            this.userSchedule.Padding = new System.Windows.Forms.Padding(3);
            this.userSchedule.Size = new System.Drawing.Size(707, 486);
            this.userSchedule.TabIndex = 1;
            this.userSchedule.Text = "Schedule";
            this.userSchedule.UseVisualStyleBackColor = true;
            // 
            // userApptsSchedule
            // 
            this.userApptsSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userApptsSchedule.Location = new System.Drawing.Point(3, 59);
            this.userApptsSchedule.Name = "userApptsSchedule";
            this.userApptsSchedule.Size = new System.Drawing.Size(701, 424);
            this.userApptsSchedule.TabIndex = 1;
            // 
            // customerAppts
            // 
            this.customerAppts.AutoScroll = true;
            this.customerAppts.Controls.Add(customerNameLabel);
            this.customerAppts.Controls.Add(this.customerNameComboBox);
            this.customerAppts.Controls.Add(this.customerApptsSchedule);
            this.customerAppts.Location = new System.Drawing.Point(4, 22);
            this.customerAppts.Name = "customerAppts";
            this.customerAppts.Size = new System.Drawing.Size(707, 486);
            this.customerAppts.TabIndex = 2;
            this.customerAppts.Text = "Customer Schedule";
            this.customerAppts.UseVisualStyleBackColor = true;
            // 
            // customerNameComboBox
            // 
            this.customerNameComboBox.DataSource = this.customerBindingSource;
            this.customerNameComboBox.DisplayMember = "customerName";
            this.customerNameComboBox.FormattingEnabled = true;
            this.customerNameComboBox.Location = new System.Drawing.Point(501, 35);
            this.customerNameComboBox.Name = "customerNameComboBox";
            this.customerNameComboBox.Size = new System.Drawing.Size(121, 21);
            this.customerNameComboBox.TabIndex = 2;
            this.customerNameComboBox.ValueMember = "customerName";
            this.customerNameComboBox.SelectedIndexChanged += new System.EventHandler(this.customerNameComboBox_SelectedIndexChanged);
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
            // customerApptsSchedule
            // 
            this.customerApptsSchedule.AllowUserToAddRows = false;
            this.customerApptsSchedule.AllowUserToDeleteRows = false;
            this.customerApptsSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerApptsSchedule.Location = new System.Drawing.Point(3, 59);
            this.customerApptsSchedule.Name = "customerApptsSchedule";
            this.customerApptsSchedule.ReadOnly = true;
            this.customerApptsSchedule.Size = new System.Drawing.Size(701, 424);
            this.customerApptsSchedule.TabIndex = 1;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.addressTableAdapter = null;
            this.tableAdapterManager.appointmentTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.cityTableAdapter = null;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.countryTableAdapter = null;
            this.tableAdapterManager.customerTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Scheduling_App.client_scheduleDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.userTableAdapter = null;
            // 
            // appointmentTableAdapter
            // 
            this.appointmentTableAdapter.ClearBeforeFill = true;
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(645, 12);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // customerTableAdapter
            // 
            this.customerTableAdapter.ClearBeforeFill = true;
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataMember = "user";
            this.userBindingSource.DataSource = this.client_scheduleDataSet;
            // 
            // userTableAdapter
            // 
            this.userTableAdapter.ClearBeforeFill = true;
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameLabel.Location = new System.Drawing.Point(16, 12);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(40, 20);
            this.userNameLabel.TabIndex = 2;
            this.userNameLabel.Text = "user";
            // 
            // reportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 574);
            this.Controls.Add(this.userNameLabel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.reports);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "reportsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "reportsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.reportsForm_FormClosing);
            this.Load += new System.EventHandler(this.reportsForm_Load);
            this.reports.ResumeLayout(false);
            this.apptByType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.apptsByType)).EndInit();
            this.userSchedule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userApptsSchedule)).EndInit();
            this.customerAppts.ResumeLayout(false);
            this.customerAppts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.client_scheduleDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerApptsSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl reports;
        private System.Windows.Forms.TabPage apptByType;
        private System.Windows.Forms.TabPage userSchedule;
        private System.Windows.Forms.TabPage customerAppts;
        private System.Windows.Forms.DataGridView apptsByType;
        private System.Windows.Forms.DataGridView userApptsSchedule;
        private System.Windows.Forms.DataGridView customerApptsSchedule;
        private client_scheduleDataSet client_scheduleDataSet;
        private client_scheduleDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private client_scheduleDataSetTableAdapters.appointmentTableAdapter appointmentTableAdapter;
        private System.Windows.Forms.Button backButton;
        private client_scheduleDataSetTableAdapters.customerTableAdapter customerTableAdapter;
        private System.Windows.Forms.BindingSource customerBindingSource;
        private System.Windows.Forms.ComboBox customerNameComboBox;
        private System.Windows.Forms.BindingSource userBindingSource;
        private client_scheduleDataSetTableAdapters.userTableAdapter userTableAdapter;
        private System.Windows.Forms.Label userNameLabel;
    }
}