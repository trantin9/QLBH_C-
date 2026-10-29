namespace NShop
{
    partial class frmChooseProductType
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAddNewProduct = new Button();
            btnViewProductList = new Button();
            panel1 = new Panel();
            btnSearchProduct = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnAddNewProduct
            // 
            btnAddNewProduct.BackColor = Color.DodgerBlue;
            btnAddNewProduct.FlatAppearance.BorderColor = Color.Black;
            btnAddNewProduct.FlatStyle = FlatStyle.Flat;
            btnAddNewProduct.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddNewProduct.ForeColor = SystemColors.ControlLightLight;
            btnAddNewProduct.Location = new Point(0, 2);
            btnAddNewProduct.Margin = new Padding(0, 2, 0, 0);
            btnAddNewProduct.Name = "btnAddNewProduct";
            btnAddNewProduct.Size = new Size(210, 65);
            btnAddNewProduct.TabIndex = 0;
            btnAddNewProduct.Text = "Add new product";
            btnAddNewProduct.UseVisualStyleBackColor = false;
            btnAddNewProduct.Click += btnAddNewProduct_Click;
            // 
            // btnViewProductList
            // 
            btnViewProductList.BackColor = SystemColors.ActiveBorder;
            btnViewProductList.FlatStyle = FlatStyle.Flat;
            btnViewProductList.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnViewProductList.Location = new Point(0, 69);
            btnViewProductList.Margin = new Padding(0, 2, 0, 0);
            btnViewProductList.Name = "btnViewProductList";
            btnViewProductList.Size = new Size(210, 65);
            btnViewProductList.TabIndex = 3;
            btnViewProductList.Text = "View product list";
            btnViewProductList.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Location = new Point(217, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(862, 636);
            panel1.TabIndex = 2;
            // 
            // btnSearchProduct
            // 
            btnSearchProduct.BackColor = SystemColors.ActiveBorder;
            btnSearchProduct.FlatStyle = FlatStyle.Flat;
            btnSearchProduct.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearchProduct.Location = new Point(0, 136);
            btnSearchProduct.Margin = new Padding(0, 2, 0, 0);
            btnSearchProduct.Name = "btnSearchProduct";
            btnSearchProduct.Size = new Size(210, 65);
            btnSearchProduct.TabIndex = 4;
            btnSearchProduct.Text = "Search for products";
            btnSearchProduct.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnAddNewProduct);
            flowLayoutPanel1.Controls.Add(btnViewProductList);
            flowLayoutPanel1.Controls.Add(btnSearchProduct);
            flowLayoutPanel1.Location = new Point(4, 5);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(213, 636);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // frmChooseProductType
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1082, 653);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            IsMdiContainer = true;
            Name = "frmChooseProductType";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Shop Control Panel";
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Button btnAddNewProduct;
        private Button btnViewProductList;
        private Button btnSearchProduct;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
