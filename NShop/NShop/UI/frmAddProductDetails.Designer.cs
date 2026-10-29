namespace NShop.UI
{
    partial class frmAddProductDetails
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
            label1 = new Label();
            txtProductId = new TextBox();
            txtProductPrice = new TextBox();
            txtDesc = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            rdoStockNo = new RadioButton();
            rdoStockYes = new RadioButton();
            btnConfirmAdd = new Button();
            btnCancel = new Button();
            button3 = new Button();
            btnPreviousStep = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(64, 64, 64);
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(50, 10, 650, 10);
            label1.Size = new Size(920, 51);
            label1.TabIndex = 0;
            label1.Text = "Add product details";
            // 
            // txtProductId
            // 
            txtProductId.Location = new Point(198, 164);
            txtProductId.Name = "txtProductId";
            txtProductId.Size = new Size(366, 27);
            txtProductId.TabIndex = 1;
            txtProductId.Text = "(Product's ID, ex: P3215..)";
            txtProductId.TextChanged += textBox1_TextChanged;
            // 
            // txtProductPrice
            // 
            txtProductPrice.Location = new Point(198, 243);
            txtProductPrice.Name = "txtProductPrice";
            txtProductPrice.Size = new Size(366, 27);
            txtProductPrice.TabIndex = 2;
            txtProductPrice.Text = "(Regular Price)";
            // 
            // txtDesc
            // 
            txtDesc.Location = new Point(198, 324);
            txtDesc.Name = "txtDesc";
            txtDesc.Size = new Size(366, 27);
            txtDesc.TabIndex = 3;
            txtDesc.Text = "(Enter short description)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(198, 141);
            label2.Name = "label2";
            label2.Size = new Size(103, 20);
            label2.TabIndex = 4;
            label2.Text = "Product ID (*)";
            label2.Click += this.label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(198, 220);
            label3.Name = "label3";
            label3.Size = new Size(64, 20);
            label3.TabIndex = 5;
            label3.Text = "Price (*)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(198, 301);
            label4.Name = "label4";
            label4.Size = new Size(82, 20);
            label4.TabIndex = 6;
            label4.Text = "Short Desc";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(198, 87);
            label5.Name = "label5";
            label5.Size = new Size(250, 23);
            label5.TabIndex = 7;
            label5.Text = "Please fill out necessary details:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(198, 388);
            label6.Name = "label6";
            label6.Size = new Size(68, 20);
            label6.TabIndex = 8;
            label6.Text = "In stock?";
            // 
            // rdoStockNo
            // 
            rdoStockNo.AutoSize = true;
            rdoStockNo.Location = new Point(301, 388);
            rdoStockNo.Name = "rdoStockNo";
            rdoStockNo.Size = new Size(50, 24);
            rdoStockNo.TabIndex = 9;
            rdoStockNo.TabStop = true;
            rdoStockNo.Text = "No";
            rdoStockNo.UseVisualStyleBackColor = true;
            // 
            // rdoStockYes
            // 
            rdoStockYes.AutoSize = true;
            rdoStockYes.Location = new Point(387, 388);
            rdoStockYes.Name = "rdoStockYes";
            rdoStockYes.Size = new Size(51, 24);
            rdoStockYes.TabIndex = 10;
            rdoStockYes.TabStop = true;
            rdoStockYes.Text = "Yes";
            rdoStockYes.UseVisualStyleBackColor = true;
            // 
            // btnConfirmAdd
            // 
            btnConfirmAdd.BackColor = Color.DodgerBlue;
            btnConfirmAdd.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirmAdd.ForeColor = SystemColors.ControlLightLight;
            btnConfirmAdd.Location = new Point(602, 449);
            btnConfirmAdd.Name = "btnConfirmAdd";
            btnConfirmAdd.Size = new Size(150, 45);
            btnConfirmAdd.TabIndex = 11;
            btnConfirmAdd.Text = "Confirm add";
            btnConfirmAdd.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(446, 449);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 45);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(22, 436);
            button3.Name = "button3";
            button3.Size = new Size(0, 0);
            button3.TabIndex = 13;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            // 
            // btnPreviousStep
            // 
            btnPreviousStep.Location = new Point(290, 450);
            btnPreviousStep.Name = "btnPreviousStep";
            btnPreviousStep.Size = new Size(150, 45);
            btnPreviousStep.TabIndex = 14;
            btnPreviousStep.Text = "Previous step";
            btnPreviousStep.UseVisualStyleBackColor = true;
            // 
            // frmAddProductDetails
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(764, 506);
            ControlBox = false;
            Controls.Add(btnPreviousStep);
            Controls.Add(button3);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirmAdd);
            Controls.Add(rdoStockYes);
            Controls.Add(rdoStockNo);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtDesc);
            Controls.Add(txtProductPrice);
            Controls.Add(txtProductId);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmAddProductDetails";
            Text = "Add product details";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtProductId;
        private TextBox txtProductPrice;
        private TextBox txtDesc;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private RadioButton rdoStockNo;
        private RadioButton rdoStockYes;
        private Button btnConfirmAdd;
        private Button btnCancel;
        private Button button3;
        private Button btnPreviousStep;
    }
}