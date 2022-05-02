
namespace DefMat_V2._0
{
    partial class DataBaseForm
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
            this.SuspendLayout();
            // 
            // ExitScreenButton
            // 
            this.ExitScreenButton.Location = new System.Drawing.Point(590, 493);
            this.ExitScreenButton.Name = "ExitScreenButton";
            this.ExitScreenButton.Size = new System.Drawing.Size(218, 34);
            this.ExitScreenButton.TabIndex = 5;
            this.ExitScreenButton.Text = "Выйти";
            this.ExitScreenButton.UseVisualStyleBackColor = true;
            this.ExitScreenButton.Click += new System.EventHandler(this.ExitScreenButton_Click);
            // 
            // DataBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 539);
            this.Controls.Add(this.ExitScreenButton);
            this.Name = "DataBaseForm";
            this.Text = "DataBaseForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ExitScreenButton;
    }
}