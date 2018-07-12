namespace DMCLDemo
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
            this.SearchDocbase = new System.Windows.Forms.Button();
            this.GetItemsButton = new System.Windows.Forms.Button();
            this.SelectedItemButton = new System.Windows.Forms.Button();
            this.FindItemButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.DataBindingButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SearchDocbase
            // 
            this.SearchDocbase.Location = new System.Drawing.Point(322, 102);
            this.SearchDocbase.Name = "SearchDocbase";
            this.SearchDocbase.Size = new System.Drawing.Size(131, 36);
            this.SearchDocbase.TabIndex = 1;
            this.SearchDocbase.Text = "Search Docbase";
            this.SearchDocbase.UseVisualStyleBackColor = true;
            this.SearchDocbase.Click += new System.EventHandler(this.SearchDocbase_Click);
            // 
            // GetItemsButton
            // 
            this.GetItemsButton.Location = new System.Drawing.Point(322, 144);
            this.GetItemsButton.Name = "GetItemsButton";
            this.GetItemsButton.Size = new System.Drawing.Size(131, 38);
            this.GetItemsButton.TabIndex = 2;
            this.GetItemsButton.Text = "Get Items";
            this.GetItemsButton.UseVisualStyleBackColor = true;
            this.GetItemsButton.Click += new System.EventHandler(this.GetItemsButton_Click);
            // 
            // SelectedItemButton
            // 
            this.SelectedItemButton.Location = new System.Drawing.Point(322, 188);
            this.SelectedItemButton.Name = "SelectedItemButton";
            this.SelectedItemButton.Size = new System.Drawing.Size(131, 38);
            this.SelectedItemButton.TabIndex = 3;
            this.SelectedItemButton.Text = "Selected Item";
            this.SelectedItemButton.UseVisualStyleBackColor = true;
            this.SelectedItemButton.Click += new System.EventHandler(this.SelectedItemButton_Click);
            // 
            // FindItemButton
            // 
            this.FindItemButton.Location = new System.Drawing.Point(324, 359);
            this.FindItemButton.Name = "FindItemButton";
            this.FindItemButton.Size = new System.Drawing.Size(131, 38);
            this.FindItemButton.TabIndex = 4;
            this.FindItemButton.Text = "Find Item";
            this.FindItemButton.UseVisualStyleBackColor = true;
            this.FindItemButton.Click += new System.EventHandler(this.FindItemButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(48, 308);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(267, 20);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // DataBindingButton
            // 
            this.DataBindingButton.Location = new System.Drawing.Point(321, 232);
            this.DataBindingButton.Name = "DataBindingButton";
            this.DataBindingButton.Size = new System.Drawing.Size(131, 38);
            this.DataBindingButton.TabIndex = 6;
            this.DataBindingButton.Text = "Data Binding";
            this.DataBindingButton.UseVisualStyleBackColor = true;
            this.DataBindingButton.Click += new System.EventHandler(this.DataBindingButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(325, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 41);
            this.button1.TabIndex = 7;
            this.button1.Text = "Documentum login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 24);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(303, 264);
            this.listBox1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 311);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "DQL";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 430);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DataBindingButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.FindItemButton);
            this.Controls.Add(this.SelectedItemButton);
            this.Controls.Add(this.GetItemsButton);
            this.Controls.Add(this.SearchDocbase);
            this.Name = "Form1";
            this.Text = "Documentum List and Display";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SearchDocbase;
        private System.Windows.Forms.Button GetItemsButton;
        private System.Windows.Forms.Button SelectedItemButton;
        private System.Windows.Forms.Button FindItemButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button DataBindingButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
    }
}

