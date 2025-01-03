﻿namespace WindowsFormsApp3
{
    partial class Details_Interface
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
            this.Select_Image = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Back_button = new System.Windows.Forms.Button();
            this.Done_button = new System.Windows.Forms.Button();
            this.title_I = new System.Windows.Forms.Label();
            this.location_select = new System.Windows.Forms.ComboBox();
            this.Interests_I = new System.Windows.Forms.Label();
            this.location_I = new System.Windows.Forms.Label();
            this.dateofbirth_I = new System.Windows.Forms.Label();
            this.fullname_t = new System.Windows.Forms.TextBox();
            this.gender_l = new System.Windows.Forms.Label();
            this.fullname_l = new System.Windows.Forms.Label();
            this.username_l = new System.Windows.Forms.Label();
            this.interest_t = new System.Windows.Forms.RichTextBox();
            this.dateofbirth_t = new System.Windows.Forms.TextBox();
            this.gender_t = new System.Windows.Forms.TextBox();
            this.username_t = new System.Windows.Forms.TextBox();
            this.Image_View = new System.Windows.Forms.PictureBox();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Image_View)).BeginInit();
            this.SuspendLayout();
            // 
            // Select_Image
            // 
            this.Select_Image.Location = new System.Drawing.Point(438, 313);
            this.Select_Image.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Select_Image.Name = "Select_Image";
            this.Select_Image.Size = new System.Drawing.Size(84, 29);
            this.Select_Image.TabIndex = 55;
            this.Select_Image.Text = "Select image";
            this.Select_Image.UseVisualStyleBackColor = true;
            this.Select_Image.Click += new System.EventHandler(this.Select_Image_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(452, 254);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 54;
            this.label1.Text = "Image";
            // 
            // Back_button
            // 
            this.Back_button.Location = new System.Drawing.Point(178, 465);
            this.Back_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Back_button.Name = "Back_button";
            this.Back_button.Size = new System.Drawing.Size(219, 42);
            this.Back_button.TabIndex = 51;
            this.Back_button.Text = "Quit";
            this.Back_button.UseVisualStyleBackColor = true;
            this.Back_button.Click += new System.EventHandler(this.Back_button_Click);
            // 
            // Done_button
            // 
            this.Done_button.Location = new System.Drawing.Point(552, 465);
            this.Done_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Done_button.Name = "Done_button";
            this.Done_button.Size = new System.Drawing.Size(219, 42);
            this.Done_button.TabIndex = 50;
            this.Done_button.Text = "Done";
            this.Done_button.UseVisualStyleBackColor = true;
            this.Done_button.Click += new System.EventHandler(this.Done_button_Click);
            // 
            // title_I
            // 
            this.title_I.AutoSize = true;
            this.title_I.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_I.Location = new System.Drawing.Point(290, 11);
            this.title_I.Name = "title_I";
            this.title_I.Size = new System.Drawing.Size(327, 46);
            this.title_I.TabIndex = 49;
            this.title_I.Text = "Personal Details";
            // 
            // location_select
            // 
            this.location_select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.location_select.FormattingEnabled = true;
            this.location_select.Items.AddRange(new object[] {
            "Quận 1",
            "Quận 2",
            "Quận 3",
            "Quận 4",
            "Quận 5",
            "Quận 6",
            "Quận 7",
            "Quận 8",
            "Quận 9",
            "Quận 10",
            "Quận 11",
            "Quận 12",
            "Quận Bình Thạnh",
            "Quận Bình Tân",
            "Quận Phú Nhuận",
            "Quận Tân Bình",
            "Quận Tân Phú",
            "Quận Gò Vấp",
            "Quận Thủ Đức",
            "Huyện Củ Chi",
            "Huyện Hóc Môn",
            "Huyện Nhà Bè"});
            this.location_select.Location = new System.Drawing.Point(541, 196);
            this.location_select.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.location_select.Name = "location_select";
            this.location_select.Size = new System.Drawing.Size(231, 28);
            this.location_select.TabIndex = 47;
            // 
            // Interests_I
            // 
            this.Interests_I.AutoSize = true;
            this.Interests_I.Location = new System.Drawing.Point(54, 256);
            this.Interests_I.Name = "Interests_I";
            this.Interests_I.Size = new System.Drawing.Size(72, 20);
            this.Interests_I.TabIndex = 46;
            this.Interests_I.Text = "Interests";
            // 
            // location_I
            // 
            this.location_I.AutoSize = true;
            this.location_I.Location = new System.Drawing.Point(452, 200);
            this.location_I.Name = "location_I";
            this.location_I.Size = new System.Drawing.Size(70, 20);
            this.location_I.TabIndex = 45;
            this.location_I.Text = "Location";
            // 
            // dateofbirth_I
            // 
            this.dateofbirth_I.AutoSize = true;
            this.dateofbirth_I.Location = new System.Drawing.Point(54, 200);
            this.dateofbirth_I.Name = "dateofbirth_I";
            this.dateofbirth_I.Size = new System.Drawing.Size(99, 20);
            this.dateofbirth_I.TabIndex = 44;
            this.dateofbirth_I.Text = "Date of Birth";
            // 
            // fullname_t
            // 
            this.fullname_t.Location = new System.Drawing.Point(178, 142);
            this.fullname_t.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fullname_t.Name = "fullname_t";
            this.fullname_t.ReadOnly = true;
            this.fullname_t.Size = new System.Drawing.Size(594, 26);
            this.fullname_t.TabIndex = 43;
            // 
            // gender_l
            // 
            this.gender_l.AutoSize = true;
            this.gender_l.Location = new System.Drawing.Point(452, 98);
            this.gender_l.Name = "gender_l";
            this.gender_l.Size = new System.Drawing.Size(63, 20);
            this.gender_l.TabIndex = 41;
            this.gender_l.Text = "Gender";
            // 
            // fullname_l
            // 
            this.fullname_l.AutoSize = true;
            this.fullname_l.Location = new System.Drawing.Point(54, 145);
            this.fullname_l.Name = "fullname_l";
            this.fullname_l.Size = new System.Drawing.Size(80, 20);
            this.fullname_l.TabIndex = 40;
            this.fullname_l.Text = "Full Name";
            // 
            // username_l
            // 
            this.username_l.AutoSize = true;
            this.username_l.Location = new System.Drawing.Point(54, 95);
            this.username_l.Name = "username_l";
            this.username_l.Size = new System.Drawing.Size(89, 20);
            this.username_l.TabIndex = 39;
            this.username_l.Text = "User Name";
            // 
            // interest_t
            // 
            this.interest_t.Location = new System.Drawing.Point(178, 254);
            this.interest_t.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.interest_t.Name = "interest_t";
            this.interest_t.Size = new System.Drawing.Size(231, 180);
            this.interest_t.TabIndex = 48;
            this.interest_t.Text = "";
            // 
            // dateofbirth_t
            // 
            this.dateofbirth_t.Location = new System.Drawing.Point(178, 196);
            this.dateofbirth_t.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateofbirth_t.Name = "dateofbirth_t";
            this.dateofbirth_t.ReadOnly = true;
            this.dateofbirth_t.Size = new System.Drawing.Size(231, 26);
            this.dateofbirth_t.TabIndex = 53;
            // 
            // gender_t
            // 
            this.gender_t.Location = new System.Drawing.Point(541, 91);
            this.gender_t.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gender_t.Name = "gender_t";
            this.gender_t.ReadOnly = true;
            this.gender_t.Size = new System.Drawing.Size(231, 26);
            this.gender_t.TabIndex = 52;
            // 
            // username_t
            // 
            this.username_t.Location = new System.Drawing.Point(178, 91);
            this.username_t.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.username_t.Name = "username_t";
            this.username_t.ReadOnly = true;
            this.username_t.Size = new System.Drawing.Size(231, 26);
            this.username_t.TabIndex = 42;
            // 
            // Image_View
            // 
            this.Image_View.Location = new System.Drawing.Point(552, 254);
            this.Image_View.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Image_View.Name = "Image_View";
            this.Image_View.Size = new System.Drawing.Size(241, 182);
            this.Image_View.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Image_View.TabIndex = 56;
            this.Image_View.TabStop = false;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // Details_Interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Pink;
            this.ClientSize = new System.Drawing.Size(826, 518);
            this.Controls.Add(this.Image_View);
            this.Controls.Add(this.Select_Image);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateofbirth_t);
            this.Controls.Add(this.gender_t);
            this.Controls.Add(this.Back_button);
            this.Controls.Add(this.Done_button);
            this.Controls.Add(this.title_I);
            this.Controls.Add(this.interest_t);
            this.Controls.Add(this.location_select);
            this.Controls.Add(this.Interests_I);
            this.Controls.Add(this.location_I);
            this.Controls.Add(this.dateofbirth_I);
            this.Controls.Add(this.fullname_t);
            this.Controls.Add(this.username_t);
            this.Controls.Add(this.gender_l);
            this.Controls.Add(this.fullname_l);
            this.Controls.Add(this.username_l);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Details_Interface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Details_Interface";
            this.Load += new System.EventHandler(this.Details_Interface_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Image_View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Select_Image;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Back_button;
        private System.Windows.Forms.Button Done_button;
        private System.Windows.Forms.Label title_I;
        private System.Windows.Forms.ComboBox location_select;
        private System.Windows.Forms.Label Interests_I;
        private System.Windows.Forms.Label location_I;
        private System.Windows.Forms.Label dateofbirth_I;
        private System.Windows.Forms.TextBox fullname_t;
        private System.Windows.Forms.Label gender_l;
        private System.Windows.Forms.Label fullname_l;
        private System.Windows.Forms.Label username_l;
        private System.Windows.Forms.RichTextBox interest_t;
        private System.Windows.Forms.TextBox dateofbirth_t;
        private System.Windows.Forms.TextBox gender_t;
        private System.Windows.Forms.TextBox username_t;
        private System.Windows.Forms.PictureBox Image_View;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    }
}