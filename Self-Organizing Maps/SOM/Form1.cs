using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SOM
{
    public partial class Form1 : Form
    {
        public SOM som = new SOM();
        public Shape shape;
        private Graphics g;
        private const int width = 550;
        private const int height = 360;
        bool enablePaint = false;
        bool enableChangeShape = false;

        public Form1()
        {  
            InitializeComponent();

            g = som_pictureBox.CreateGraphics();
            som_pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.CreateEmptyPictureBox);

            liczba_neuronow_textBox.Text = "10";
            liczba_iteracji_textBox.Text = "1000";
            wspolczynnik_uczenia_textBox.Text = "1";

            // Load figures option
            trianglePictureBox.Image = Image.FromFile("../../Assets/Triangle.png");
            rectangularTrianglePictureBox.Image = Image.FromFile("../../Assets/Rectangular Triangle.png");
            obtuseTrianglePictureBox.Image = Image.FromFile("../../Assets/Obtuse Triangle.png");
            rectanglePictureBox.Image = Image.FromFile("../../Assets/Rectangle.png");
            parallelogramPictureBox.Image = Image.FromFile("../../Assets/Parallelogram.png");
            rhombusPictureBox.Image = Image.FromFile("../../Assets/Rhombus.png");
            circlePictureBox.Image = Image.FromFile("../../Assets/Circle.png");
            ellipse1PictureBox.Image = Image.FromFile("../../Assets/Ellipse1.png");
            ellipse2PictureBox.Image = Image.FromFile("../../Assets/Ellipse2.png");
            DisableStartButton();
        }
        
        private void CreateEmptyPictureBox (object sender, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.White, new Rectangle(0, 0, width, height));
        }

        private void DrawPoint(float x, float y, Brush brush)
        {
            Graphics g = som_pictureBox.CreateGraphics();
            g.FillRectangle(brush, x, y, 3, 3);
        }

        private void DrawEdge(Point point1, Point point2)
        {
            Graphics g = som_pictureBox.CreateGraphics();
            g.DrawLine(Pens.Black, point1.X, point1.Y, point2.X, point2.Y);
        }

        public void DrawSOM(Point randomPoint)
        {
            List<Point> neurony = som.ReturnNeuronList();

            // Updating information in labels
            iteracja_label.Text = som.IterationNumber.ToString();
            wspolczynnik_uczenia_akt_label.Text = som.LearningRate.ToString();
            promien_sasiedztwa_textBox.Text = som.NeighborhoodRadius.ToString();

            // Draw triangle, random point and all neurons
            Graphics g = som_pictureBox.CreateGraphics();
            g.Clear(Color.White);

            shape.Draw(som_pictureBox);

            DrawPoint(randomPoint.X, randomPoint.Y, Brushes.Red);

            for (int i = 0; i < neurony.Count - 1; i++)
            {
                if (i == 0)
                {
                    DrawPoint(neurony[i].X, neurony[i].Y, Brushes.Black);
                }
                DrawEdge(neurony[i], neurony[i + 1]);
                DrawPoint(neurony[i + 1].X, neurony[i + 1].Y, Brushes.Black);
            }
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            // Protection of the entered data
            if (liczba_neuronow_textBox.Text.Length == 0)
            {
                MessageBox.Show("Podaj liczbe neuronow!", "Blad", MessageBoxButtons.OK);
                return;
            }

            if (liczba_iteracji_textBox.Text.Length == 0)
            {
                MessageBox.Show("Podaj liczbe iteracji!", "Blad", MessageBoxButtons.OK);
                return;
            }

            // Preparation and launch of the algorithm
            int neuronCount = Convert.ToInt32(liczba_neuronow_textBox.Text);

            som = new SOM(neuronCount, shape, Int32.Parse(promien_sasiedztwa_textBox.Text));

            som.RandomNeurons();
            shape.Draw(som_pictureBox);

            List<Point> neurony = som.ReturnNeuronList();
            for (int i = 0; i < neurony.Count - 1; i++)
            {
                if (i == 0)
                {
                    DrawPoint(neurony[i].X, neurony[i].Y, Brushes.Black);
                }
                DrawEdge(neurony[i], neurony[i + 1]);
                DrawPoint(neurony[i + 1].X, neurony[i + 1].Y, Brushes.Black);
            }

            if (som == null)
            {
                MessageBox.Show("Som nie zostal prawidlowo zainicjowany", "Blad", MessageBoxButtons.OK);
                return;
            }
            else if (som.ReturnNeuronCount() == 0)
            {
                MessageBox.Show("Podaj poprawna liczbe neuronow", "Blad", MessageBoxButtons.OK);
                return;
            }
            else if (wspolczynnik_uczenia_textBox.Text.Length == 0)
            {
                MessageBox.Show("Podaj wspolczynnik uczenia", "Blad", MessageBoxButtons.OK);
                return;
            }

            som.IterationCount = Convert.ToInt32(liczba_iteracji_textBox.Text);
            som.LearningRate = double.Parse(wspolczynnik_uczenia_textBox.Text, System.Globalization.CultureInfo.InvariantCulture);

            som_progressBar.Value = 0;
            som.StartSOM(DrawSOM, som_progressBar);
        }

        // Secure data entry in textboxes
        private void liczba_neuronow_textBox_KeyPress(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(liczba_neuronow_textBox.Text, "[^0-9]"))
            {
                MessageBox.Show("Prosze wprowadzic tylko liczby!");
                liczba_neuronow_textBox.Text = liczba_neuronow_textBox.Text.Remove(liczba_neuronow_textBox.Text.Length - 1);
            }
        }

        private void liczba_neuronow_textBox_TextChanged(object sender, EventArgs e)
        {
            if (automaticLearningRateCheckBox.Checked)
            {
                try
                {
                    promien_sasiedztwa_textBox.Text = (Convert.ToInt32(liczba_neuronow_textBox.Text) / 2).ToString();
                }
                catch
                {

                }
            }
        }

        private void liczba_iteracji_textBox_KeyPress(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(liczba_iteracji_textBox.Text, "[^0-9]"))
            {
                MessageBox.Show("Prosze wprowadzic tylko liczby!");
                liczba_iteracji_textBox.Text = liczba_iteracji_textBox.Text.Remove(liczba_iteracji_textBox.Text.Length - 1);
            }
        }

        private void wspolczynnik_uczenia_textBox_KeyPress(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(wspolczynnik_uczenia_textBox.Text, "[^0-9,.]"))
            {
                MessageBox.Show("Prosze wprowadzic tylko liczby!");
                wspolczynnik_uczenia_textBox.Text = wspolczynnik_uczenia_textBox.Text.Remove(wspolczynnik_uczenia_textBox.Text.Length - 1);
            }
        }

        private void promien_sasiedztwa_textBox_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(wspolczynnik_uczenia_textBox.Text, "[^0-9,.]"))
            {
                MessageBox.Show("Prosze wprowadzic tylko liczby!");
                promien_sasiedztwa_textBox.Text = promien_sasiedztwa_textBox.Text.Remove(promien_sasiedztwa_textBox.Text.Length - 1);
            }

            if (Int32.Parse(promien_sasiedztwa_textBox.Text) > Int32.Parse(liczba_neuronow_textBox.Text))
            {
                promien_sasiedztwa_textBox.Text = liczba_neuronow_textBox.Text;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Example Shapes

        #region Triangles

        private void trianglePictureBox_Click(object sender, EventArgs e)
        {
            if (ChangeShapeStatus())
            {
                som_pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.CreateEmptyPictureBox);
                Point a = new Point(50, 350);
                Point b = new Point(275, 10);
                Point c = new Point(500, 350);
                shape = new Triangle(a, b, c);
                shape.Draw(som_pictureBox);
                DisablePaintMode();
                EnableStartButton();
                SOMChangeShape();
            }
        }

        private void rectangularTrianglePictureBox_Click(object sender, EventArgs e)
        {
            if (ChangeShapeStatus())
            {
                som_pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.CreateEmptyPictureBox);
                Point a = new Point(50, 350);
                Point b = new Point(50, 10);
                Point c = new Point(500, 350);
                shape = new Triangle(a, b, c);
                shape.Draw(som_pictureBox);
                DisablePaintMode();
                EnableStartButton();
                SOMChangeShape();
            }
        }

        private void obtuseTrianglePictureBox_Click(object sender, EventArgs e)
        {
            if (ChangeShapeStatus())
            {
                som_pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.CreateEmptyPictureBox);
                Point a = new Point(200, 350);
                Point b = new Point(50, 10);
                Point c = new Point(500, 350);
                shape = new Triangle(a, b, c);
                shape.Draw(som_pictureBox);
                DisablePaintMode();
                EnableStartButton();
                SOMChangeShape();
            }
        }

        #endregion

        #region Quadrangles

        private void rectanglePictureBox_Click(object sender, EventArgs e)
        {
            if (ChangeShapeStatus())
            {
                Point a = new Point(50, 50);
                Point b = new Point(500, 50);
                Point c = new Point(500, 300);
                Point d = new Point(50, 300);
                shape = new Quadrangle(a, b, c, d);
                shape.Draw(som_pictureBox);
                DisablePaintMode();
                EnableStartButton();
                SOMChangeShape();
            }
        }

        private void parallelogramPictureBox_Click(object sender, EventArgs e)
        {
            if (ChangeShapeStatus())
            {
                Point a = new Point(150, 50);
                Point b = new Point(500, 50);
                Point c = new Point(400, 300);
                Point d = new Point(50, 300);
                shape = new Quadrangle(a, b, c, d);
                shape.Draw(som_pictureBox);
                DisablePaintMode();
                EnableStartButton();
                SOMChangeShape();
            }
        }

        private void rhombusPictureBox_Click(object sender, EventArgs e)
        {
            if (ChangeShapeStatus())
            {
                Point a = new Point(80, 180);
                Point b = new Point(280, 30);
                Point c = new Point(480, 180);
                Point d = new Point(280, 330);
                shape = new Quadrangle(a, b, c, d);
                shape.Draw(som_pictureBox);
                DisablePaintMode();
                EnableStartButton();
                SOMChangeShape();
            }
        }

        #endregion

        #region Circles & Ellipse

        private void circlePictureBox_Click(object sender, EventArgs e)
        {
            if(ChangeShapeStatus())
            {
                float radius = 150;
                Point a = new Point(width / 2 - radius, height / 2 - radius);
                shape = new Circle(a, 2 * radius);
                shape.Draw(som_pictureBox);
                EnableStartButton();
                SOMChangeShape();
            }
        }

        private void ellipse1PictureBox_Click(object sender, EventArgs e)
        {
            if (ChangeShapeStatus())
            {
                float radiusX = 100;
                float radiusY = 150;
                Point a = new Point(width / 2 - radiusX, height / 2 - radiusY);
                shape = new Ellipse(a, 2 * radiusX, 2 * radiusY);
                shape.Draw(som_pictureBox);
                EnableStartButton();
                SOMChangeShape();
            }
        }

        private void ellipse2PictureBox_Click(object sender, EventArgs e)
        {
            if (ChangeShapeStatus())
            {
                float radiusX = 200;
                float radiusY = 100;
                Point a = new Point(width / 2 - radiusX, height / 2 - radiusY);
                shape = new Ellipse(a, 2 * radiusX, 2 * radiusY);
                shape.Draw(som_pictureBox);
                EnableStartButton();
                SOMChangeShape();
            }
        }

        #endregion

        private void som_pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if(enablePaint && ChangeShapeStatus())
            {
                Point point = new Point(e.X, e.Y);
                shape.AddPoint(point);
                shape.Draw(som_pictureBox);
                if (shape.IsComplete())
                {
                    DisablePaintMode();
                    EnableStartButton();
                    SOMChangeShape();
                }
            }
        }

        private void drawTriangleButton_Click(object sender, EventArgs e)
        {
            if (ChangeShapeStatus())
            {
                if (enablePaint)
                {
                    shape.Draw(som_pictureBox);
                    drawTriangleButton.Text = "Rysuj trójkąt";
                    EnableStartButton();
                }
                else
                {
                    drawTriangleButton.Text = "Zakończ rysowanie";
                    shape = new Triangle();
                    shape.Draw(som_pictureBox);
                    DisableStartButton();
                }
                enablePaint = !enablePaint;
            }
        }

        private void drawQuadrangleButton_Click(object sender, EventArgs e)
        {
            if (ChangeShapeStatus())
            {
                if (enablePaint)
                {
                    shape.Draw(som_pictureBox);
                    drawQuadrangleButton.Text = "Rysuj czworokąt";
                    EnableStartButton();
                }
                else
                {
                    drawQuadrangleButton.Text = "Zakończ rysowanie";
                    shape = new Quadrangle();
                    shape.Draw(som_pictureBox);
                    DisableStartButton();
                }
                enablePaint = !enablePaint;
            }
        }

        private void drawCircleButton_Click(object sender, EventArgs e)
        {
            if (ChangeShapeStatus())
            {
                if (enablePaint)
                {
                    shape.Draw(som_pictureBox);
                    drawCircleButton.Text = "Rysuj okrąg";
                    EnableStartButton();
                }
                else
                {
                    drawCircleButton.Text = "Zakończ rysowanie";
                    shape = new Circle();
                    shape.Draw(som_pictureBox);
                    DisableStartButton();
                }
                enablePaint = !enablePaint;
            }
        }

        private void DisableStartButton()
        {
            startButton.Enabled = false;
        }

        private void EnableStartButton()
        {
            if (shape.IsComplete())
            {
                startButton.Enabled = true;
            }
        }

        private void DisablePaintMode()
        {
            enablePaint = false;
            drawTriangleButton.Text = "Rysuj trójkąt";
            drawQuadrangleButton.Text = "Rysuj czworokąt";
            drawCircleButton.Text = "Rysuj okrąg";
        }

        private void SOMChangeShape()
        {
            if (som.WorkingStatus == true)
            {
                som.ChangeShape(shape);
            }
        }

        private bool ChangeShapeStatus()
        {
            if (som.WorkingStatus == true && enableChangeShape == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void blockChangeShapeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (blockChangeShapeCheckBox.Checked == true)
            {
                enableChangeShape = false;
            }
            else
            {
                enableChangeShape = true;
            }
        }

        private void automaticLearningRateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (automaticLearningRateCheckBox.Checked == true)
            {
                DisableNeighborhoodRadiusTextBox();
                promien_sasiedztwa_textBox.Text = (Convert.ToInt32(liczba_neuronow_textBox.Text) / 2).ToString();
            }
            else
            {
                EnableNeighborhoodRadiusTextBox();
            }
        }

        private void EnableNeighborhoodRadiusTextBox()
        {
            promien_sasiedztwa_textBox.Enabled = true;
        }

        private void DisableNeighborhoodRadiusTextBox()
        {
            promien_sasiedztwa_textBox.Enabled = false;
        }
    }


    public class SOM
    {
        private ProgressBar som_progressBar;
        private Shape shape;
        public delegate void DrawFunction(Point randomPoint);
        public bool WorkingStatus = false;

        private List<Point> NeuronsList = new List<Point>();
        private int NeuronCount = 0;
        private Timer timer = new Timer();

        public int IterationCount { get; set; }
        public double LearningRate { get; set; }
        public int NeighborhoodRadius { private set; get;}
        public int IterationNumber { private set; get; }

        public SOM()
        {

        }

        public SOM(int setNeuronCount, Shape setShape, int setNeighborhoodRadius)
        {
            NeuronCount = setNeuronCount;
            shape = setShape;
            NeighborhoodRadius = setNeighborhoodRadius;
        }

        public void ChangeShape(Shape setShape)
        {
            shape = setShape;
        }

        public int ReturnNeuronCount()
        {
            return NeuronCount;
        }

        public void RandomNeurons()
        {
            for (int i = 0; i < NeuronCount; i++)
            {
                NeuronsList.Add(shape.RandomPointIn());
            }
        }

        public List<Point> ReturnNeuronList()
        {
            return NeuronsList;
        }

        public double DistanceBetweenPoints(Point point1, Point point2)
        {
            return Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));
        }

        public void TimerTick(object sender, EventArgs e)
        {

            timer.Stop();
        }

        public void ProgressTick()
        {
            som_progressBar.Increment(1);
        }

        public async void StartSOM(DrawFunction drawSOM, ProgressBar progressBar)
        {
            WorkingStatus = true;

            double somLearningRate = LearningRate;
            double tmpLearningRate = LearningRate;

            int sigma = NeuronCount / 2;
            double lambda = IterationCount / Math.Log(sigma);
            int neighborhoodReductionStep = IterationCount / NeighborhoodRadius;

            // Progress bar
            som_progressBar = progressBar;
            som_progressBar.Maximum = IterationCount;

            timer.Interval = 1;
            timer.Tick += TimerTick;

            for (int i = 0; i < IterationCount; i++)
            {
                IterationNumber = i + 1;

                // Reduction of neighborhood radius
                if ((i + 1) % neighborhoodReductionStep == 0)
                {
                    NeighborhoodRadius--;
                }

                Point randomPoint = shape.RandomPointIn();

                // Calculation of distance between points
                List<double> distances = new List<double>();
                foreach (Point neuron in NeuronsList)
                {
                    double sum = DistanceBetweenPoints(randomPoint, neuron);
                    distances.Add(sum);
                }

                // Set the neuron index of the nearest selected point and radius of neighbors
                int nearestIndex = distances.IndexOf(distances.Min());
                int firstIndex = 0;
                int lastIndex = 0;

                if (nearestIndex - NeighborhoodRadius < 0)
                {
                    firstIndex = 0;
                }
                else
                {
                    firstIndex = nearestIndex - NeighborhoodRadius;
                }

                if (nearestIndex + NeighborhoodRadius > NeuronCount)
                {
                    lastIndex = NeuronCount;
                }
                else
                {
                    lastIndex = nearestIndex + NeighborhoodRadius;
                }

                NeuronsList[nearestIndex] = NeuronsList[nearestIndex] + somLearningRate * (randomPoint - NeuronsList[nearestIndex]);

                // Moving neurons
                for (int j = firstIndex; j < lastIndex; j++)
                {
                    if (j == nearestIndex) continue;
                    NeuronsList[j] = NeuronsList[j] + somLearningRate / Math.Abs(nearestIndex - j) * (randomPoint - NeuronsList[j]);
                }

                timer.Start();
                await Task.Run(() => {
                    while (timer.Enabled) { }
                });

                // Decreasing learning rate
                double x = Math.Exp(-(i + 1) / lambda);
                somLearningRate = tmpLearningRate * x;
                LearningRate = somLearningRate;

                // Update pictureBox
                drawSOM(randomPoint);

                // Update progressBar
                ProgressTick();

                // 
                if (i == IterationCount - 1)
                {
                    WorkingStatus = false;
                }
            }
        }
    }
}
