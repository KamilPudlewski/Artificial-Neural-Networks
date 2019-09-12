namespace ImageStyleChanger
{
    partial class Menu
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
            this.startButton = new System.Windows.Forms.Button();
            this.styleListView = new System.Windows.Forms.ListView();
            this.addStyleButton = new System.Windows.Forms.Button();
            this.openStyleFolderButton = new System.Windows.Forms.Button();
            this.deleteStyleButton = new System.Windows.Forms.Button();
            this.loadImageButton = new System.Windows.Forms.Button();
            this.loadedImagePictureBox = new System.Windows.Forms.PictureBox();
            this.reworkedImagePictureBox = new System.Windows.Forms.PictureBox();
            this.separatorLabel = new System.Windows.Forms.Label();
            this.separatorLabel2 = new System.Windows.Forms.Label();
            this.originalImageLabel = new System.Windows.Forms.Label();
            this.reworkedImageLabel = new System.Windows.Forms.Label();
            this.horizontalSeparatorLabel = new System.Windows.Forms.Label();
            this.styleWeightTextBox = new System.Windows.Forms.TextBox();
            this.styleWeightLabel = new System.Windows.Forms.Label();
            this.horizontalSeparatorLabel2 = new System.Windows.Forms.Label();
            this.iterationsCountLabel = new System.Windows.Forms.Label();
            this.iterationsCountTextBox = new System.Windows.Forms.TextBox();
            this.imageStyleLabel = new System.Windows.Forms.Label();
            this.styleLabel = new System.Windows.Forms.Label();
            this.programStatusLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.horizontalSeparatorLabel3 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.openReworkedImageFolderButton = new System.Windows.Forms.Button();
            this.saveReworkedImageButton = new System.Windows.Forms.Button();
            this.optionsLabel = new System.Windows.Forms.Label();
            this.progressLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.loadedImagePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reworkedImagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 378);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(150, 60);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // styleListView
            // 
            this.styleListView.HideSelection = false;
            this.styleListView.Location = new System.Drawing.Point(190, 12);
            this.styleListView.Name = "styleListView";
            this.styleListView.Size = new System.Drawing.Size(462, 350);
            this.styleListView.TabIndex = 1;
            this.styleListView.UseCompatibleStateImageBehavior = false;
            this.styleListView.SelectedIndexChanged += new System.EventHandler(this.styleListView_SelectedIndexChanged);
            // 
            // addStyleButton
            // 
            this.addStyleButton.Location = new System.Drawing.Point(190, 378);
            this.addStyleButton.Name = "addStyleButton";
            this.addStyleButton.Size = new System.Drawing.Size(140, 60);
            this.addStyleButton.TabIndex = 2;
            this.addStyleButton.Text = "Add Style";
            this.addStyleButton.UseVisualStyleBackColor = true;
            this.addStyleButton.Click += new System.EventHandler(this.addStyleButton_Click);
            // 
            // openStyleFolderButton
            // 
            this.openStyleFolderButton.Location = new System.Drawing.Point(510, 378);
            this.openStyleFolderButton.Name = "openStyleFolderButton";
            this.openStyleFolderButton.Size = new System.Drawing.Size(140, 60);
            this.openStyleFolderButton.TabIndex = 3;
            this.openStyleFolderButton.Text = "Open Style Folder";
            this.openStyleFolderButton.UseVisualStyleBackColor = true;
            this.openStyleFolderButton.Click += new System.EventHandler(this.openStyleFolderButton_Click);
            // 
            // deleteStyleButton
            // 
            this.deleteStyleButton.Location = new System.Drawing.Point(350, 378);
            this.deleteStyleButton.Name = "deleteStyleButton";
            this.deleteStyleButton.Size = new System.Drawing.Size(140, 60);
            this.deleteStyleButton.TabIndex = 4;
            this.deleteStyleButton.Text = "Delete Style";
            this.deleteStyleButton.UseVisualStyleBackColor = true;
            this.deleteStyleButton.Click += new System.EventHandler(this.deleteStyleButton_Click);
            // 
            // loadImageButton
            // 
            this.loadImageButton.Location = new System.Drawing.Point(12, 12);
            this.loadImageButton.Name = "loadImageButton";
            this.loadImageButton.Size = new System.Drawing.Size(150, 60);
            this.loadImageButton.TabIndex = 5;
            this.loadImageButton.Text = "Load Image";
            this.loadImageButton.UseVisualStyleBackColor = true;
            this.loadImageButton.Click += new System.EventHandler(this.loadImageButton_Click);
            // 
            // loadedImagePictureBox
            // 
            this.loadedImagePictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.loadedImagePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loadedImagePictureBox.Location = new System.Drawing.Point(680, 25);
            this.loadedImagePictureBox.Name = "loadedImagePictureBox";
            this.loadedImagePictureBox.Size = new System.Drawing.Size(300, 200);
            this.loadedImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.loadedImagePictureBox.TabIndex = 6;
            this.loadedImagePictureBox.TabStop = false;
            // 
            // reworkedImagePictureBox
            // 
            this.reworkedImagePictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.reworkedImagePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.reworkedImagePictureBox.Location = new System.Drawing.Point(680, 249);
            this.reworkedImagePictureBox.Name = "reworkedImagePictureBox";
            this.reworkedImagePictureBox.Size = new System.Drawing.Size(300, 200);
            this.reworkedImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.reworkedImagePictureBox.TabIndex = 7;
            this.reworkedImagePictureBox.TabStop = false;
            // 
            // separatorLabel
            // 
            this.separatorLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.separatorLabel.Location = new System.Drawing.Point(175, 10);
            this.separatorLabel.Name = "separatorLabel";
            this.separatorLabel.Size = new System.Drawing.Size(2, 445);
            this.separatorLabel.TabIndex = 8;
            // 
            // separatorLabel2
            // 
            this.separatorLabel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.separatorLabel2.Location = new System.Drawing.Point(665, 10);
            this.separatorLabel2.Name = "separatorLabel2";
            this.separatorLabel2.Size = new System.Drawing.Size(2, 515);
            this.separatorLabel2.TabIndex = 9;
            // 
            // originalImageLabel
            // 
            this.originalImageLabel.AutoSize = true;
            this.originalImageLabel.Location = new System.Drawing.Point(680, 9);
            this.originalImageLabel.Name = "originalImageLabel";
            this.originalImageLabel.Size = new System.Drawing.Size(77, 13);
            this.originalImageLabel.TabIndex = 10;
            this.originalImageLabel.Text = "Original Image:";
            // 
            // reworkedImageLabel
            // 
            this.reworkedImageLabel.AutoSize = true;
            this.reworkedImageLabel.Location = new System.Drawing.Point(680, 233);
            this.reworkedImageLabel.Name = "reworkedImageLabel";
            this.reworkedImageLabel.Size = new System.Drawing.Size(91, 13);
            this.reworkedImageLabel.TabIndex = 11;
            this.reworkedImageLabel.Text = "Reworked Image:";
            // 
            // horizontalSeparatorLabel
            // 
            this.horizontalSeparatorLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.horizontalSeparatorLabel.Location = new System.Drawing.Point(9, 90);
            this.horizontalSeparatorLabel.Name = "horizontalSeparatorLabel";
            this.horizontalSeparatorLabel.Size = new System.Drawing.Size(160, 2);
            this.horizontalSeparatorLabel.TabIndex = 12;
            // 
            // styleWeightTextBox
            // 
            this.styleWeightTextBox.Location = new System.Drawing.Point(12, 160);
            this.styleWeightTextBox.Name = "styleWeightTextBox";
            this.styleWeightTextBox.Size = new System.Drawing.Size(150, 20);
            this.styleWeightTextBox.TabIndex = 13;
            this.styleWeightTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.styleWeightTextBox.TextChanged += new System.EventHandler(this.styleWeightTextBox_KeyPress);
            // 
            // styleWeightLabel
            // 
            this.styleWeightLabel.Location = new System.Drawing.Point(12, 140);
            this.styleWeightLabel.Name = "styleWeightLabel";
            this.styleWeightLabel.Size = new System.Drawing.Size(150, 15);
            this.styleWeightLabel.TabIndex = 14;
            this.styleWeightLabel.Text = "Style Weight:";
            this.styleWeightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // horizontalSeparatorLabel2
            // 
            this.horizontalSeparatorLabel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.horizontalSeparatorLabel2.Location = new System.Drawing.Point(9, 360);
            this.horizontalSeparatorLabel2.Name = "horizontalSeparatorLabel2";
            this.horizontalSeparatorLabel2.Size = new System.Drawing.Size(160, 2);
            this.horizontalSeparatorLabel2.TabIndex = 15;
            // 
            // iterationsCountLabel
            // 
            this.iterationsCountLabel.Location = new System.Drawing.Point(12, 200);
            this.iterationsCountLabel.Name = "iterationsCountLabel";
            this.iterationsCountLabel.Size = new System.Drawing.Size(150, 15);
            this.iterationsCountLabel.TabIndex = 16;
            this.iterationsCountLabel.Text = "Iterations Count:";
            this.iterationsCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // iterationsCountTextBox
            // 
            this.iterationsCountTextBox.Location = new System.Drawing.Point(12, 220);
            this.iterationsCountTextBox.Name = "iterationsCountTextBox";
            this.iterationsCountTextBox.Size = new System.Drawing.Size(150, 20);
            this.iterationsCountTextBox.TabIndex = 17;
            this.iterationsCountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.iterationsCountTextBox.TextChanged += new System.EventHandler(this.iterationsCountTextBox_KeyPress);
            // 
            // imageStyleLabel
            // 
            this.imageStyleLabel.Location = new System.Drawing.Point(12, 260);
            this.imageStyleLabel.Name = "imageStyleLabel";
            this.imageStyleLabel.Size = new System.Drawing.Size(150, 15);
            this.imageStyleLabel.TabIndex = 18;
            this.imageStyleLabel.Text = "Image Style:";
            this.imageStyleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // styleLabel
            // 
            this.styleLabel.BackColor = System.Drawing.SystemColors.Window;
            this.styleLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.styleLabel.Location = new System.Drawing.Point(12, 280);
            this.styleLabel.Name = "styleLabel";
            this.styleLabel.Size = new System.Drawing.Size(150, 50);
            this.styleLabel.TabIndex = 20;
            this.styleLabel.Text = "Select Style From List";
            this.styleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // programStatusLabel
            // 
            this.programStatusLabel.Location = new System.Drawing.Point(12, 450);
            this.programStatusLabel.Name = "programStatusLabel";
            this.programStatusLabel.Size = new System.Drawing.Size(150, 15);
            this.programStatusLabel.TabIndex = 21;
            this.programStatusLabel.Text = "Status:";
            this.programStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusLabel
            // 
            this.statusLabel.BackColor = System.Drawing.SystemColors.Window;
            this.statusLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statusLabel.Location = new System.Drawing.Point(12, 470);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(150, 50);
            this.statusLabel.TabIndex = 22;
            this.statusLabel.Text = "Load image";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // horizontalSeparatorLabel3
            // 
            this.horizontalSeparatorLabel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.horizontalSeparatorLabel3.Location = new System.Drawing.Point(190, 452);
            this.horizontalSeparatorLabel3.Name = "horizontalSeparatorLabel3";
            this.horizontalSeparatorLabel3.Size = new System.Drawing.Size(460, 2);
            this.horizontalSeparatorLabel3.TabIndex = 23;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(190, 496);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(460, 23);
            this.progressBar.TabIndex = 24;
            // 
            // openReworkedImageFolderButton
            // 
            this.openReworkedImageFolderButton.Location = new System.Drawing.Point(680, 460);
            this.openReworkedImageFolderButton.Name = "openReworkedImageFolderButton";
            this.openReworkedImageFolderButton.Size = new System.Drawing.Size(140, 60);
            this.openReworkedImageFolderButton.TabIndex = 25;
            this.openReworkedImageFolderButton.Text = "Open Image Folder";
            this.openReworkedImageFolderButton.UseVisualStyleBackColor = true;
            this.openReworkedImageFolderButton.Click += new System.EventHandler(this.openReworkedImageFolderButton_Click);
            // 
            // saveReworkedImageButton
            // 
            this.saveReworkedImageButton.Location = new System.Drawing.Point(840, 460);
            this.saveReworkedImageButton.Name = "saveReworkedImageButton";
            this.saveReworkedImageButton.Size = new System.Drawing.Size(140, 60);
            this.saveReworkedImageButton.TabIndex = 26;
            this.saveReworkedImageButton.Text = "Save Image";
            this.saveReworkedImageButton.UseVisualStyleBackColor = true;
            this.saveReworkedImageButton.Click += new System.EventHandler(this.saveReworkedImageButton_Click);
            // 
            // optionsLabel
            // 
            this.optionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.optionsLabel.Location = new System.Drawing.Point(12, 100);
            this.optionsLabel.Name = "optionsLabel";
            this.optionsLabel.Size = new System.Drawing.Size(150, 30);
            this.optionsLabel.TabIndex = 27;
            this.optionsLabel.Text = "OPTIONS:";
            this.optionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressLabel
            // 
            this.progressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.progressLabel.Location = new System.Drawing.Point(190, 465);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(460, 25);
            this.progressLabel.TabIndex = 28;
            this.progressLabel.Text = "Iteration progress counter";
            this.progressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 531);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.optionsLabel);
            this.Controls.Add(this.saveReworkedImageButton);
            this.Controls.Add(this.openReworkedImageFolderButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.horizontalSeparatorLabel3);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.programStatusLabel);
            this.Controls.Add(this.styleLabel);
            this.Controls.Add(this.imageStyleLabel);
            this.Controls.Add(this.iterationsCountTextBox);
            this.Controls.Add(this.iterationsCountLabel);
            this.Controls.Add(this.horizontalSeparatorLabel2);
            this.Controls.Add(this.styleWeightLabel);
            this.Controls.Add(this.styleWeightTextBox);
            this.Controls.Add(this.horizontalSeparatorLabel);
            this.Controls.Add(this.reworkedImageLabel);
            this.Controls.Add(this.originalImageLabel);
            this.Controls.Add(this.separatorLabel2);
            this.Controls.Add(this.separatorLabel);
            this.Controls.Add(this.reworkedImagePictureBox);
            this.Controls.Add(this.loadedImagePictureBox);
            this.Controls.Add(this.loadImageButton);
            this.Controls.Add(this.deleteStyleButton);
            this.Controls.Add(this.openStyleFolderButton);
            this.Controls.Add(this.addStyleButton);
            this.Controls.Add(this.styleListView);
            this.Controls.Add(this.startButton);
            this.Name = "Menu";
            this.Text = "Image Style Changer";
            this.Load += new System.EventHandler(this.Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.loadedImagePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reworkedImagePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.ListView styleListView;
        private System.Windows.Forms.Button addStyleButton;
        private System.Windows.Forms.Button openStyleFolderButton;
        private System.Windows.Forms.Button deleteStyleButton;
        private System.Windows.Forms.Button loadImageButton;
        private System.Windows.Forms.PictureBox loadedImagePictureBox;
        private System.Windows.Forms.PictureBox reworkedImagePictureBox;
        private System.Windows.Forms.Label separatorLabel;
        private System.Windows.Forms.Label separatorLabel2;
        private System.Windows.Forms.Label originalImageLabel;
        private System.Windows.Forms.Label reworkedImageLabel;
        private System.Windows.Forms.Label horizontalSeparatorLabel;
        private System.Windows.Forms.TextBox styleWeightTextBox;
        private System.Windows.Forms.Label styleWeightLabel;
        private System.Windows.Forms.Label horizontalSeparatorLabel2;
        private System.Windows.Forms.Label iterationsCountLabel;
        private System.Windows.Forms.TextBox iterationsCountTextBox;
        private System.Windows.Forms.Label imageStyleLabel;
        private System.Windows.Forms.Label styleLabel;
        private System.Windows.Forms.Label programStatusLabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label horizontalSeparatorLabel3;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button openReworkedImageFolderButton;
        private System.Windows.Forms.Button saveReworkedImageButton;
        private System.Windows.Forms.Label optionsLabel;
        private System.Windows.Forms.Label progressLabel;
    }
}

