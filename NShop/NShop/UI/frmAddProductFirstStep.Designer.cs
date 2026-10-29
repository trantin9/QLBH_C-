namespace NShop.UI
{
    partial class frmAddProductFirstStep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddProductFirstStep));
            label1 = new Label();
            btnConsoleProduct = new Button();
            btnPC = new Button();
            btnPhysicalCopy = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(64, 64, 64);
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(-1, -1);
            label1.Name = "label1";
            label1.Padding = new Padding(50, 10, 620, 10);
            label1.Size = new Size(988, 51);
            label1.TabIndex = 0;
            label1.Text = "Choose the product category";
            // 
            // btnConsoleProduct
            // 
            btnConsoleProduct.BackgroundImage = (Image)resources.GetObject("btnConsoleProduct.BackgroundImage");
            btnConsoleProduct.BackgroundImageLayout = ImageLayout.Zoom;
            btnConsoleProduct.Location = new Point(85, 184);
            btnConsoleProduct.Name = "btnConsoleProduct";
            btnConsoleProduct.Size = new Size(180, 180);
            btnConsoleProduct.TabIndex = 1;
            btnConsoleProduct.UseVisualStyleBackColor = true;
            // 
            // btnPC
            // 
            btnPC.BackgroundImage = (Image)resources.GetObject("btnPC.BackgroundImage");
            btnPC.BackgroundImageLayout = ImageLayout.Stretch;
            btnPC.Location = new Point(510, 184);
            btnPC.Name = "btnPC";
            btnPC.Size = new Size(180, 180);
            btnPC.TabIndex = 2;
            btnPC.UseVisualStyleBackColor = true;
            // 
            // btnPhysicalCopy
            // 
            btnPhysicalCopy.BackColor = SystemColors.Control;
            btnPhysicalCopy.BackgroundImage = (Image)resources.GetObject("btnPhysicalCopy.BackgroundImage");
            btnPhysicalCopy.BackgroundImageLayout = ImageLayout.Stretch;
            btnPhysicalCopy.Location = new Point(296, 184);
            btnPhysicalCopy.Name = "btnPhysicalCopy";
            btnPhysicalCopy.Size = new Size(180, 180);
            btnPhysicalCopy.TabIndex = 3;
            btnPhysicalCopy.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(219, 119);
            label2.Name = "label2";
            label2.Size = new Size(341, 23);
            label2.TabIndex = 4;
            label2.Text = "What type of product do you want to add?";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(104, 367);
            label3.Name = "label3";
            label3.Size = new Size(136, 23);
            label3.TabIndex = 5;
            label3.Text = "Console product";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label4.Location = new Point(329, 367);
            label4.Name = "label4";
            label4.Size = new Size(113, 23);
            label4.TabIndex = 6;
            label4.Text = "Physical copy";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label5.Location = new Point(546, 367);
            label5.Name = "label5";
            label5.Size = new Size(108, 23);
            label5.TabIndex = 7;
            label5.Text = "PC hardware";
            // 
            // frmAddProductFirstStep
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 553);
            ControlBox = false;
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnPhysicalCopy);
            Controls.Add(btnPC);
            Controls.Add(btnConsoleProduct);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmAddProductFirstStep";
            StartPosition = FormStartPosition.CenterParent;
            Text = "AddProductFirstStep";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnConsoleProduct;
        private Button btnPC;
        private Button btnPhysicalCopy;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}