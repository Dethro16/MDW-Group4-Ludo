namespace Mdw
{
    partial class LudoRegisterGUI
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
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbRePassword = new System.Windows.Forms.TextBox();
            this.btCancel = new System.Windows.Forms.Button();
            this.pbDragDrop = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btRegister = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbDragDrop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbUsername
            // 
            this.tbUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUsername.Location = new System.Drawing.Point(12, 73);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(210, 26);
            this.tbUsername.TabIndex = 5;
            // 
            // tbPassword
            // 
            this.tbPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.Location = new System.Drawing.Point(12, 140);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(210, 26);
            this.tbPassword.TabIndex = 6;
            // 
            // tbRePassword
            // 
            this.tbRePassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRePassword.Location = new System.Drawing.Point(12, 207);
            this.tbRePassword.Name = "tbRePassword";
            this.tbRePassword.Size = new System.Drawing.Size(210, 26);
            this.tbRePassword.TabIndex = 7;
            // 
            // btCancel
            // 
            this.btCancel.BackColor = System.Drawing.Color.Transparent;
            this.btCancel.BackgroundImage = global::Mdw.Properties.Resources.RCancel;
            this.btCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btCancel.FlatAppearance.BorderSize = 0;
            this.btCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Location = new System.Drawing.Point(163, 307);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(108, 60);
            this.btCancel.TabIndex = 8;
            this.btCancel.UseVisualStyleBackColor = false;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // pbDragDrop
            // 
            this.pbDragDrop.BackColor = System.Drawing.Color.Transparent;
            this.pbDragDrop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbDragDrop.Location = new System.Drawing.Point(0, 0);
            this.pbDragDrop.Name = "pbDragDrop";
            this.pbDragDrop.Size = new System.Drawing.Size(302, 32);
            this.pbDragDrop.TabIndex = 9;
            this.pbDragDrop.TabStop = false;
            this.pbDragDrop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbDragDrop_MouseDown);
            this.pbDragDrop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbDragDrop_MouseMove);
            this.pbDragDrop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbDragDrop_MouseUp);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = global::Mdw.Properties.Resources.rePassword;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Location = new System.Drawing.Point(12, 172);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(154, 29);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::Mdw.Properties.Resources.Password;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(12, 105);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(154, 29);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::Mdw.Properties.Resources.Username;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(12, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(154, 29);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btRegister
            // 
            this.btRegister.BackColor = System.Drawing.Color.Transparent;
            this.btRegister.BackgroundImage = global::Mdw.Properties.Resources.Register;
            this.btRegister.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btRegister.FlatAppearance.BorderSize = 0;
            this.btRegister.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btRegister.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRegister.Location = new System.Drawing.Point(27, 307);
            this.btRegister.Name = "btRegister";
            this.btRegister.Size = new System.Drawing.Size(108, 60);
            this.btRegister.TabIndex = 10;
            this.btRegister.UseVisualStyleBackColor = false;
            this.btRegister.Click += new System.EventHandler(this.btRegister_Click);
            // 
            // RegisterGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Mdw.Properties.Resources.registerbg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(302, 388);
            this.Controls.Add(this.btRegister);
            this.Controls.Add(this.pbDragDrop);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.tbRePassword);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegisterGUI";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbDragDrop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbRePassword;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.PictureBox pbDragDrop;
        private System.Windows.Forms.Button btRegister;
    }
}