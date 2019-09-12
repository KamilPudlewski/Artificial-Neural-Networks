using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiecHopfielda
{
    public partial class SiecHopfielda : Form
    {
        private static int size = 10;
        private static int cellSize = 50;
        private static int gridSize = size * size;

        private Graphics g;
        private Rectangle[,] grid = new Rectangle[size, size];
        private int[,] inputGrid = new int[size, size];
        private int[] inputArray = new int[gridSize];
        private double[,] weights = new double[gridSize, gridSize];

        private int uniquePatternID = 0;
        private int patternCounter = 0;

        private List<int> shuffledList = new List<int>();
        private Dictionary<string, int[]> patternDic = new Dictionary<string, int[]>();
        private bool stopTest = false;

        public SiecHopfielda()
        {
            InitializeComponent();
        }


        private void SiecHopfielda_Load(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
            InitializeBitGrid();
            shuffledList.AddRange(Enumerable.Range(0, gridSize));
            shuffledList = ShuffleList(shuffledList);

            // Connect the Paint event of the PictureBox to the event handler method.
            pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.CreateGrid);
            pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.CreateGridPools);

            // Add the PictureBox control to the Form.
            this.Controls.Add(pictureBox1);

            EnableTrainButtons();
        }

        private void InitializeBitGrid()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    inputGrid[i, j] = -1;
                }
            }
        }

        private void CreateGrid(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            int height = 0;

            for (int i = 0; i < size; i++)
            {
                int width = 0;
                for (int j = 0; j < size; j++)
                {
                    Rectangle cellRectangle = new Rectangle(width, height, cellSize, cellSize);
                    grid[i, j] = cellRectangle;
                    e.Graphics.DrawRectangle(Pens.Black, cellRectangle);
                    width += cellSize;
                }
                height += cellSize;
            }
        }

        private void CreateGridPools(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (inputGrid[i, j] == -1)
                    {
                        e.Graphics.FillRectangle(Brushes.White, grid[i, j]);
                        e.Graphics.DrawRectangle(Pens.Black, grid[i, j]);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(Brushes.Black, grid[i, j]);
                    }
                }
            }
        }

        private List<int> ShuffleList(List<int> inputList)
        {
            List<int> randomList = new List<int>();
            Random random = new Random();
           
            foreach (int xInt in inputList)
            {
                randomList.Insert(random.Next(0, randomList.Count + 1), xInt);
            }

            return randomList;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int mouseX = e.X;
            int mouseY = e.Y;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (grid[i, j].X < mouseX && grid[i, j].Y < mouseY && (grid[i, j].X + grid[i, j].Width) > mouseX && (grid[i, j].Y + grid[i, j].Height) > mouseY)
                    {
                        if (inputGrid[i, j] == -1)
                        {
                            g.FillRectangle(Brushes.Black, grid[i, j]);
                            inputGrid[i, j] = 1;
                        }
                        else
                        {
                            g.FillRectangle(Brushes.White, grid[i, j]);
                            g.DrawRectangle(Pens.Black, grid[i, j]);
                            inputGrid[i, j] = -1;
                        }
                        return;
                    }
                }
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            inputGrid = new int[size, size];
            InitializeBitGrid();
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (inputGrid[i, j] == -1)
                    {
                        g.FillRectangle(Brushes.White, grid[i, j]);
                        g.DrawRectangle(Pens.Black, grid[i, j]);
                    }
                    else
                    {
                        g.FillRectangle(Brushes.Black, grid[i, j]);
                    }
                }
            }
        }

        // ----------------------------------- BUTTONS CONTROL -----------------------------------

        private void EnableTrainButtons()
        {
            testButton.Enabled = true;
            stopButton.Enabled = false;
            addPatternButton.Enabled = true;
            showPatternButton.Enabled = true;
            deletePatternButton.Enabled = true;
        }

        private void DisableTrainButons()
        {
            testButton.Enabled = false;
            stopButton.Enabled = true;
            addPatternButton.Enabled = false;
            showPatternButton.Enabled = false;
            deletePatternButton.Enabled = false;
        }

        // ----------------------------------- TRAIN MODE -----------------------------------

        private int[] GridToArray(int[,] Grid)
        {
            int index = 0;
            int[] result = new int[gridSize];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result[index] = Grid[i, j];
                    index++;
                }
            }
            return result;
        }

        private void AddPatternButton_Click(object sender, EventArgs e)
        {
            patternCounter++;
            uniquePatternID++;
            int[] gridArray = GridToArray(inputGrid);
            patternDic.Add("Pattern" + uniquePatternID.ToString(), gridArray);
            PatternBox.Items.Add("Pattern" + uniquePatternID.ToString());
            patternCounterLabel.Text = "Pattern count: " + patternCounter;
            PatternBox.SelectedItem = "Pattern" + uniquePatternID.ToString();
            Train();
        }

        private void Train()
        {
            double[,] tmpWeights = new double[gridSize, gridSize];
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    if (i == j) continue;
                    double sum = 0.0;
                    foreach (var pattern in patternDic)
                    {
                        sum += pattern.Value[i] * pattern.Value[j];
                    }
                    tmpWeights[i, j] = 1.0 / patternCounter * sum;
                }
            }
            weights = tmpWeights;
        }

        private int[,] ArrayToGrid(int[] Array)
        {
            int arrayCounter = 0;
            int[,] result = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result[i, j] = Array[arrayCounter];
                    arrayCounter++;
                }
            }
            return result;
        }

        private void ShowPatternButton_Click(object sender, EventArgs e)
        {
            if (PatternBox.SelectedItem == null)
            {
                return;
            }

            inputGrid = ArrayToGrid(patternDic[(string)PatternBox.SelectedItem]);
            RefreshGrid();
        }

        private void DeletePatternButton_Click(object sender, EventArgs e)
        {
            if (PatternBox.SelectedItem == null)
            {
                return;
            }

            patternDic.Remove((string)PatternBox.SelectedItem);
            PatternBox.Items.Remove(PatternBox.SelectedItem);
            PatternBox.SelectedItem = null;
            PatternBox.Update();
            PatternBox.Refresh();
            patternCounter--;
            patternCounterLabel.Text = "Pattern count: " + patternCounter;

            // Reset weights and retrain
            weights = new double[gridSize, gridSize];
            Train();
        }

        // ----------------------------------- TEST MODE -----------------------------------

        private int Signum(double value)
        {
            if (value >= 0)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        Tuple<int, int> GetIndex2D(int index)
        {
            int indexI = 0, indexJ = 0;
            for (int i = 0; i < gridSize; i += size)
            {
                if (index - i < size)
                {
                    indexJ = index - i;
                    indexI = i / 10;
                    break;
                }
            }
            return new Tuple<int, int>(indexI, indexJ);
        }

        private async void TestButton_Click(object sender, EventArgs e)
        {
            DisableTrainButons();
            shuffledList = ShuffleList(shuffledList);

            Timer timer = new Timer();
            timer.Interval = 10;
            timer.Tick += delegate
            {
                timer.Stop();
            };

            int[] y = (int[])inputArray.Clone();

            while (true)
            {
                foreach (int el in shuffledList)
                {
                    double sum = 0.0;
                    for (int i = 0; i < gridSize; i++)
                    {
                        if(stopTest)
                        {
                            EnableTrainButtons();
                            stopTest = false;
                            return;
                        }
                        if (el == i) continue;
                        sum += weights[el, i] * y[i];
                    }
                    timer.Start();

                    y[el] = Signum(sum);
                    Tuple<int, int> tuple = GetIndex2D(el);

                    if (y[el] >= 0)
                    {
                        g.FillRectangle(Brushes.Black, grid[tuple.Item1, tuple.Item2]);
                    }
                    else
                    {
                        g.FillRectangle(Brushes.White, grid[tuple.Item1, tuple.Item2]);
                        g.DrawRectangle(Pens.Black, grid[tuple.Item1, tuple.Item2]);
                    }

                    await Task.Run(() => {
                        while (timer.Enabled) { }
                    });
                }
            }
        }

        private void ShuffleButton_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (random.Next(0, 2) == 1)
                    {
                        inputGrid[i, j] = 1;
                    }
                }
            }

            inputArray = GridToArray(inputGrid);
            RefreshGrid();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            stopTest = true;
        }
    }
}
