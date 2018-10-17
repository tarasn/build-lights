namespace BuildLights.WinAppTester
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
            this.buttonSend = new System.Windows.Forms.Button();
            this.checkedListBoxColors = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(102, 324);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(87, 33);
            this.buttonSend.TabIndex = 0;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // checkedListBoxColors
            // 
            this.checkedListBoxColors.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkedListBoxColors.FormattingEnabled = true;
            this.checkedListBoxColors.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Yellow"});
            this.checkedListBoxColors.Location = new System.Drawing.Point(0, 0);
            this.checkedListBoxColors.Name = "checkedListBoxColors";
            this.checkedListBoxColors.Size = new System.Drawing.Size(284, 214);
            this.checkedListBoxColors.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 381);
            this.Controls.Add(this.checkedListBoxColors);
            this.Controls.Add(this.buttonSend);
            this.Name = "Form1";
            this.Text = "Build Lights Arduino Tester";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.CheckedListBox checkedListBoxColors;
    }
}

