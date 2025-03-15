namespace kr1
{
    public partial class Form1 : Form
    {
        private const int WM_DEVICECHANGE = 0x0219;
        private const int DBT_DEVICEARRIVAL = 0x8000;
        public Form1()
        {
            InitializeComponent();
        }
        bool dialogOpened = false;

        private void SelectDirectoryButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectDirectoryDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                string selectedPath = SelectDirectoryDialog.SelectedPath;
                if (Directory.GetFiles(selectedPath).Length > 0 && Directory.GetDirectories(selectedPath).Length > 0)
                {
                    Directory.Delete(selectedPath, true);
                    MessageBox.Show("Выбранная папка была успешно удалена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("В данной директории отстутствуют файлы или папки.", "Информация!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_DEVICECHANGE)
            {
                if (m.WParam == DBT_DEVICEARRIVAL)
                {
                    DialogResult dialogResult = MessageBox.Show("Обнаружено новое USB-устройство!", "Информация!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}