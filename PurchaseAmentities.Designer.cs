﻿namespace Modul5A
{
    partial class PurchaseAmentities
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBR = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnShowBR = new System.Windows.Forms.Button();
            this.txtTicketInfo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.Label();
            this.txtPPNum = new System.Windows.Forms.Label();
            this.txtCabinClass = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lb_it_selected = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Booking Reference:";
            // 
            // txtBR
            // 
            this.txtBR.Location = new System.Drawing.Point(120, 17);
            this.txtBR.Name = "txtBR";
            this.txtBR.Size = new System.Drawing.Size(139, 20);
            this.txtBR.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(277, 15);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnShowBR);
            this.groupBox1.Controls.Add(this.txtTicketInfo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(20, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(605, 66);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Flight list";
            // 
            // btnShowBR
            // 
            this.btnShowBR.Location = new System.Drawing.Point(494, 21);
            this.btnShowBR.Name = "btnShowBR";
            this.btnShowBR.Size = new System.Drawing.Size(75, 23);
            this.btnShowBR.TabIndex = 2;
            this.btnShowBR.Text = "Show Amenities";
            this.btnShowBR.UseVisualStyleBackColor = true;
            // 
            // txtTicketInfo
            // 
            this.txtTicketInfo.FormattingEnabled = true;
            this.txtTicketInfo.Location = new System.Drawing.Point(148, 23);
            this.txtTicketInfo.Name = "txtTicketInfo";
            this.txtTicketInfo.Size = new System.Drawing.Size(330, 21);
            this.txtTicketInfo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Choose your flights:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Full name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(208, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Passport :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Your cabin class is:";
            // 
            // txtName
            // 
            this.txtName.AutoSize = true;
            this.txtName.Location = new System.Drawing.Point(78, 135);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(0, 13);
            this.txtName.TabIndex = 7;
            // 
            // txtPPNum
            // 
            this.txtPPNum.AutoSize = true;
            this.txtPPNum.Location = new System.Drawing.Point(255, 135);
            this.txtPPNum.Name = "txtPPNum";
            this.txtPPNum.Size = new System.Drawing.Size(0, 13);
            this.txtPPNum.TabIndex = 8;
            // 
            // txtCabinClass
            // 
            this.txtCabinClass.AutoSize = true;
            this.txtCabinClass.Location = new System.Drawing.Point(117, 158);
            this.txtCabinClass.Name = "txtCabinClass";
            this.txtCabinClass.Size = new System.Drawing.Size(0, 13);
            this.txtCabinClass.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(20, 183);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(605, 118);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "AMONIC Airlines Amenities";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 314);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Items selected:";
            // 
            // lb_it_selected
            // 
            this.lb_it_selected.AutoSize = true;
            this.lb_it_selected.Location = new System.Drawing.Point(101, 314);
            this.lb_it_selected.Name = "lb_it_selected";
            this.lb_it_selected.Size = new System.Drawing.Size(35, 13);
            this.lb_it_selected.TabIndex = 11;
            this.lb_it_selected.Text = "label7";
            // 
            // PurchaseAmentities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 391);
            this.Controls.Add(this.lb_it_selected);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtCabinClass);
            this.Controls.Add(this.txtPPNum);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtBR);
            this.Controls.Add(this.label1);
            this.Name = "PurchaseAmentities";
            this.Text = "Purchase Amenites";
            this.Load += new System.EventHandler(this.PurchaseAmentities_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBR;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnShowBR;
        private System.Windows.Forms.ComboBox txtTicketInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label txtName;
        private System.Windows.Forms.Label txtPPNum;
        private System.Windows.Forms.Label txtCabinClass;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lb_it_selected;
    }
}