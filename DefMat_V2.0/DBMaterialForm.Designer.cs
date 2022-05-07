
namespace DefMat_V2._0
{
    partial class DBMaterialForm<T>
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
            this.ExitScreenButton = new System.Windows.Forms.Button();
            this.SaveDbbutton2 = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ExitScreenButton
            // 
            this.ExitScreenButton.Location = new System.Drawing.Point(13, 181);
            this.ExitScreenButton.Name = "ExitScreenButton";
            this.ExitScreenButton.Size = new System.Drawing.Size(179, 37);
            this.ExitScreenButton.TabIndex = 5;
            this.ExitScreenButton.Text = "Выйти";
            this.ExitScreenButton.UseVisualStyleBackColor = true;
            this.ExitScreenButton.Click += new System.EventHandler(this.ExitScreenButton_Click);
            // 
            // SaveDbbutton2
            // 
            this.SaveDbbutton2.Location = new System.Drawing.Point(13, 9);
            this.SaveDbbutton2.Name = "SaveDbbutton2";
            this.SaveDbbutton2.Size = new System.Drawing.Size(179, 37);
            this.SaveDbbutton2.TabIndex = 7;
            this.SaveDbbutton2.Text = "Экспорт";
            this.SaveDbbutton2.UseVisualStyleBackColor = true;
            this.SaveDbbutton2.Click += new System.EventHandler(this.SaveDbbutton2_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(198, 9);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(611, 458);
            this.dataGridView.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 37);
            this.button1.TabIndex = 9;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 138);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(179, 37);
            this.button2.TabIndex = 10;
            this.button2.Text = "Удалить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(13, 95);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(179, 37);
            this.button3.TabIndex = 11;
            this.button3.Text = "Редактировать";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // DBMaterialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 483);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.SaveDbbutton2);
            this.Controls.Add(this.ExitScreenButton);
            this.Name = "DBMaterialForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Materials";
            this.Load += new System.EventHandler(this.DBMaterialForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ExitScreenButton;
        private System.Windows.Forms.Button SaveDbbutton2;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}