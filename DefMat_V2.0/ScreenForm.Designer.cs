
namespace DefMat_V2._0
{
    partial class ScreenForm
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
            this.ScreenPB = new System.Windows.Forms.PictureBox();
            this.SaveScreenButton = new System.Windows.Forms.Button();
            this.EditScreenButton = new System.Windows.Forms.Button();
            this.ExitScreenButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ScreenPB)).BeginInit();
            this.SuspendLayout();
            // 
            // ScreenPB
            // 
            this.ScreenPB.Location = new System.Drawing.Point(13, 13);
            this.ScreenPB.Name = "ScreenPB";
            this.ScreenPB.Size = new System.Drawing.Size(737, 432);
            this.ScreenPB.TabIndex = 0;
            this.ScreenPB.TabStop = false;
            // 
            // SaveScreenButton
            // 
            this.SaveScreenButton.Location = new System.Drawing.Point(12, 462);
            this.SaveScreenButton.Name = "SaveScreenButton";
            this.SaveScreenButton.Size = new System.Drawing.Size(218, 34);
            this.SaveScreenButton.TabIndex = 1;
            this.SaveScreenButton.Text = "Save";
            this.SaveScreenButton.UseVisualStyleBackColor = true;
            this.SaveScreenButton.Click += new System.EventHandler(this.SaveScreenButton_Click);
            // 
            // EditScreenButton
            // 
            this.EditScreenButton.Location = new System.Drawing.Point(272, 462);
            this.EditScreenButton.Name = "EditScreenButton";
            this.EditScreenButton.Size = new System.Drawing.Size(218, 34);
            this.EditScreenButton.TabIndex = 2;
            this.EditScreenButton.Text = "Edit (beta)";
            this.EditScreenButton.UseVisualStyleBackColor = true;
            // 
            // ExitScreenButton
            // 
            this.ExitScreenButton.Location = new System.Drawing.Point(532, 462);
            this.ExitScreenButton.Name = "ExitScreenButton";
            this.ExitScreenButton.Size = new System.Drawing.Size(218, 34);
            this.ExitScreenButton.TabIndex = 3;
            this.ExitScreenButton.Text = "Back";
            this.ExitScreenButton.UseVisualStyleBackColor = true;
            this.ExitScreenButton.Click += new System.EventHandler(this.ExitScreenButton_Click);
            // 
            // ScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 519);
            this.Controls.Add(this.ExitScreenButton);
            this.Controls.Add(this.EditScreenButton);
            this.Controls.Add(this.SaveScreenButton);
            this.Controls.Add(this.ScreenPB);
            this.Name = "ScreenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Screen";
            this.Load += new System.EventHandler(this.Screen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ScreenPB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ScreenPB;
        private System.Windows.Forms.Button SaveScreenButton;
        private System.Windows.Forms.Button EditScreenButton;
        private System.Windows.Forms.Button ExitScreenButton;
    }
}