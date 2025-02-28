using System.Drawing.Text;
using System.IO;
namespace lab2


{
    public partial class Form1 : Form
    {
        private DriveInfo[] drives;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            drives = DriveInfo.GetDrives();
            GetTree(sender, e, drives);
            treeView1.BeforeExpand += AddNode;
        }

        private void GetDisks(object s, EventArgs e, DriveInfo[] drives)
        {
            listView1.Items.Clear();

            using (StreamWriter writer = new StreamWriter("disk_log.txt", true))
            {
                writer.WriteLine($"[{DateTime.Now}] - Start logging disks info:");
            }

            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady)
                {

                    string driveTotalSize = $"{(int)(drive.TotalSize / (Math.Pow(1024, 3)))} ГБ / {(int)(drive.TotalSize / (Math.Pow(1024, 2)))} МБ";
                    string driveTotalFreeSpace = $"{(int)(drive.TotalFreeSpace / (Math.Pow(1024, 3)))} ГБ / {(int)(drive.TotalFreeSpace / (Math.Pow(1024, 2)))} МБ";
                    string driveTotalOccupiedSpace = $"{(int)((drive.TotalSize - drive.TotalFreeSpace) / (Math.Pow(1024, 3)))} ГБ / {(int)((drive.TotalSize - drive.TotalFreeSpace) / (Math.Pow(1024, 2)))} МБ";

                    ListViewItem item = new ListViewItem(drive.Name);
                    item.SubItems.Add(drive.DriveFormat);
                    item.SubItems.Add(driveTotalSize);
                    item.SubItems.Add(driveTotalFreeSpace);
                    item.SubItems.Add(driveTotalOccupiedSpace);

                    listView1.Items.Add(item);

                    using (StreamWriter writer = new StreamWriter("disk_log.txt", true))
                    {
                        writer.WriteLine($"    Disk {drive.Name}\n" +
                                         $"        Format: {drive.DriveFormat}\n" +
                                         $"        Total Size: {driveTotalSize}\n" +
                                         $"        Free Space: {driveTotalFreeSpace}\n" +
                                         $"        Used Space: {driveTotalOccupiedSpace}");
                    }
                }
            }
            using (StreamWriter writer = new StreamWriter("disk_log.txt", true))
            {
                writer.WriteLine($"[{DateTime.Now}] - End logging disks info.\n\n\n");
            }

        }

        private void GetTree(object s, EventArgs e, DriveInfo[] drives)
        {
            treeView1.Nodes.Clear();
            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady)
                {
                    TreeNode rootNode = new TreeNode(drive.Name)
                    {
                        Tag = drive.Name,
                        ImageKey = "drive",
                        SelectedImageKey = "drive"
                    };
                    rootNode.Nodes.Add("Загрузка...");
                    treeView1.Nodes.Add(rootNode);
                }
            }
        }

        private void AddNode(object sender, TreeViewCancelEventArgs e)
        {

            TreeNode currentNode = e.Node;
            currentNode.Nodes.Clear();
            string path = currentNode.Tag.ToString();

            try
            {
                string[] dirs = Directory.GetDirectories(path);

                foreach (string dir in dirs)
                {
                    string dirName = Path.GetFileName(dir);

                    TreeNode dirNode = new TreeNode(dirName)
                    {
                        Tag = dir,
                        ImageKey = "folder",
                        SelectedImageKey = "folder"
                    };

                    if (Directory.GetDirectories(dir).Length > 0)
                    {
                        dirNode.Nodes.Add("Загрузка...");
                    }

                    currentNode.Nodes.Add(dirNode);

                }
                string[] files = Directory.GetFiles(path);
                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);

                    TreeNode fileNode = new TreeNode(fileName)
                    {
                        Tag = file,
                        ImageKey = "file",
                        SelectedImageKey = "file"
                    };


                    currentNode.Nodes.Add(fileNode);

                }
            }
            catch (UnauthorizedAccessException)
            {
                currentNode.Nodes.Add("Отказано в доступе");
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Указанная директория не найдена!", "DirectoryNotFound", MessageBoxButtons.OK, MessageBoxIcon.Error);
                drives = DriveInfo.GetDrives();
                GetTree(sender, e, drives);

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.Columns.Add("Диск", 100);
            listView1.Columns.Add("Тип", 100);
            listView1.Columns.Add("Общий объем (ГБ/МБ)", 150);
            listView1.Columns.Add("Свободно (ГБ/МБ)", 150);
            listView1.Columns.Add("Занято (ГБ/МБ)", 150);

            listView1.ColumnWidthChanging += (s, ev) =>
            {
                ev.NewWidth = listView1.Columns[ev.ColumnIndex].Width;
                ev.Cancel = true;
            };

            drives = DriveInfo.GetDrives();
            GetDisks(sender, e, drives);
            GetTree(sender, e, drives);
            treeView1.BeforeExpand += AddNode;


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            drives = DriveInfo.GetDrives();
            GetDisks(sender, e, drives);
        }
    }
}