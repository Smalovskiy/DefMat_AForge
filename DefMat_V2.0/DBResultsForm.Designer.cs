
namespace DefMat_V2._0
{
    partial class DBResultsForm<T>
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
            this.dGVResults = new System.Windows.Forms.DataGridView();
            this.ExitResultsButton = new System.Windows.Forms.Button();
            this.SaveDbbutton1 = new System.Windows.Forms.Button();
            this.DeleteResultsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGVResults)).BeginInit();
            this.SuspendLayout();
            // 
            // dGVResults
            // 
            this.dGVResults.AllowUserToAddRows = false;
            this.dGVResults.AllowUserToDeleteRows = false;
            this.dGVResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVResults.Location = new System.Drawing.Point(198, 12);
            this.dGVResults.Name = "dGVResults";
            this.dGVResults.Size = new System.Drawing.Size(611, 458);
            this.dGVResults.TabIndex = 7;
            // 
            // ExitResultsButton
            // 
            this.ExitResultsButton.Location = new System.Drawing.Point(12, 98);
            this.ExitResultsButton.Name = "ExitResultsButton";
            this.ExitResultsButton.Size = new System.Drawing.Size(179, 37);
            this.ExitResultsButton.TabIndex = 8;
            this.ExitResultsButton.Text = "Выйти";
            this.ExitResultsButton.UseVisualStyleBackColor = true;
            this.ExitResultsButton.Click += new System.EventHandler(this.ExitScreenButton1_Click);
            // 
            // SaveDbbutton1
            // 
            this.SaveDbbutton1.Location = new System.Drawing.Point(12, 12);
            this.SaveDbbutton1.Name = "SaveDbbutton1";
            this.SaveDbbutton1.Size = new System.Drawing.Size(179, 37);
            this.SaveDbbutton1.TabIndex = 9;
            this.SaveDbbutton1.Text = "Экспорт";
            this.SaveDbbutton1.UseVisualStyleBackColor = true;
            this.SaveDbbutton1.Click += new System.EventHandler(this.SaveDbbutton1_Click);
            // 
            // DeleteResultsButton
            // 
            this.DeleteResultsButton.Location = new System.Drawing.Point(12, 55);
            this.DeleteResultsButton.Name = "DeleteResultsButton";
            this.DeleteResultsButton.Size = new System.Drawing.Size(179, 37);
            this.DeleteResultsButton.TabIndex = 11;
            this.DeleteResultsButton.Text = "Удалить";
            this.DeleteResultsButton.UseVisualStyleBackColor = true;
            this.DeleteResultsButton.Click += new System.EventHandler(this.DeleteResultsButton_Click);
            // 
            // DBResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 483);
            this.Controls.Add(this.DeleteResultsButton);
            this.Controls.Add(this.SaveDbbutton1);
            this.Controls.Add(this.ExitResultsButton);
            this.Controls.Add(this.dGVResults);
            this.Name = "DBResultsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Results";
            this.Load += new System.EventHandler(this.DBResultsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGVResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dGVResults;
        private System.Windows.Forms.Button ExitResultsButton;
        private System.Windows.Forms.Button SaveDbbutton1;
        private System.Windows.Forms.Button DeleteResultsButton;
    }
}