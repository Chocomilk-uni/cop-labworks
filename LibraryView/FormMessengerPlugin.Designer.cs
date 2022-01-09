
namespace LibraryView
{
    partial class FormMessengerPlugin
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
            this.comboBoxAvailablePlugin = new System.Windows.Forms.ComboBox();
            this.labelAvailablePlugin = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSignIn = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboBoxAvailablePlugin
            // 
            this.comboBoxAvailablePlugin.FormattingEnabled = true;
            this.comboBoxAvailablePlugin.Location = new System.Drawing.Point(29, 40);
            this.comboBoxAvailablePlugin.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxAvailablePlugin.Name = "comboBoxAvailablePlugin";
            this.comboBoxAvailablePlugin.Size = new System.Drawing.Size(265, 24);
            this.comboBoxAvailablePlugin.TabIndex = 3;
            // 
            // labelAvailablePlugin
            // 
            this.labelAvailablePlugin.AutoSize = true;
            this.labelAvailablePlugin.Location = new System.Drawing.Point(29, 20);
            this.labelAvailablePlugin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAvailablePlugin.Name = "labelAvailablePlugin";
            this.labelAvailablePlugin.Size = new System.Drawing.Size(145, 17);
            this.labelAvailablePlugin.TabIndex = 2;
            this.labelAvailablePlugin.Text = "Доступные плагины:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Пароль:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Логин:";
            // 
            // buttonSignIn
            // 
            this.buttonSignIn.Location = new System.Drawing.Point(79, 218);
            this.buttonSignIn.Name = "buttonSignIn";
            this.buttonSignIn.Size = new System.Drawing.Size(133, 31);
            this.buttonSignIn.TabIndex = 7;
            this.buttonSignIn.Text = "Войти";
            this.buttonSignIn.UseVisualStyleBackColor = true;
            this.buttonSignIn.Click += new System.EventHandler(this.ButtonSignIn_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(35, 175);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(210, 22);
            this.textBoxPassword.TabIndex = 6;
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(35, 112);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(210, 22);
            this.textBoxLogin.TabIndex = 5;
            // 
            // FormMessengerPlugin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 274);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSignIn);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.comboBoxAvailablePlugin);
            this.Controls.Add(this.labelAvailablePlugin);
            this.Name = "FormMessengerPlugin";
            this.Text = "Авторизация";
            this.Load += new System.EventHandler(this.FormMessengerPlugin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxAvailablePlugin;
        private System.Windows.Forms.Label labelAvailablePlugin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSignIn;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxLogin;
    }
}