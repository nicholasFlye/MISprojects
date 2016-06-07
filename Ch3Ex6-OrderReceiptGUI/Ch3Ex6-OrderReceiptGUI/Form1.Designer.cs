namespace Ch3Ex6_OrderReceiptGUI
{
    partial class Form1
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtStreetAddress = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtState = new System.Windows.Forms.TextBox();
            this.txtZip = new System.Windows.Forms.TextBox();
            this.txtOrder = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblStreetAddress = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.lblOrdered = new System.Windows.Forms.Label();
            this.lblUnitPrice = new System.Windows.Forms.Label();
            this.lblSalesTax = new System.Windows.Forms.Label();
            this.lblBeforeTax = new System.Windows.Forms.Label();
            this.lblNetDue = new System.Windows.Forms.Label();
            this.lblSalesTaxC = new System.Windows.Forms.Label();
            this.lblBeforeTaxC = new System.Windows.Forms.Label();
            this.lblNetDueC = new System.Windows.Forms.Label();
            this.lblZip = new System.Windows.Forms.Label();
            this.lblOrderCompletionStatus = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(242, 109);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(338, 31);
            this.txtName.TabIndex = 0;
            // 
            // txtStreetAddress
            // 
            this.txtStreetAddress.Location = new System.Drawing.Point(242, 188);
            this.txtStreetAddress.Name = "txtStreetAddress";
            this.txtStreetAddress.Size = new System.Drawing.Size(338, 31);
            this.txtStreetAddress.TabIndex = 1;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(242, 270);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(338, 31);
            this.txtCity.TabIndex = 2;
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(242, 350);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(338, 31);
            this.txtState.TabIndex = 3;
            // 
            // txtZip
            // 
            this.txtZip.Location = new System.Drawing.Point(242, 434);
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(189, 31);
            this.txtZip.TabIndex = 4;
            // 
            // txtOrder
            // 
            this.txtOrder.Location = new System.Drawing.Point(242, 545);
            this.txtOrder.Name = "txtOrder";
            this.txtOrder.Size = new System.Drawing.Size(189, 31);
            this.txtOrder.TabIndex = 5;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(146, 112);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(74, 25);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Name:";
            // 
            // lblStreetAddress
            // 
            this.lblStreetAddress.AutoSize = true;
            this.lblStreetAddress.Location = new System.Drawing.Point(62, 191);
            this.lblStreetAddress.Name = "lblStreetAddress";
            this.lblStreetAddress.Size = new System.Drawing.Size(158, 25);
            this.lblStreetAddress.TabIndex = 8;
            this.lblStreetAddress.Text = "Street address:";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(165, 273);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(55, 25);
            this.lblCity.TabIndex = 9;
            this.lblCity.Text = "City:";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(152, 353);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(68, 25);
            this.lblState.TabIndex = 10;
            this.lblState.Text = "State:";
            // 
            // lblOrdered
            // 
            this.lblOrdered.AutoSize = true;
            this.lblOrdered.Location = new System.Drawing.Point(106, 548);
            this.lblOrdered.Name = "lblOrdered";
            this.lblOrdered.Size = new System.Drawing.Size(114, 25);
            this.lblOrdered.TabIndex = 12;
            this.lblOrdered.Text = "# Ordered:";
            // 
            // lblUnitPrice
            // 
            this.lblUnitPrice.AutoSize = true;
            this.lblUnitPrice.Location = new System.Drawing.Point(462, 548);
            this.lblUnitPrice.Name = "lblUnitPrice";
            this.lblUnitPrice.Size = new System.Drawing.Size(95, 25);
            this.lblUnitPrice.TabIndex = 13;
            this.lblUnitPrice.Text = "x $39.95";
            // 
            // lblSalesTax
            // 
            this.lblSalesTax.AutoSize = true;
            this.lblSalesTax.Location = new System.Drawing.Point(355, 633);
            this.lblSalesTax.Name = "lblSalesTax";
            this.lblSalesTax.Size = new System.Drawing.Size(107, 25);
            this.lblSalesTax.TabIndex = 14;
            this.lblSalesTax.Text = "Sales tax:";
            // 
            // lblBeforeTax
            // 
            this.lblBeforeTax.AutoSize = true;
            this.lblBeforeTax.Location = new System.Drawing.Point(346, 704);
            this.lblBeforeTax.Name = "lblBeforeTax";
            this.lblBeforeTax.Size = new System.Drawing.Size(116, 25);
            this.lblBeforeTax.TabIndex = 15;
            this.lblBeforeTax.Text = "Before tax:";
            // 
            // lblNetDue
            // 
            this.lblNetDue.AutoSize = true;
            this.lblNetDue.Location = new System.Drawing.Point(369, 766);
            this.lblNetDue.Name = "lblNetDue";
            this.lblNetDue.Size = new System.Drawing.Size(93, 25);
            this.lblNetDue.TabIndex = 16;
            this.lblNetDue.Text = "Net due:";
            // 
            // lblRealSalesTax
            // 
            this.lblSalesTaxC.AutoSize = true;
            this.lblSalesTaxC.Location = new System.Drawing.Point(491, 632);
            this.lblSalesTaxC.Name = "lblRealSalesTax";
            this.lblSalesTaxC.Size = new System.Drawing.Size(66, 25);
            this.lblSalesTaxC.TabIndex = 17;
            this.lblSalesTaxC.Text = "$0.00";
            // 
            // lblRealBeforeTax
            // 
            this.lblBeforeTaxC.AutoSize = true;
            this.lblBeforeTaxC.Location = new System.Drawing.Point(491, 704);
            this.lblBeforeTaxC.Name = "lblRealBeforeTax";
            this.lblBeforeTaxC.Size = new System.Drawing.Size(66, 25);
            this.lblBeforeTaxC.TabIndex = 18;
            this.lblBeforeTaxC.Text = "$0.00";
            // 
            // lblRealNetDue
            // 
            this.lblNetDueC.AutoSize = true;
            this.lblNetDueC.Location = new System.Drawing.Point(491, 766);
            this.lblNetDueC.Name = "lblRealNetDue";
            this.lblNetDueC.Size = new System.Drawing.Size(66, 25);
            this.lblNetDueC.TabIndex = 19;
            this.lblNetDueC.Text = "$0.00";
            // 
            // lblZip
            // 
            this.lblZip.AutoSize = true;
            this.lblZip.Location = new System.Drawing.Point(119, 437);
            this.lblZip.Name = "lblZip";
            this.lblZip.Size = new System.Drawing.Size(101, 25);
            this.lblZip.TabIndex = 20;
            this.lblZip.Text = "Zip code:";
            // 
            // lblCompleteOrder
            // 
            this.lblOrderCompletionStatus.AutoSize = true;
            this.lblOrderCompletionStatus.Location = new System.Drawing.Point(266, 833);
            this.lblOrderCompletionStatus.Name = "lblCompleteOrder";
            this.lblOrderCompletionStatus.Size = new System.Drawing.Size(0, 25);
            this.lblOrderCompletionStatus.TabIndex = 21;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(111, 755);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(206, 47);
            this.button1.TabIndex = 22;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 903);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblOrderCompletionStatus);
            this.Controls.Add(this.lblZip);
            this.Controls.Add(this.lblNetDueC);
            this.Controls.Add(this.lblBeforeTaxC);
            this.Controls.Add(this.lblSalesTaxC);
            this.Controls.Add(this.lblNetDue);
            this.Controls.Add(this.lblBeforeTax);
            this.Controls.Add(this.lblSalesTax);
            this.Controls.Add(this.lblUnitPrice);
            this.Controls.Add(this.lblOrdered);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.lblStreetAddress);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtOrder);
            this.Controls.Add(this.txtZip);
            this.Controls.Add(this.txtState);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.txtStreetAddress);
            this.Controls.Add(this.txtName);
            this.Name = "Form1";
            this.Text = "Blender Order Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtStreetAddress;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.TextBox txtZip;
        private System.Windows.Forms.TextBox txtOrder;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblOrdered;
        private System.Windows.Forms.Label lblStreetAddress;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblUnitPrice;
        private System.Windows.Forms.Label lblSalesTax;
        private System.Windows.Forms.Label lblBeforeTax;
        private System.Windows.Forms.Label lblNetDue;
        private System.Windows.Forms.Label lblSalesTaxC;
        private System.Windows.Forms.Label lblBeforeTaxC;
        private System.Windows.Forms.Label lblNetDueC;
        private System.Windows.Forms.Label lblZip;
        private System.Windows.Forms.Label lblOrderCompletionStatus;
        private System.Windows.Forms.Button button1;
    }
}

