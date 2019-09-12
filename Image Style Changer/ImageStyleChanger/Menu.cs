using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageStyleChanger
{
    public partial class Menu : Form
    {
        private string pythonPath;
        private string pythonConfigPath = "..\\..\\..\\python.cfg";
        private string filePath = "..\\..\\..\\KerasTensorflowImage\\KerasTensorflowImage\\KerasTensorflowImage.py";

        private List<string> styleListPaths;
        private string selectedStyle;
        double styleWeight = 0.01;
        int iterationsCount = 100;
        bool loadImageStatus = false;

        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            // ListView Properties
            styleListView.View = View.Details;

            // Construct Columns
            styleListView.Columns.Add("Style List", 150);
            styleListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);

            createListView();

            styleWeightTextBox.Text = styleWeight.ToString();
            iterationsCountTextBox.Text = iterationsCount.ToString();

            // Load Python Path
            getPythonPathConfig();

            disableReworkedImageButtons();

            statusLabel.Text = "Load image";
        }

        private void createListView()
        {
            // Prepare styleListPaths
            styleListPaths = new List<string>();

            // ImageList to hold images
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(200, 150);

            // Load images from file
            string[] paths = { };
            paths = Directory.GetFiles("../../../ImageStyles");

            try
            {
                int index = 0;
                foreach (string path in paths)
                {
                    imageList.Images.Add(Image.FromFile(path));
                    styleListView.Items.Add(Path.GetFileNameWithoutExtension(path), index);
                    styleListPaths.Add(path);
                    index++;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            // Bind images to ListView
            styleListView.SmallImageList = imageList;
        }

        private void createConfig()
        {
            string configPath = "../../../config.cfg";

            TextWriter tw = new StreamWriter(configPath, false);
            int actualIndex = styleListView.SelectedIndices[0];

            tw.WriteLine(styleWeight);
            tw.WriteLine(iterationsCount);
            tw.WriteLine(styleListPaths[actualIndex]);
            tw.Close();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (loadImageStatus == false)
            {
                MessageBox.Show("Load image first!", "Error");
                return;
            }
            if (selectedStyle == null)
            {
                MessageBox.Show("Select image style first!", "Error");
                return;
            }
            if (styleWeight == 0)
            {
                MessageBox.Show("Bad style weight value!", "Error");
                return;
            }
            if (iterationsCount == 0)
            {
                MessageBox.Show("Bad iteration count value!", "Error");
                return;
            }

            statusLabel.Text = "Changing image style has started!";

            emptyWorkingDirectory();
            disableReworkedImageButtons();
            reworkedImagePictureBox.Image = null;
            prepareProgressBar();

            // Update Garbage Collection
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();

            Thread bgDoneWorker = new Thread(checkDoneStatus);
            bgDoneWorker.Start();

            try
            {
                createConfig();
                run_cmd();
            }
            catch (Exception ex)
            {
                statusLabel.Text = "Error! Unable to start python script!";
                Console.WriteLine(ex.Message.ToString());
            }
        }

        private void styleListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (styleListView.SelectedIndices.Count <= 0)
            {
                return;
            }
            int intselectedindex = styleListView.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                selectedStyle = styleListView.Items[intselectedindex].Text;
                styleLabel.Text = styleListView.Items[intselectedindex].Text;
                //MessageBox.Show(selectedStyle); 
            }
        }

        private void run_cmd()
        {
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo(pythonPath, filePath)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            p.Start();

            //string output = p.StandardOutput.ReadToEnd();
            //p.WaitForExit();

            //Console.WriteLine(output);
            //Console.ReadLine();
        }

        private void addStyleButton_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                openFileDialog.Filter = "Jpg files (*.jpg)|*.jpg|Png files (*.png)|*.png|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the path of specified file
                    filePath = openFileDialog.FileName;

                    // Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }

            if (filePath != string.Empty)
            {
                MessageBox.Show("File content at path: " + filePath, "Style added!", MessageBoxButtons.OK);
                System.IO.File.Copy(filePath, "../../../ImageStyles/" + Path.GetFileName(filePath));

                // Clear ListView items
                styleListView.Items.Clear();
                createListView();
            }
        }

        private void openStyleFolderButton_Click(object sender, EventArgs e)
        {
                System.Diagnostics.Process.Start("explorer.exe", "..\\..\\..\\ImageStyles");
        }

        private void deleteStyleButton_Click(object sender, EventArgs e)
        {
            if (selectedStyle == null)
            {
                MessageBox.Show("Select style first!", "Error");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete " + selectedStyle + " style?", "Delete style", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        int actualIndex = styleListView.SelectedIndices[0];

                        // Update Garbage Collection and Delete File
                        System.GC.Collect();
                        System.GC.WaitForPendingFinalizers();
                        File.Delete(styleListPaths[actualIndex]);

                        // Update ListView items
                        styleListView.Items.Clear();
                        createListView();
                    }
                    catch (Exception deleteError)
                    {
                        MessageBox.Show(deleteError.Message);
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
        }

        private void loadImageButton_Click(object sender, EventArgs e)
        {
            string fileContent = string.Empty;
            string filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                openFileDialog.Filter = "Jpg files (*.jpg)|*.jpg|Png files (*.png)|*.png|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the path of specified file
                    filePath = openFileDialog.FileName;

                    // Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }

                    statusLabel.Text = "Select Style Weight, Iteration Count and click Start";
                }
            }

            if (filePath != string.Empty)
            {
                Image loadedImageBitmap = System.Drawing.Image.FromFile(filePath);
                loadedImagePictureBox.Image = loadedImageBitmap;
                System.IO.File.Copy(filePath, "../../../Image/Image.png", true);
                loadImageStatus = true;
            }
        }
        
        private void styleWeightTextBox_KeyPress(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(styleWeightTextBox.Text, "[^0-9,.]"))
            {
                MessageBox.Show("Please enter only the number!", "Error");
                styleWeightTextBox.Text = styleWeightTextBox.Text.Remove(styleWeightTextBox.Text.Length - 1);
            }

            if (styleWeightTextBox.Text != "")
            {
                styleWeight = Convert.ToDouble(styleWeightTextBox.Text);
            }
            else
            {
                styleWeight = 0;
            }
        }

        private void iterationsCountTextBox_KeyPress(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(iterationsCountTextBox.Text, "[^0-9,.]"))
            {
                MessageBox.Show("Please enter only the number!", "Error");
                iterationsCountTextBox.Text = iterationsCountTextBox.Text.Remove(iterationsCountTextBox.Text.Length - 1);
            }

            if (iterationsCountTextBox.Text != "")
            {
                iterationsCount = Int32.Parse(iterationsCountTextBox.Text);
            }
            else
            {
                iterationsCount = 0;
            }
        }

        private void getPythonPathConfig()
        {
            try
            {
                using (StreamReader sr = new StreamReader(pythonConfigPath))
                {
                    // Read the stream to a string, and write the string to the console.
                    String line = sr.ReadToEnd();
                    pythonPath = line;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void checkDoneStatus()
        {
            int tmpNumber = getFilesCount();
            int tmpProgressNumber = getProgressCount();

            while (true)
            {
                if (tmpProgressNumber != getProgressCount())
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        incrementProgressBar();
                        tmpProgressNumber = getProgressCount();
                    });
                }

                if (tmpNumber != getFilesCount())
                {
                    string[] paths = Directory.GetFiles("results");
                    List<string> files = new List<string>();

                    try
                    {
                        int index = 0;
                        foreach (string path in paths)
                        {
                            files.Add(path);
                            index++;
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }

                    this.Invoke((MethodInvoker)delegate ()
                    {
                        statusLabel.Text = "The image style has changed!";
                        enableReworkedImageButtons();
                    });

                    // Update Garbage Collection
                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();

                    // Create copy of reworked image
                    int immageNumber = getReworkedFilesCount();
                    string reworkedPath = "..\\..\\..\\Reworked Image\\" + immageNumber + ".png";
                    System.IO.File.Copy(files[paths.Length - 1], reworkedPath, true);

                    reworkedImagePictureBox.Load(reworkedPath);

                    return;
                }
            }
        }

        private int getFilesCount()
        {
            string workingDirectoryPath = "results";
            int count = Directory.GetFiles(workingDirectoryPath, "*", SearchOption.TopDirectoryOnly).Length;
            return count;
        }

        private int getReworkedFilesCount()
        {
            string workingDirectoryPath = "..\\..\\..\\Reworked Image";
            int count = Directory.GetFiles(workingDirectoryPath, "*", SearchOption.TopDirectoryOnly).Length;
            return count;
        }

        private int getProgressCount()
        {
            string workingDirectoryPath = "progress";
            int count = Directory.GetFiles(workingDirectoryPath, "*", SearchOption.TopDirectoryOnly).Length;
            return count;
        }

        private void emptyWorkingDirectory()
        {
            // Update Garbage Collection
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();

            System.IO.DirectoryInfo workingDirectoryPath = new DirectoryInfo("results");
            foreach (System.IO.FileInfo file in workingDirectoryPath.GetFiles()) file.Delete();
            foreach (System.IO.DirectoryInfo subDirectory in workingDirectoryPath.GetDirectories()) subDirectory.Delete(true);

            workingDirectoryPath = new DirectoryInfo("progress");
            foreach (System.IO.FileInfo file in workingDirectoryPath.GetFiles()) file.Delete();
            foreach (System.IO.DirectoryInfo subDirectory in workingDirectoryPath.GetDirectories()) subDirectory.Delete(true);
        }

        private void openReworkedImageFolderButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "..\\Debug\\results");
        }

        private void saveReworkedImageButton_Click(object sender, EventArgs e)
        {
            string[] paths = Directory.GetFiles("results");
            List<string> files = new List<string>();

            try
            {
                int index = 0;
                foreach (string path in paths)
                {
                    files.Add(path);
                    index++;
                }
            }
            catch (Exception openError)
            {
                MessageBox.Show(openError.Message);
            }

            string sourceFile = paths[0];
            if (sourceFile == null)
            {
                MessageBox.Show("Save image error!");
                return;
            }

            // Save file dialog

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.FileName = "Reworked Image.jpg";
            saveFileDialog.Filter = "Jpg files (*.jpg)|*.jpg|Png files (*.png)|*.png|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string destFile = saveFileDialog.FileName;
                System.IO.File.Copy(sourceFile, destFile, true);
            }
        }

        private void disableReworkedImageButtons()
        {
            openReworkedImageFolderButton.Enabled = false;
            saveReworkedImageButton.Enabled = false;
        }

        private void enableReworkedImageButtons()
        {
            openReworkedImageFolderButton.Enabled = true;
            saveReworkedImageButton.Enabled = true;
        }

        private void prepareProgressBar()
        {
            progressBar.Maximum = Int32.Parse(iterationsCountTextBox.Text);
            progressBar.Step = 1;
            progressBar.Value = 0;
            progressLabel.Text = "Iteration progress: " + progressBar.Value + " / " + progressBar.Maximum;
        }

        private void incrementProgressBar()
        {
            progressBar.Increment(1);
            progressLabel.Text = "Iteration progress: " + progressBar.Value + " / " + progressBar.Maximum;
        }
    }
}
