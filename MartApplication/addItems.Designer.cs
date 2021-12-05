
namespace MartApplication
{
    partial class addItems
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addItems));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.itmnametxt = new System.Windows.Forms.TextBox();
            this.itmprice = new System.Windows.Forms.TextBox();
            this.distxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.Label();
            this.itemdistxt = new System.Windows.Forms.Label();
            this.itembtntxt = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(3, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(871, 100);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(370, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "SYR MART";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.itembtntxt);
            this.panel2.Controls.Add(this.itemdistxt);
            this.panel2.Controls.Add(this.price);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.distxt);
            this.panel2.Controls.Add(this.itmprice);
            this.panel2.Controls.Add(this.itmnametxt);
            this.panel2.Location = new System.Drawing.Point(162, 165);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(573, 378);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // itmnametxt
            // 
            this.itmnametxt.Location = new System.Drawing.Point(226, 60);
            this.itmnametxt.Name = "itmnametxt";
            this.itmnametxt.Size = new System.Drawing.Size(219, 26);
            this.itmnametxt.TabIndex = 0;
            // 
            // itmprice
            // 
            this.itmprice.Location = new System.Drawing.Point(226, 144);
            this.itmprice.Name = "itmprice";
            this.itmprice.Size = new System.Drawing.Size(219, 26);
            this.itmprice.TabIndex = 1;
            // 
            // distxt
            // 
            this.distxt.Location = new System.Drawing.Point(226, 231);
            this.distxt.Name = "distxt";
            this.distxt.Size = new System.Drawing.Size(219, 26);
            this.distxt.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(86, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Item Name";
            // 
            // price
            // 
            this.price.AutoSize = true;
            this.price.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.price.Location = new System.Drawing.Point(86, 145);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(61, 25);
            this.price.TabIndex = 4;
            this.price.Text = "Price";
            // 
            // itemdistxt
            // 
            this.itemdistxt.AutoSize = true;
            this.itemdistxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemdistxt.Location = new System.Drawing.Point(86, 232);
            this.itemdistxt.Name = "itemdistxt";
            this.itemdistxt.Size = new System.Drawing.Size(96, 25);
            this.itemdistxt.TabIndex = 5;
            this.itemdistxt.Text = "Discount";
            // 
            // itembtntxt
            // 
            this.itembtntxt.Location = new System.Drawing.Point(263, 285);
            this.itembtntxt.Name = "itembtntxt";
            this.itembtntxt.Size = new System.Drawing.Size(129, 52);
            this.itembtntxt.TabIndex = 6;
            this.itembtntxt.Text = "ADD ITEMS";
            this.itembtntxt.UseVisualStyleBackColor = true;
            this.itembtntxt.Click += new System.EventHandler(this.itembtntxt_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(224, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(131, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // addItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 642);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "addItems";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "addItems";
            this.Load += new System.EventHandler(this.addItems_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label itemdistxt;
        private System.Windows.Forms.Label price;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox distxt;
        private System.Windows.Forms.TextBox itmprice;
        private System.Windows.Forms.TextBox itmnametxt;
        private System.Windows.Forms.Button itembtntxt;
    }
}