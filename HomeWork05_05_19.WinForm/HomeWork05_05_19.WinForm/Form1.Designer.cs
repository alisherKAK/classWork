namespace HomeWork05_05_19.WinForm
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.CitiesComboBox = new System.Windows.Forms.ComboBox();
            this.CitiesLabel = new System.Windows.Forms.Label();
            this.CityPhoneCodeLabel = new System.Windows.Forms.Label();
            this.UserPhoneNumberTextBox = new System.Windows.Forms.TextBox();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.CityPhoneNumberLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CitiesComboBox
            // 
            this.CitiesComboBox.FormattingEnabled = true;
            this.CitiesComboBox.Location = new System.Drawing.Point(12, 24);
            this.CitiesComboBox.Name = "CitiesComboBox";
            this.CitiesComboBox.Size = new System.Drawing.Size(209, 21);
            this.CitiesComboBox.TabIndex = 0;
            this.CitiesComboBox.SelectedValueChanged += new System.EventHandler(this.CitiesComboBox_SelectedValueChanged);
            // 
            // CitiesLabel
            // 
            this.CitiesLabel.AutoSize = true;
            this.CitiesLabel.Location = new System.Drawing.Point(12, 8);
            this.CitiesLabel.Name = "CitiesLabel";
            this.CitiesLabel.Size = new System.Drawing.Size(32, 13);
            this.CitiesLabel.TabIndex = 1;
            this.CitiesLabel.Text = "Cities";
            // 
            // CityPhoneCodeLabel
            // 
            this.CityPhoneCodeLabel.AutoSize = true;
            this.CityPhoneCodeLabel.Location = new System.Drawing.Point(227, 28);
            this.CityPhoneCodeLabel.Name = "CityPhoneCodeLabel";
            this.CityPhoneCodeLabel.Size = new System.Drawing.Size(42, 13);
            this.CityPhoneCodeLabel.TabIndex = 2;
            this.CityPhoneCodeLabel.Text = "XXXXX";
            // 
            // UserPhoneNumberTextBox
            // 
            this.UserPhoneNumberTextBox.Location = new System.Drawing.Point(268, 25);
            this.UserPhoneNumberTextBox.Name = "UserPhoneNumberTextBox";
            this.UserPhoneNumberTextBox.Size = new System.Drawing.Size(208, 20);
            this.UserPhoneNumberTextBox.TabIndex = 3;
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Location = new System.Drawing.Point(482, 25);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(206, 20);
            this.UsernameTextBox.TabIndex = 4;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(479, 9);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(55, 13);
            this.UsernameLabel.TabIndex = 5;
            this.UsernameLabel.Text = "Username";
            // 
            // CityPhoneNumberLabel
            // 
            this.CityPhoneNumberLabel.AutoSize = true;
            this.CityPhoneNumberLabel.Location = new System.Drawing.Point(265, 9);
            this.CityPhoneNumberLabel.Name = "CityPhoneNumberLabel";
            this.CityPhoneNumberLabel.Size = new System.Drawing.Size(92, 13);
            this.CityPhoneNumberLabel.TabIndex = 6;
            this.CityPhoneNumberLabel.Text = "CityPhoneNumber";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(570, 57);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(117, 29);
            this.SaveButton.TabIndex = 7;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 97);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CityPhoneNumberLabel);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.UsernameTextBox);
            this.Controls.Add(this.UserPhoneNumberTextBox);
            this.Controls.Add(this.CityPhoneCodeLabel);
            this.Controls.Add(this.CitiesLabel);
            this.Controls.Add(this.CitiesComboBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CitiesComboBox;
        private System.Windows.Forms.Label CitiesLabel;
        private System.Windows.Forms.Label CityPhoneCodeLabel;
        private System.Windows.Forms.TextBox UserPhoneNumberTextBox;
        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label CityPhoneNumberLabel;
        private System.Windows.Forms.Button SaveButton;
    }
}

