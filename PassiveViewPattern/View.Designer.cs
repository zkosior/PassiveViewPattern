namespace PassiveViewPattern
{
    partial class View
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
            this.labelWarning = new System.Windows.Forms.Label();
            this.radioButtonOptionOne = new System.Windows.Forms.RadioButton();
            this.panelOptions = new System.Windows.Forms.Panel();
            this.radioButtonOptionTwo = new System.Windows.Forms.RadioButton();
            this.panelOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelWarning
            // 
            this.labelWarning.AutoSize = true;
            this.labelWarning.Location = new System.Drawing.Point(33, 27);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(69, 13);
            this.labelWarning.TabIndex = 0;
            this.labelWarning.Text = "labelWarning";
            // 
            // radioButtonOptionOne
            // 
            this.radioButtonOptionOne.AutoSize = true;
            this.radioButtonOptionOne.Location = new System.Drawing.Point(13, 12);
            this.radioButtonOptionOne.Name = "radioButtonOptionOne";
            this.radioButtonOptionOne.Size = new System.Drawing.Size(130, 17);
            this.radioButtonOptionOne.TabIndex = 1;
            this.radioButtonOptionOne.TabStop = true;
            this.radioButtonOptionOne.Text = "radioButtonOptionOne";
            this.radioButtonOptionOne.UseVisualStyleBackColor = true;
            // 
            // panelOptions
            // 
            this.panelOptions.Controls.Add(this.radioButtonOptionTwo);
            this.panelOptions.Controls.Add(this.radioButtonOptionOne);
            this.panelOptions.Location = new System.Drawing.Point(36, 113);
            this.panelOptions.Name = "panelOptions";
            this.panelOptions.Size = new System.Drawing.Size(200, 100);
            this.panelOptions.TabIndex = 2;
            // 
            // radioButtonOptionTwo
            // 
            this.radioButtonOptionTwo.AutoSize = true;
            this.radioButtonOptionTwo.Location = new System.Drawing.Point(13, 48);
            this.radioButtonOptionTwo.Name = "radioButtonOptionTwo";
            this.radioButtonOptionTwo.Size = new System.Drawing.Size(131, 17);
            this.radioButtonOptionTwo.TabIndex = 2;
            this.radioButtonOptionTwo.TabStop = true;
            this.radioButtonOptionTwo.Text = "radioButtonOptionTwo";
            this.radioButtonOptionTwo.UseVisualStyleBackColor = true;
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.panelOptions);
            this.Controls.Add(this.labelWarning);
            this.Name = "View";
            this.Text = "Form1";
            this.panelOptions.ResumeLayout(false);
            this.panelOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelWarning;
        private System.Windows.Forms.RadioButton radioButtonOptionOne;
        private System.Windows.Forms.Panel panelOptions;
        private System.Windows.Forms.RadioButton radioButtonOptionTwo;
    }
}

