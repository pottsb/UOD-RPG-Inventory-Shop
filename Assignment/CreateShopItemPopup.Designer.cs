
namespace Assignment
{
    partial class CreateShopItemPopup
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
            this.lblName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tbCost = new System.Windows.Forms.TextBox();
            this.lblCost = new System.Windows.Forms.Label();
            this.tbWeight = new System.Windows.Forms.TextBox();
            this.lblWeight = new System.Windows.Forms.Label();
            this.tbCleaningMagic = new System.Windows.Forms.TextBox();
            this.lblCleaningMagic = new System.Windows.Forms.Label();
            this.tbProtectiveMagic = new System.Windows.Forms.TextBox();
            this.lblProtectiveMagic = new System.Windows.Forms.Label();
            this.lblItelType = new System.Windows.Forms.Label();
            this.cbItemType = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(35, 65);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(39, 15);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(145, 65);
            this.tbName.MaxLength = 25;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(205, 23);
            this.tbName.TabIndex = 1;
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(145, 94);
            this.tbDescription.MaxLength = 100;
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(205, 72);
            this.tbDescription.TabIndex = 3;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(35, 94);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(67, 15);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Description";
            // 
            // tbCost
            // 
            this.tbCost.Location = new System.Drawing.Point(145, 172);
            this.tbCost.MaxLength = 3;
            this.tbCost.Name = "tbCost";
            this.tbCost.Size = new System.Drawing.Size(100, 23);
            this.tbCost.TabIndex = 5;
            this.tbCost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCost_KeyPress);
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Location = new System.Drawing.Point(35, 172);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(31, 15);
            this.lblCost.TabIndex = 4;
            this.lblCost.Text = "Cost";
            // 
            // tbWeight
            // 
            this.tbWeight.Location = new System.Drawing.Point(145, 201);
            this.tbWeight.MaxLength = 3;
            this.tbWeight.Name = "tbWeight";
            this.tbWeight.Size = new System.Drawing.Size(100, 23);
            this.tbWeight.TabIndex = 7;
            this.tbWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbWeight_KeyPress);
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Location = new System.Drawing.Point(35, 201);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(45, 15);
            this.lblWeight.TabIndex = 6;
            this.lblWeight.Text = "Weight";
            // 
            // tbCleaningMagic
            // 
            this.tbCleaningMagic.Location = new System.Drawing.Point(145, 230);
            this.tbCleaningMagic.MaxLength = 3;
            this.tbCleaningMagic.Name = "tbCleaningMagic";
            this.tbCleaningMagic.Size = new System.Drawing.Size(100, 23);
            this.tbCleaningMagic.TabIndex = 9;
            this.tbCleaningMagic.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCleaningMagic_KeyPress);
            // 
            // lblCleaningMagic
            // 
            this.lblCleaningMagic.AutoSize = true;
            this.lblCleaningMagic.Location = new System.Drawing.Point(35, 230);
            this.lblCleaningMagic.Name = "lblCleaningMagic";
            this.lblCleaningMagic.Size = new System.Drawing.Size(87, 15);
            this.lblCleaningMagic.TabIndex = 8;
            this.lblCleaningMagic.Text = "CleaningMagic";
            // 
            // tbProtectiveMagic
            // 
            this.tbProtectiveMagic.Location = new System.Drawing.Point(145, 259);
            this.tbProtectiveMagic.MaxLength = 3;
            this.tbProtectiveMagic.Name = "tbProtectiveMagic";
            this.tbProtectiveMagic.Size = new System.Drawing.Size(100, 23);
            this.tbProtectiveMagic.TabIndex = 11;
            this.tbProtectiveMagic.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbProtectiveMagic_KeyPress);
            // 
            // lblProtectiveMagic
            // 
            this.lblProtectiveMagic.AutoSize = true;
            this.lblProtectiveMagic.Location = new System.Drawing.Point(35, 259);
            this.lblProtectiveMagic.Name = "lblProtectiveMagic";
            this.lblProtectiveMagic.Size = new System.Drawing.Size(96, 15);
            this.lblProtectiveMagic.TabIndex = 10;
            this.lblProtectiveMagic.Text = "Protective Magic";
            // 
            // lblItelType
            // 
            this.lblItelType.AutoSize = true;
            this.lblItelType.Location = new System.Drawing.Point(35, 24);
            this.lblItelType.Name = "lblItelType";
            this.lblItelType.Size = new System.Drawing.Size(58, 15);
            this.lblItelType.TabIndex = 12;
            this.lblItelType.Text = "Item Type";
            // 
            // cbItemType
            // 
            this.cbItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItemType.FormattingEnabled = true;
            this.cbItemType.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.cbItemType.Location = new System.Drawing.Point(145, 24);
            this.cbItemType.Name = "cbItemType";
            this.cbItemType.Size = new System.Drawing.Size(121, 23);
            this.cbItemType.TabIndex = 13;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(131, 297);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(245, 297);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // CreateShopItemPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(380, 320);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cbItemType);
            this.Controls.Add(this.lblItelType);
            this.Controls.Add(this.tbProtectiveMagic);
            this.Controls.Add(this.lblProtectiveMagic);
            this.Controls.Add(this.tbCleaningMagic);
            this.Controls.Add(this.lblCleaningMagic);
            this.Controls.Add(this.tbWeight);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.tbCost);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MinimumSize = new System.Drawing.Size(400, 363);
            this.Name = "CreateShopItemPopup";
            this.Text = "Create New Item";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox tbCost;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.TextBox tbWeight;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.TextBox tbCleaningMagic;
        private System.Windows.Forms.Label lblCleaningMagic;
        private System.Windows.Forms.TextBox tbProtectiveMagic;
        private System.Windows.Forms.Label lblProtectiveMagic;
        private System.Windows.Forms.Label lblItelType;
        private System.Windows.Forms.ComboBox cbItemType;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
    }
}