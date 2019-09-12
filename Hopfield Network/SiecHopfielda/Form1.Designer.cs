namespace SiecHopfielda
{
    partial class SiecHopfielda
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.addPatternButton = new System.Windows.Forms.Button();
            this.testButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.shuffleButton = new System.Windows.Forms.Button();
            this.showPatternButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.PatternBox = new System.Windows.Forms.ComboBox();
            this.patternCounterLabel = new System.Windows.Forms.Label();
            this.deletePatternButton = new System.Windows.Forms.Button();
            this.horizotalSeparatorLabel = new System.Windows.Forms.Label();
            this.selectedPatternLabel = new System.Windows.Forms.Label();
            this.verticalSeparatorLabel = new System.Windows.Forms.Label();
            this.trainModeLabel = new System.Windows.Forms.Label();
            this.testModeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 161);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(502, 504);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // addPatternButton
            // 
            this.addPatternButton.Location = new System.Drawing.Point(15, 17);
            this.addPatternButton.Margin = new System.Windows.Forms.Padding(2);
            this.addPatternButton.Name = "addPatternButton";
            this.addPatternButton.Size = new System.Drawing.Size(93, 54);
            this.addPatternButton.TabIndex = 1;
            this.addPatternButton.Text = "Add Pattern";
            this.addPatternButton.UseVisualStyleBackColor = true;
            this.addPatternButton.Click += new System.EventHandler(this.AddPatternButton_Click);
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(15, 102);
            this.testButton.Margin = new System.Windows.Forms.Padding(2);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(93, 49);
            this.testButton.TabIndex = 2;
            this.testButton.Text = "Start Test";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(424, 9);
            this.clearButton.Margin = new System.Windows.Forms.Padding(2);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(84, 142);
            this.clearButton.TabIndex = 3;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // shuffleButton
            // 
            this.shuffleButton.Location = new System.Drawing.Point(146, 92);
            this.shuffleButton.Margin = new System.Windows.Forms.Padding(2);
            this.shuffleButton.Name = "shuffleButton";
            this.shuffleButton.Size = new System.Drawing.Size(93, 59);
            this.shuffleButton.TabIndex = 4;
            this.shuffleButton.Text = "Shuffle";
            this.shuffleButton.UseVisualStyleBackColor = true;
            this.shuffleButton.Click += new System.EventHandler(this.ShuffleButton_Click);
            // 
            // showPatternButton
            // 
            this.showPatternButton.Location = new System.Drawing.Point(317, 8);
            this.showPatternButton.Margin = new System.Windows.Forms.Padding(2);
            this.showPatternButton.Name = "showPatternButton";
            this.showPatternButton.Size = new System.Drawing.Size(85, 31);
            this.showPatternButton.TabIndex = 5;
            this.showPatternButton.Text = "Show Pattern";
            this.showPatternButton.UseVisualStyleBackColor = true;
            this.showPatternButton.Click += new System.EventHandler(this.ShowPatternButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(260, 92);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(93, 59);
            this.stopButton.TabIndex = 6;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // PatternBox
            // 
            this.PatternBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PatternBox.FormattingEnabled = true;
            this.PatternBox.Location = new System.Drawing.Point(146, 50);
            this.PatternBox.Name = "PatternBox";
            this.PatternBox.Size = new System.Drawing.Size(135, 21);
            this.PatternBox.TabIndex = 7;
            // 
            // patternCounterLabel
            // 
            this.patternCounterLabel.AutoSize = true;
            this.patternCounterLabel.Location = new System.Drawing.Point(173, 8);
            this.patternCounterLabel.Name = "patternCounterLabel";
            this.patternCounterLabel.Size = new System.Drawing.Size(83, 13);
            this.patternCounterLabel.TabIndex = 8;
            this.patternCounterLabel.Text = "Pattern count: 0";
            // 
            // deletePatternButton
            // 
            this.deletePatternButton.Location = new System.Drawing.Point(317, 44);
            this.deletePatternButton.Name = "deletePatternButton";
            this.deletePatternButton.Size = new System.Drawing.Size(85, 31);
            this.deletePatternButton.TabIndex = 9;
            this.deletePatternButton.Text = "Delete Pattern";
            this.deletePatternButton.UseVisualStyleBackColor = true;
            this.deletePatternButton.Click += new System.EventHandler(this.DeletePatternButton_Click);
            // 
            // horizotalSeparatorLabel
            // 
            this.horizotalSeparatorLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.horizotalSeparatorLabel.Location = new System.Drawing.Point(12, 79);
            this.horizotalSeparatorLabel.Name = "horizotalSeparatorLabel";
            this.horizotalSeparatorLabel.Size = new System.Drawing.Size(400, 2);
            this.horizotalSeparatorLabel.TabIndex = 10;
            // 
            // selectedPatternLabel
            // 
            this.selectedPatternLabel.AutoSize = true;
            this.selectedPatternLabel.Location = new System.Drawing.Point(173, 34);
            this.selectedPatternLabel.Name = "selectedPatternLabel";
            this.selectedPatternLabel.Size = new System.Drawing.Size(89, 13);
            this.selectedPatternLabel.TabIndex = 11;
            this.selectedPatternLabel.Text = "Selected Pattern:";
            // 
            // verticalSeparatorLabel
            // 
            this.verticalSeparatorLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.verticalSeparatorLabel.Location = new System.Drawing.Point(417, 8);
            this.verticalSeparatorLabel.Name = "verticalSeparatorLabel";
            this.verticalSeparatorLabel.Size = new System.Drawing.Size(2, 150);
            this.verticalSeparatorLabel.TabIndex = 14;
            // 
            // trainModeLabel
            // 
            this.trainModeLabel.AutoSize = true;
            this.trainModeLabel.Location = new System.Drawing.Point(12, 5);
            this.trainModeLabel.Name = "trainModeLabel";
            this.trainModeLabel.Size = new System.Drawing.Size(61, 13);
            this.trainModeLabel.TabIndex = 15;
            this.trainModeLabel.Text = "Train Mode";
            // 
            // testModeLabel
            // 
            this.testModeLabel.AutoSize = true;
            this.testModeLabel.Location = new System.Drawing.Point(15, 86);
            this.testModeLabel.Name = "testModeLabel";
            this.testModeLabel.Size = new System.Drawing.Size(58, 13);
            this.testModeLabel.TabIndex = 16;
            this.testModeLabel.Text = "Test Mode";
            // 
            // SiecHopfielda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 671);
            this.Controls.Add(this.testModeLabel);
            this.Controls.Add(this.trainModeLabel);
            this.Controls.Add(this.verticalSeparatorLabel);
            this.Controls.Add(this.selectedPatternLabel);
            this.Controls.Add(this.horizotalSeparatorLabel);
            this.Controls.Add(this.deletePatternButton);
            this.Controls.Add(this.patternCounterLabel);
            this.Controls.Add(this.PatternBox);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.showPatternButton);
            this.Controls.Add(this.shuffleButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.addPatternButton);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SiecHopfielda";
            this.Text = "Siec Hopfielda";
            this.Load += new System.EventHandler(this.SiecHopfielda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button addPatternButton;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button shuffleButton;
        private System.Windows.Forms.Button showPatternButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.ComboBox PatternBox;
        private System.Windows.Forms.Label patternCounterLabel;
        private System.Windows.Forms.Button deletePatternButton;
        private System.Windows.Forms.Label horizotalSeparatorLabel;
        private System.Windows.Forms.Label selectedPatternLabel;
        private System.Windows.Forms.Label verticalSeparatorLabel;
        private System.Windows.Forms.Label trainModeLabel;
        private System.Windows.Forms.Label testModeLabel;
    }
}

