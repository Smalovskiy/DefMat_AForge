
namespace DefMat_V2._0
{
    partial class GraphsForm
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
            this.ExitGraphsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ExitGraphsButton
            // 
            this.ExitGraphsButton.Location = new System.Drawing.Point(703, 593);
            this.ExitGraphsButton.Name = "ExitGraphsButton";
            this.ExitGraphsButton.Size = new System.Drawing.Size(218, 34);
            this.ExitGraphsButton.TabIndex = 4;
            this.ExitGraphsButton.Text = "Back";
            this.ExitGraphsButton.UseVisualStyleBackColor = true;
            this.ExitGraphsButton.Click += new System.EventHandler(this.ExitGraphsButton_Click);
            // 
            // GraphsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 639);
            this.Controls.Add(this.ExitGraphsButton);
            this.Name = "GraphsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Graphs";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ExitGraphsButton;
    }
}