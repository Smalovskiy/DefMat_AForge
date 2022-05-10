
namespace DefMat_V2._0
{
    partial class DBExtensionsForm<T>
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
            this.dGVExtension = new System.Windows.Forms.DataGridView();
            this.ExitScreenButton2 = new System.Windows.Forms.Button();
            this.SaveDbbutton3 = new System.Windows.Forms.Button();
            this.DelExtensionsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGVExtension)).BeginInit();
            this.SuspendLayout();
            // 
            // dGVExtension
            // 
            this.dGVExtension.AllowUserToAddRows = false;
            this.dGVExtension.AllowUserToDeleteRows = false;
            this.dGVExtension.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dGVExtension.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVExtension.Location = new System.Drawing.Point(197, 12);
            this.dGVExtension.Name = "dGVExtension";
            this.dGVExtension.Size = new System.Drawing.Size(611, 458);
            this.dGVExtension.TabIndex = 7;
            // 
            // ExitScreenButton2
            // 
            this.ExitScreenButton2.Location = new System.Drawing.Point(12, 95);
            this.ExitScreenButton2.Name = "ExitScreenButton2";
            this.ExitScreenButton2.Size = new System.Drawing.Size(177, 37);
            this.ExitScreenButton2.TabIndex = 8;
            this.ExitScreenButton2.Text = "Выйти";
            this.ExitScreenButton2.UseVisualStyleBackColor = true;
            this.ExitScreenButton2.Click += new System.EventHandler(this.ExitScreenButton2_Click);
            // 
            // SaveDbbutton3
            // 
            this.SaveDbbutton3.Location = new System.Drawing.Point(12, 12);
            this.SaveDbbutton3.Name = "SaveDbbutton3";
            this.SaveDbbutton3.Size = new System.Drawing.Size(177, 34);
            this.SaveDbbutton3.TabIndex = 10;
            this.SaveDbbutton3.Text = "Экспорт";
            this.SaveDbbutton3.UseVisualStyleBackColor = true;
            this.SaveDbbutton3.Click += new System.EventHandler(this.SaveDbbutton3_Click);
            // 
            // DelExtensionsButton
            // 
            this.DelExtensionsButton.Location = new System.Drawing.Point(12, 52);
            this.DelExtensionsButton.Name = "DelExtensionsButton";
            this.DelExtensionsButton.Size = new System.Drawing.Size(177, 37);
            this.DelExtensionsButton.TabIndex = 12;
            this.DelExtensionsButton.Text = "Удалить";
            this.DelExtensionsButton.UseVisualStyleBackColor = true;
            this.DelExtensionsButton.Click += new System.EventHandler(this.DelExtensionsButton_Click);
            // 
            // DBExtensionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 483);
            this.Controls.Add(this.DelExtensionsButton);
            this.Controls.Add(this.SaveDbbutton3);
            this.Controls.Add(this.ExitScreenButton2);
            this.Controls.Add(this.dGVExtension);
            this.Name = "DBExtensionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Extensions";
            this.Load += new System.EventHandler(this.DBExtensionsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGVExtension)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dGVExtension;
        private System.Windows.Forms.Button ExitScreenButton2;
        private System.Windows.Forms.Button SaveDbbutton3;
        private System.Windows.Forms.Button DelExtensionsButton;
    }
}