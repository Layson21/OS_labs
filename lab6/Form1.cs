using System.Windows.Forms;
using static lab6.Manager;

namespace lab6
{
    public partial class Form1 : Form
    {
        int rowIndex = -1;

        public Form1()
        {
            InitializeComponent();
            windowsTable.CellMouseClick += windowsTable_RightClick;
            windowsTable.CellClick += windowsTable_CellClick;
        }

        private void getWndBtn_Click(object sender, EventArgs e)
        {
            
            rowIndex = -1;
            showWindows();
        }

        private void showWindows()
        {
            windowsTable.Rows.Clear();
            try
            {
                Manager.GetWindows();
                foreach (var win in Manager.windows)
                {
                    windowsTable.Rows.Add(win.Title, win.ProcessName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                showWindows();
            }

        }

        private void windowsTable_RightClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    Window win = Manager.windows[e.RowIndex];
                    MessageBox.Show($"Заголовок: {win.Title}\nКласс окна: {win.ClassName}\n" +
                        $"PID: {win.ProcessId}\nИмя процесса: {win.ProcessName}\nВидимость: {win.IsVisible}\n" +
                        $"Координаты: ({win.Coords[0]}, {win.Coords[1]})\nРазмер: ({win.Size[0]}, {win.Size[1]})");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                showWindows();
            }
        }

        private void windowsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
        }

        private void changeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (rowIndex != -1)
                {
                    Window selectedWindow = Manager.windows[rowIndex];

                    if (!Manager.IsWindow(selectedWindow.hwnd)) {
                        throw new Exception("Окно было закрыто. Обновление данных.");
                    }

                    Manager.GetWindowRect(selectedWindow.hwnd, out RECT rect);
                    string newTitle = titleInput.Text;

                    if (!string.IsNullOrWhiteSpace(newTitle))
                    {
                        Manager.SetWindowText(selectedWindow.hwnd, newTitle);
                        if (Manager.GetTitle(selectedWindow.hwnd) == newTitle)
                            windowsTable.Rows[rowIndex].Cells[0].Value = newTitle;
                        else
                            MessageBox.Show("Не удалось изменить имя окна.");
                    }

                    Manager.MoveWindow(
                        selectedWindow.hwnd,
                        Int32.TryParse(xInput.Text, out int x) ? x : rect.Left,
                        Int32.TryParse(yInput.Text, out int y) ? y : rect.Top,
                        Int32.TryParse(widthInput.Text, out int width) ? width : rect.Right - rect.Left,
                        Int32.TryParse(heightInput.Text, out int height) ? height : rect.Bottom - rect.Top,
                        true
                    );
                }
                else
                    MessageBox.Show("Выберите ячейку.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                showWindows();
            }
        }
    }
}