using System.Diagnostics;

namespace lab3
{
    public partial class ExplorerApp : Form
    {
        private string currentPath = "MyComputer";
        public ExplorerApp()
        {
            InitializeComponent();
        }

        private void ListViewFiles_ItemActivate(object sender, EventArgs e)
        {
            if (ListViewFiles.SelectedItems.Count > 0)
            {
                string selectedPath = ListViewFiles.SelectedItems[0].Tag.ToString();

                if (Directory.Exists(selectedPath))
                {
                    FileManager.LoadFiles(selectedPath, ref currentPath, ListViewFiles, PathTextBox);
                }
                else if (File.Exists(selectedPath))
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = selectedPath,
                            UseShellExecute = true
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Не удалось открыть файл: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Открытие элемента '" + selectedPath + "' невозможно.");
                }
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (Directory.GetParent(currentPath) != null && currentPath != "MyComputer")
            {
                FileManager.LoadFiles(Directory.GetParent(currentPath).FullName, ref currentPath, ListViewFiles, PathTextBox);
            }
            else
            {
                FileManager.LoadFiles("MyComputer", ref currentPath, ListViewFiles, PathTextBox);
            }
        }

        private void ExplorerApp_Load(object sender, EventArgs e)
        {
            FileManager.LoadFiles(currentPath, ref currentPath, ListViewFiles, PathTextBox);
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            if (currentPath != "MyComputer")
            {
                string name = FFTextBox.Text.Trim();

                if (name.Length == 0)
                {
                    MessageBox.Show("Введите имя.");
                    return;
                }

                if (name.Contains(Path.DirectorySeparatorChar) || name.Contains(Path.AltDirectorySeparatorChar))
                {
                    MessageBox.Show("Имя не может содержать символы пути.");
                    return;
                }

                string fullPath = Path.Combine(currentPath, name);

                if (File.Exists(fullPath))
                {
                    MessageBox.Show("Файл с таким именем уже существует.");
                }
                else if (Directory.Exists(fullPath))
                {
                    MessageBox.Show("Папка с таким именем уже существует.");
                }
                else
                {
                    if (name.Contains("."))
                    {
                        FileManager.CreateFile(fullPath);
                    }
                    else
                    {
                        FileManager.CreateDirectory(fullPath);
                    }
                }
            }
            else
            {
                MessageBox.Show("Данное действие невозможно.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            HideInputControls();
            FileManager.LoadFiles(currentPath, ref currentPath, ListViewFiles, PathTextBox);
        }

        private void HideMenu()
        {
            CreateFileButton.Visible = false;
            CreateFolderButton.Visible = false;
            DeleteButton.Visible = false;
            CopyButton.Visible = false;
            InsertButton.Visible = false;
            MoveButton.Visible = false;
            ChangeNameButton.Visible = false;
        }

        private void ShowMenu()
        {
            CreateFileButton.Visible = true;
            CreateFolderButton.Visible = true;
            DeleteButton.Visible = true;
            CopyButton.Visible = true;
            InsertButton.Visible = true;
            MoveButton.Visible = true;
            ChangeNameButton.Visible = true;
        }

        private void HideInputControls()
        {
            FFTextBox.Visible = false;
            CancelButton.Visible = false;
            EnterButton.Visible = false;
            ShowMenu();
        }

        private void ShowInputControls(string type)
        {
            FFTextBox.Text = "";
            FFTextBox.Visible = true;
            CancelButton.Visible = true;
            EnterButton.Visible = true;
            HideMenu();

            if (type == "file")
            {
                FFTextBox.Text = "newfile.txt";
            }
            else
            {
                FFTextBox.Text = "NewFolder";
            }
        }

        private void ShowMoveContols()
        {
            HideMenu();
            EnterMoveButton.Visible = true;
            MoveLabel.Visible = true;
            CancelMove.Visible = true;
        }

        private void HideMoveContols()
        {
            ShowMenu();
            EnterMoveButton.Visible = false;
            MoveLabel.Visible = false;
            CancelMove.Visible = false;
        }

        private void ShowChangeControls()
        {
            HideMenu();
            EnterChangeButton.Visible = true;
            FFTextBox.Text = "";
            FFTextBox.Visible = true;
            CancelButton.Visible = true;
        }

        private void HideChangeControls()
        {
            ShowMenu();
            EnterChangeButton.Visible = false;
            FFTextBox.Text = "";
            FFTextBox.Visible = false;
            CancelButton.Visible = false;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            HideInputControls();
            HideMoveContols();
            HideChangeControls();
        }

        private void CreateFileButton_Click(object sender, EventArgs e)
        {
            ShowInputControls("file");
        }

        private void CreateFolderButton_Click(object sender, EventArgs e)
        {
            ShowInputControls("folder");
        }

        private void ListViewFiles_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            int totalWidth = 0;
            foreach (ColumnHeader column in ListViewFiles.Columns)
            {
                totalWidth += column.Width;
            }

            if (e.ColumnIndex == ListViewFiles.Columns.Count - 1)
            {
                e.Cancel = true;
                e.NewWidth = ListViewFiles.Columns[e.ColumnIndex].Width;
            }
            else if (totalWidth - ListViewFiles.Columns[e.ColumnIndex].Width + e.NewWidth > ListViewFiles.Width)
            {
                e.Cancel = true;
                e.NewWidth = ListViewFiles.Columns[e.ColumnIndex].Width;
            }
            else if (e.NewWidth < 100)
            {
                e.Cancel = true;
                e.NewWidth = 100;
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (ListViewFiles.SelectedItems.Count > 0)
            {
                string selectedPath = ListViewFiles.SelectedItems[0].Tag.ToString();

                if (Directory.Exists(selectedPath))
                {
                    FileManager.DeleteDirectory(selectedPath);
                    FileManager.LoadFiles(currentPath, ref currentPath, ListViewFiles, PathTextBox);
                }
                else if (File.Exists(selectedPath))
                {
                    FileManager.DeleteFile(selectedPath);
                    FileManager.LoadFiles(currentPath, ref currentPath, ListViewFiles, PathTextBox);
                }
                else
                {
                    MessageBox.Show("Не удалось найти файл или папку.");
                }
            }
            else
            {
                MessageBox.Show("Выберите файл или папку для удаления.");
            }
        }


        private void CopyButton_Click(object sender, EventArgs e)
        {
            if (currentPath != "MyComputer")
            {
                FileManager.Copy(ListViewFiles);
            }
            else
            {
                MessageBox.Show("Нельзя совершить данное действие.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            FileManager.Paste(currentPath);
            FileManager.LoadFiles(currentPath, ref currentPath, ListViewFiles, PathTextBox);
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            FileManager.TryNavigateToPath(PathTextBox, ref currentPath, ListViewFiles);
        }

        private void PathTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FileManager.TryNavigateToPath(PathTextBox, ref currentPath, ListViewFiles);
                e.SuppressKeyPress = true;
            }
        }

        private void MoveButton_Click(object sender, EventArgs e)
        {
            if (currentPath != "MyComputer")
            {
                int check = FileManager.Copy(ListViewFiles);
                if (check == 1)
                {
                    ShowMoveContols();
                }
            }
            else
            {
                MessageBox.Show("Нельзя совершить данное действие.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnterMoveButton_Click(object sender, EventArgs e)
        {
            FileManager.MoveFiles(currentPath);

            FileManager.LoadFiles(currentPath, ref currentPath, ListViewFiles, PathTextBox);
            HideMoveContols();
        }

        private void ChangeNameButton_Click(object sender, EventArgs e)
        {
            if (ListViewFiles.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите файл или папку для переименования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ListViewItem selectedItem = ListViewFiles.SelectedItems[0];
            FFTextBox.Text = selectedItem.Text;
            FFTextBox.Tag = selectedItem.Tag;
            ShowChangeControls();
        }

        private void EnterChangeButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FFTextBox.Text))
            {
                MessageBox.Show("Имя не может быть пустым!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string oldPath = FFTextBox.Tag.ToString();
            string newPath = Path.Combine(Path.GetDirectoryName(oldPath), FFTextBox.Text);
            FileManager.RenameItem(oldPath, FFTextBox.Text, ListViewFiles, PathTextBox);
            HideChangeControls();
        }

        private void ListViewFiles_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (ListViewFiles.FocusedItem != null && ListViewFiles.FocusedItem.Bounds.Contains(e.Location))
                {
                    string filePath = ListViewFiles.FocusedItem.Tag.ToString();
                    FileManager.ShowFileProperties(filePath);
                }
            }
        }
    }
}