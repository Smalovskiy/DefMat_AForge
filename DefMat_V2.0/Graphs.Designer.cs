
namespace DefMat_V2._0
{
    partial class Graphs
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
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ExitScreenButton
            // 
            this.ExitScreenButton.Location = new System.Drawing.Point(703, 593);
            this.ExitScreenButton.Name = "ExitScreenButton";
            this.ExitScreenButton.Size = new System.Drawing.Size(218, 34);
            this.ExitScreenButton.TabIndex = 4;
            this.ExitScreenButton.Text = "Выйти";
            this.ExitScreenButton.UseVisualStyleBackColor = true;
            this.ExitScreenButton.Click += new System.EventHandler(this.ExitScreenButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 593);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(218, 34);
            this.button1.TabIndex = 5;
            this.button1.Text = "База данных";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Graphs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 639);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ExitScreenButton);
            this.Name = "Graphs";
            this.Text = "Graphs";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ExitScreenButton;
        private System.Windows.Forms.Button button1;
    }
}