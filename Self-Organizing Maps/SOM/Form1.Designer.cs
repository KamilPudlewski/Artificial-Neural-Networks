namespace SOM
{
    partial class Form1
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
            this.som_pictureBox = new System.Windows.Forms.PictureBox();
            this.liczba_neuronow_label = new System.Windows.Forms.Label();
            this.liczba_iteracji_label = new System.Windows.Forms.Label();
            this.wspolczynnik_uczenia_label = new System.Windows.Forms.Label();
            this.promien_sasiedztwa_label = new System.Windows.Forms.Label();
            this.som_progressBar = new System.Windows.Forms.ProgressBar();
            this.startButton = new System.Windows.Forms.Button();
            this.liczba_neuronow_textBox = new System.Windows.Forms.TextBox();
            this.liczba_iteracji_textBox = new System.Windows.Forms.TextBox();
            this.wspolczynnik_uczenia_textBox = new System.Windows.Forms.TextBox();
            this.iteracja_label = new System.Windows.Forms.Label();
            this.wspolczynnik_uczenia_akt_label = new System.Windows.Forms.Label();
            this.akt_liczba_iteracji = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.trianglePictureBox = new System.Windows.Forms.PictureBox();
            this.rectanglePictureBox = new System.Windows.Forms.PictureBox();
            this.rectangularTrianglePictureBox = new System.Windows.Forms.PictureBox();
            this.obtuseTrianglePictureBox = new System.Windows.Forms.PictureBox();
            this.drawCircleButton = new System.Windows.Forms.Button();
            this.parallelogramPictureBox = new System.Windows.Forms.PictureBox();
            this.circlePictureBox = new System.Windows.Forms.PictureBox();
            this.drawTriangleButton = new System.Windows.Forms.Button();
            this.drawQuadrangleButton = new System.Windows.Forms.Button();
            this.blockChangeShapeCheckBox = new System.Windows.Forms.CheckBox();
            this.rhombusPictureBox = new System.Windows.Forms.PictureBox();
            this.ellipse1PictureBox = new System.Windows.Forms.PictureBox();
            this.ellipse2PictureBox = new System.Windows.Forms.PictureBox();
            this.horizontalSeparatorLabel = new System.Windows.Forms.Label();
            this.promien_sasiedztwa_textBox = new System.Windows.Forms.TextBox();
            this.automaticLearningRateCheckBox = new System.Windows.Forms.CheckBox();
            this.verticalSeparatorLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.som_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trianglePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rectanglePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rectangularTrianglePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obtuseTrianglePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parallelogramPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circlePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rhombusPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ellipse1PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ellipse2PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // som_pictureBox
            // 
            this.som_pictureBox.Location = new System.Drawing.Point(10, 100);
            this.som_pictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.som_pictureBox.Name = "som_pictureBox";
            this.som_pictureBox.Size = new System.Drawing.Size(550, 360);
            this.som_pictureBox.TabIndex = 0;
            this.som_pictureBox.TabStop = false;
            this.som_pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.som_pictureBox_MouseClick);
            // 
            // liczba_neuronow_label
            // 
            this.liczba_neuronow_label.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.liczba_neuronow_label.Location = new System.Drawing.Point(10, 7);
            this.liczba_neuronow_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.liczba_neuronow_label.Name = "liczba_neuronow_label";
            this.liczba_neuronow_label.Size = new System.Drawing.Size(110, 15);
            this.liczba_neuronow_label.TabIndex = 1;
            this.liczba_neuronow_label.Text = "Liczba neuronów:";
            this.liczba_neuronow_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // liczba_iteracji_label
            // 
            this.liczba_iteracji_label.Location = new System.Drawing.Point(140, 7);
            this.liczba_iteracji_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.liczba_iteracji_label.Name = "liczba_iteracji_label";
            this.liczba_iteracji_label.Size = new System.Drawing.Size(110, 15);
            this.liczba_iteracji_label.TabIndex = 2;
            this.liczba_iteracji_label.Text = "Liczba iteracji:";
            this.liczba_iteracji_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wspolczynnik_uczenia_label
            // 
            this.wspolczynnik_uczenia_label.AutoSize = true;
            this.wspolczynnik_uczenia_label.Location = new System.Drawing.Point(277, 7);
            this.wspolczynnik_uczenia_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.wspolczynnik_uczenia_label.Name = "wspolczynnik_uczenia_label";
            this.wspolczynnik_uczenia_label.Size = new System.Drawing.Size(118, 13);
            this.wspolczynnik_uczenia_label.TabIndex = 3;
            this.wspolczynnik_uczenia_label.Text = "Współczynnik uczenia:";
            // 
            // promien_sasiedztwa_label
            // 
            this.promien_sasiedztwa_label.Location = new System.Drawing.Point(420, 7);
            this.promien_sasiedztwa_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.promien_sasiedztwa_label.Name = "promien_sasiedztwa_label";
            this.promien_sasiedztwa_label.Size = new System.Drawing.Size(110, 15);
            this.promien_sasiedztwa_label.TabIndex = 4;
            this.promien_sasiedztwa_label.Text = "Promień sąsiedztwa:";
            this.promien_sasiedztwa_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // som_progressBar
            // 
            this.som_progressBar.Location = new System.Drawing.Point(9, 79);
            this.som_progressBar.Margin = new System.Windows.Forms.Padding(2);
            this.som_progressBar.Name = "som_progressBar";
            this.som_progressBar.Size = new System.Drawing.Size(550, 19);
            this.som_progressBar.TabIndex = 5;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(800, 7);
            this.startButton.Margin = new System.Windows.Forms.Padding(2);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(90, 60);
            this.startButton.TabIndex = 6;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.start_button_Click);
            // 
            // liczba_neuronow_textBox
            // 
            this.liczba_neuronow_textBox.Location = new System.Drawing.Point(10, 25);
            this.liczba_neuronow_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.liczba_neuronow_textBox.Name = "liczba_neuronow_textBox";
            this.liczba_neuronow_textBox.Size = new System.Drawing.Size(110, 20);
            this.liczba_neuronow_textBox.TabIndex = 8;
            this.liczba_neuronow_textBox.TextChanged += new System.EventHandler(this.liczba_neuronow_textBox_TextChanged);
            // 
            // liczba_iteracji_textBox
            // 
            this.liczba_iteracji_textBox.Location = new System.Drawing.Point(140, 25);
            this.liczba_iteracji_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.liczba_iteracji_textBox.Name = "liczba_iteracji_textBox";
            this.liczba_iteracji_textBox.Size = new System.Drawing.Size(110, 20);
            this.liczba_iteracji_textBox.TabIndex = 9;
            this.liczba_iteracji_textBox.TextChanged += new System.EventHandler(this.liczba_iteracji_textBox_KeyPress);
            // 
            // wspolczynnik_uczenia_textBox
            // 
            this.wspolczynnik_uczenia_textBox.Location = new System.Drawing.Point(280, 25);
            this.wspolczynnik_uczenia_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.wspolczynnik_uczenia_textBox.Name = "wspolczynnik_uczenia_textBox";
            this.wspolczynnik_uczenia_textBox.Size = new System.Drawing.Size(110, 20);
            this.wspolczynnik_uczenia_textBox.TabIndex = 10;
            this.wspolczynnik_uczenia_textBox.TextChanged += new System.EventHandler(this.wspolczynnik_uczenia_textBox_KeyPress);
            // 
            // iteracja_label
            // 
            this.iteracja_label.AutoSize = true;
            this.iteracja_label.Location = new System.Drawing.Point(125, 55);
            this.iteracja_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.iteracja_label.Name = "iteracja_label";
            this.iteracja_label.Size = new System.Drawing.Size(13, 13);
            this.iteracja_label.TabIndex = 12;
            this.iteracja_label.Text = "0";
            // 
            // wspolczynnik_uczenia_akt_label
            // 
            this.wspolczynnik_uczenia_akt_label.AutoSize = true;
            this.wspolczynnik_uczenia_akt_label.Location = new System.Drawing.Point(358, 55);
            this.wspolczynnik_uczenia_akt_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.wspolczynnik_uczenia_akt_label.Name = "wspolczynnik_uczenia_akt_label";
            this.wspolczynnik_uczenia_akt_label.Size = new System.Drawing.Size(13, 13);
            this.wspolczynnik_uczenia_akt_label.TabIndex = 13;
            this.wspolczynnik_uczenia_akt_label.Text = "0";
            // 
            // akt_liczba_iteracji
            // 
            this.akt_liczba_iteracji.AutoSize = true;
            this.akt_liczba_iteracji.Location = new System.Drawing.Point(10, 55);
            this.akt_liczba_iteracji.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.akt_liczba_iteracji.Name = "akt_liczba_iteracji";
            this.akt_liczba_iteracji.Size = new System.Drawing.Size(115, 13);
            this.akt_liczba_iteracji.TabIndex = 15;
            this.akt_liczba_iteracji.Text = "Aktualna liczba iteracji:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(200, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Aktualny współczynnik uczenia:";
            // 
            // trianglePictureBox
            // 
            this.trianglePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.trianglePictureBox.Location = new System.Drawing.Point(570, 80);
            this.trianglePictureBox.Name = "trianglePictureBox";
            this.trianglePictureBox.Size = new System.Drawing.Size(100, 100);
            this.trianglePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.trianglePictureBox.TabIndex = 17;
            this.trianglePictureBox.TabStop = false;
            this.trianglePictureBox.Click += new System.EventHandler(this.trianglePictureBox_Click);
            // 
            // rectanglePictureBox
            // 
            this.rectanglePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rectanglePictureBox.Location = new System.Drawing.Point(570, 190);
            this.rectanglePictureBox.Name = "rectanglePictureBox";
            this.rectanglePictureBox.Size = new System.Drawing.Size(100, 100);
            this.rectanglePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rectanglePictureBox.TabIndex = 18;
            this.rectanglePictureBox.TabStop = false;
            this.rectanglePictureBox.Click += new System.EventHandler(this.rectanglePictureBox_Click);
            // 
            // rectangularTrianglePictureBox
            // 
            this.rectangularTrianglePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rectangularTrianglePictureBox.Location = new System.Drawing.Point(680, 80);
            this.rectangularTrianglePictureBox.Name = "rectangularTrianglePictureBox";
            this.rectangularTrianglePictureBox.Size = new System.Drawing.Size(100, 100);
            this.rectangularTrianglePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rectangularTrianglePictureBox.TabIndex = 19;
            this.rectangularTrianglePictureBox.TabStop = false;
            this.rectangularTrianglePictureBox.Click += new System.EventHandler(this.rectangularTrianglePictureBox_Click);
            // 
            // obtuseTrianglePictureBox
            // 
            this.obtuseTrianglePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.obtuseTrianglePictureBox.Location = new System.Drawing.Point(790, 80);
            this.obtuseTrianglePictureBox.Name = "obtuseTrianglePictureBox";
            this.obtuseTrianglePictureBox.Size = new System.Drawing.Size(100, 100);
            this.obtuseTrianglePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.obtuseTrianglePictureBox.TabIndex = 20;
            this.obtuseTrianglePictureBox.TabStop = false;
            this.obtuseTrianglePictureBox.Click += new System.EventHandler(this.obtuseTrianglePictureBox_Click);
            // 
            // drawCircleButton
            // 
            this.drawCircleButton.Location = new System.Drawing.Point(790, 410);
            this.drawCircleButton.Name = "drawCircleButton";
            this.drawCircleButton.Size = new System.Drawing.Size(100, 49);
            this.drawCircleButton.TabIndex = 21;
            this.drawCircleButton.Text = "Rysuj okrąg";
            this.drawCircleButton.UseVisualStyleBackColor = true;
            this.drawCircleButton.Click += new System.EventHandler(this.drawCircleButton_Click);
            // 
            // parallelogramPictureBox
            // 
            this.parallelogramPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parallelogramPictureBox.Location = new System.Drawing.Point(680, 190);
            this.parallelogramPictureBox.Name = "parallelogramPictureBox";
            this.parallelogramPictureBox.Size = new System.Drawing.Size(100, 100);
            this.parallelogramPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.parallelogramPictureBox.TabIndex = 23;
            this.parallelogramPictureBox.TabStop = false;
            this.parallelogramPictureBox.Click += new System.EventHandler(this.parallelogramPictureBox_Click);
            // 
            // circlePictureBox
            // 
            this.circlePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.circlePictureBox.Location = new System.Drawing.Point(570, 300);
            this.circlePictureBox.Name = "circlePictureBox";
            this.circlePictureBox.Size = new System.Drawing.Size(100, 100);
            this.circlePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.circlePictureBox.TabIndex = 24;
            this.circlePictureBox.TabStop = false;
            this.circlePictureBox.Click += new System.EventHandler(this.circlePictureBox_Click);
            // 
            // drawTriangleButton
            // 
            this.drawTriangleButton.Location = new System.Drawing.Point(570, 410);
            this.drawTriangleButton.Name = "drawTriangleButton";
            this.drawTriangleButton.Size = new System.Drawing.Size(100, 50);
            this.drawTriangleButton.TabIndex = 25;
            this.drawTriangleButton.Text = "Rysuj trójkąt";
            this.drawTriangleButton.UseVisualStyleBackColor = true;
            this.drawTriangleButton.Click += new System.EventHandler(this.drawTriangleButton_Click);
            // 
            // drawQuadrangleButton
            // 
            this.drawQuadrangleButton.Location = new System.Drawing.Point(680, 410);
            this.drawQuadrangleButton.Name = "drawQuadrangleButton";
            this.drawQuadrangleButton.Size = new System.Drawing.Size(100, 50);
            this.drawQuadrangleButton.TabIndex = 26;
            this.drawQuadrangleButton.Text = "Rysuj czworokąt";
            this.drawQuadrangleButton.UseVisualStyleBackColor = true;
            this.drawQuadrangleButton.Click += new System.EventHandler(this.drawQuadrangleButton_Click);
            // 
            // blockChangeShapeCheckBox
            // 
            this.blockChangeShapeCheckBox.AutoSize = true;
            this.blockChangeShapeCheckBox.Checked = true;
            this.blockChangeShapeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.blockChangeShapeCheckBox.Location = new System.Drawing.Point(570, 37);
            this.blockChangeShapeCheckBox.Name = "blockChangeShapeCheckBox";
            this.blockChangeShapeCheckBox.Size = new System.Drawing.Size(227, 17);
            this.blockChangeShapeCheckBox.TabIndex = 27;
            this.blockChangeShapeCheckBox.Text = "Blokada zmiany kształtu w trakcie uczenia";
            this.blockChangeShapeCheckBox.UseVisualStyleBackColor = true;
            this.blockChangeShapeCheckBox.CheckedChanged += new System.EventHandler(this.blockChangeShapeCheckBox_CheckedChanged);
            // 
            // rhombusPictureBox
            // 
            this.rhombusPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rhombusPictureBox.Location = new System.Drawing.Point(790, 190);
            this.rhombusPictureBox.Name = "rhombusPictureBox";
            this.rhombusPictureBox.Size = new System.Drawing.Size(100, 100);
            this.rhombusPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rhombusPictureBox.TabIndex = 29;
            this.rhombusPictureBox.TabStop = false;
            this.rhombusPictureBox.Click += new System.EventHandler(this.rhombusPictureBox_Click);
            // 
            // ellipse1PictureBox
            // 
            this.ellipse1PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ellipse1PictureBox.Location = new System.Drawing.Point(680, 300);
            this.ellipse1PictureBox.Name = "ellipse1PictureBox";
            this.ellipse1PictureBox.Size = new System.Drawing.Size(100, 100);
            this.ellipse1PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ellipse1PictureBox.TabIndex = 30;
            this.ellipse1PictureBox.TabStop = false;
            this.ellipse1PictureBox.Click += new System.EventHandler(this.ellipse1PictureBox_Click);
            // 
            // ellipse2PictureBox
            // 
            this.ellipse2PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ellipse2PictureBox.Location = new System.Drawing.Point(790, 300);
            this.ellipse2PictureBox.Name = "ellipse2PictureBox";
            this.ellipse2PictureBox.Size = new System.Drawing.Size(100, 100);
            this.ellipse2PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ellipse2PictureBox.TabIndex = 31;
            this.ellipse2PictureBox.TabStop = false;
            this.ellipse2PictureBox.Click += new System.EventHandler(this.ellipse2PictureBox_Click);
            // 
            // horizontalSeparatorLabel
            // 
            this.horizontalSeparatorLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.horizontalSeparatorLabel.Location = new System.Drawing.Point(10, 75);
            this.horizontalSeparatorLabel.Name = "horizontalSeparatorLabel";
            this.horizontalSeparatorLabel.Size = new System.Drawing.Size(880, 2);
            this.horizontalSeparatorLabel.TabIndex = 32;
            // 
            // promien_sasiedztwa_textBox
            // 
            this.promien_sasiedztwa_textBox.Enabled = false;
            this.promien_sasiedztwa_textBox.Location = new System.Drawing.Point(420, 25);
            this.promien_sasiedztwa_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.promien_sasiedztwa_textBox.Name = "promien_sasiedztwa_textBox";
            this.promien_sasiedztwa_textBox.Size = new System.Drawing.Size(110, 20);
            this.promien_sasiedztwa_textBox.TabIndex = 33;
            this.promien_sasiedztwa_textBox.TextChanged += new System.EventHandler(this.promien_sasiedztwa_textBox_TextChanged);
            // 
            // automaticLearningRateCheckBox
            // 
            this.automaticLearningRateCheckBox.AutoSize = true;
            this.automaticLearningRateCheckBox.Checked = true;
            this.automaticLearningRateCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.automaticLearningRateCheckBox.Location = new System.Drawing.Point(570, 14);
            this.automaticLearningRateCheckBox.Name = "automaticLearningRateCheckBox";
            this.automaticLearningRateCheckBox.Size = new System.Drawing.Size(200, 17);
            this.automaticLearningRateCheckBox.TabIndex = 34;
            this.automaticLearningRateCheckBox.Text = "Automatyczny współczynnik uczenia";
            this.automaticLearningRateCheckBox.UseVisualStyleBackColor = true;
            this.automaticLearningRateCheckBox.CheckedChanged += new System.EventHandler(this.automaticLearningRateCheckBox_CheckedChanged);
            // 
            // verticalSeparatorLabel
            // 
            this.verticalSeparatorLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.verticalSeparatorLabel.Location = new System.Drawing.Point(560, 7);
            this.verticalSeparatorLabel.Name = "verticalSeparatorLabel";
            this.verticalSeparatorLabel.Size = new System.Drawing.Size(2, 60);
            this.verticalSeparatorLabel.TabIndex = 35;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 471);
            this.Controls.Add(this.verticalSeparatorLabel);
            this.Controls.Add(this.automaticLearningRateCheckBox);
            this.Controls.Add(this.promien_sasiedztwa_textBox);
            this.Controls.Add(this.horizontalSeparatorLabel);
            this.Controls.Add(this.ellipse2PictureBox);
            this.Controls.Add(this.ellipse1PictureBox);
            this.Controls.Add(this.rhombusPictureBox);
            this.Controls.Add(this.blockChangeShapeCheckBox);
            this.Controls.Add(this.drawQuadrangleButton);
            this.Controls.Add(this.drawTriangleButton);
            this.Controls.Add(this.circlePictureBox);
            this.Controls.Add(this.parallelogramPictureBox);
            this.Controls.Add(this.drawCircleButton);
            this.Controls.Add(this.obtuseTrianglePictureBox);
            this.Controls.Add(this.rectangularTrianglePictureBox);
            this.Controls.Add(this.rectanglePictureBox);
            this.Controls.Add(this.trianglePictureBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.akt_liczba_iteracji);
            this.Controls.Add(this.wspolczynnik_uczenia_akt_label);
            this.Controls.Add(this.iteracja_label);
            this.Controls.Add(this.wspolczynnik_uczenia_textBox);
            this.Controls.Add(this.liczba_iteracji_textBox);
            this.Controls.Add(this.liczba_neuronow_textBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.som_progressBar);
            this.Controls.Add(this.promien_sasiedztwa_label);
            this.Controls.Add(this.wspolczynnik_uczenia_label);
            this.Controls.Add(this.liczba_iteracji_label);
            this.Controls.Add(this.liczba_neuronow_label);
            this.Controls.Add(this.som_pictureBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "SOM";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.som_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trianglePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rectanglePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rectangularTrianglePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obtuseTrianglePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parallelogramPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circlePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rhombusPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ellipse1PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ellipse2PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox som_pictureBox;
        private System.Windows.Forms.Label liczba_neuronow_label;
        private System.Windows.Forms.Label liczba_iteracji_label;
        private System.Windows.Forms.Label wspolczynnik_uczenia_label;
        private System.Windows.Forms.Label promien_sasiedztwa_label;
        private System.Windows.Forms.ProgressBar som_progressBar;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TextBox liczba_neuronow_textBox;
        private System.Windows.Forms.TextBox liczba_iteracji_textBox;
        private System.Windows.Forms.TextBox wspolczynnik_uczenia_textBox;
        private System.Windows.Forms.Label iteracja_label;
        private System.Windows.Forms.Label wspolczynnik_uczenia_akt_label;
        private System.Windows.Forms.Label akt_liczba_iteracji;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox trianglePictureBox;
        private System.Windows.Forms.PictureBox rectanglePictureBox;
        private System.Windows.Forms.PictureBox rectangularTrianglePictureBox;
        private System.Windows.Forms.PictureBox obtuseTrianglePictureBox;
        private System.Windows.Forms.Button drawCircleButton;
        private System.Windows.Forms.PictureBox parallelogramPictureBox;
        private System.Windows.Forms.PictureBox circlePictureBox;
        private System.Windows.Forms.Button drawTriangleButton;
        private System.Windows.Forms.Button drawQuadrangleButton;
        private System.Windows.Forms.CheckBox blockChangeShapeCheckBox;
        private System.Windows.Forms.PictureBox rhombusPictureBox;
        private System.Windows.Forms.PictureBox ellipse1PictureBox;
        private System.Windows.Forms.PictureBox ellipse2PictureBox;
        private System.Windows.Forms.Label horizontalSeparatorLabel;
        private System.Windows.Forms.TextBox promien_sasiedztwa_textBox;
        private System.Windows.Forms.CheckBox automaticLearningRateCheckBox;
        private System.Windows.Forms.Label verticalSeparatorLabel;
    }
}

