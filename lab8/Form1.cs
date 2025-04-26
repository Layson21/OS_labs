namespace lab8
{
    using System;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    using System.IO;

    public partial class Form1 : Form
    {
        TcpClient client;
        NetworkStream stream;
        Thread receiveThread;
        volatile bool isRunning = true;

        public Form1()
        {
            InitializeComponent();
            try
            {
                client = new TcpClient("127.0.0.1", 5000);
                stream = client.GetStream();
                receiveThread = new Thread(ReceiveData);
                receiveThread.IsBackground = true;
                receiveThread.Start();
            }
            catch 
            {
                MessageBox.Show("Сервер скорее всего выключен. Повторите попытку позднее!");
                Environment.Exit(0);
            }
        }

        void ReceiveData()
        {
            byte[] buffer = new byte[4096];
            while (isRunning)
            {
                try
                {
                    if (!stream.DataAvailable)
                    {
                        Thread.Sleep(100);
                        continue;
                    }

                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    bool isFile = buffer[0] == 1;
                    byte[] data = new byte[bytesRead - 1];
                    Array.Copy(buffer, 1, data, 0, bytesRead - 1);

                    if (isFile)
                    {
                        int fileNameLength = BitConverter.ToInt32(data, 0);
                        string fileName = Encoding.UTF8.GetString(data, 4, fileNameLength);

                        byte[] fileContent = new byte[data.Length - 4 - fileNameLength];
                        Array.Copy(data, 4 + fileNameLength, fileContent, 0, fileContent.Length);

                        Invoke((MethodInvoker)(() =>
                        {
                            SaveFileDialog sfd = new SaveFileDialog();
                            sfd.Title = "Сохранить полученный файл";
                            sfd.FileName = fileName;
                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                File.WriteAllBytes(sfd.FileName, fileContent);
                                listBox1.Items.Add("Получено: Файл сохранён (" + fileName + ")");
                            }
                            else
                            {
                                listBox1.Items.Add("Получено: Файл отклонён (" + fileName + ")");
                            }
                        }));
                    }
                    else
                    {
                        string message = Encoding.UTF8.GetString(data);
                        Invoke((MethodInvoker)(() => listBox1.Items.Add("Получено: " + message)));
                    }
                }
                catch
                {
                    break;
                }
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
                return;

            byte[] messageBytes = Encoding.UTF8.GetBytes(textBox1.Text);
            byte[] data = new byte[messageBytes.Length + 1];
            data[0] = 0;
            Array.Copy(messageBytes, 0, data, 1, messageBytes.Length);
            try
            {
                stream.Write(data, 0, data.Length);
            }
            catch
            {
                MessageBox.Show("Сервер скорее всего выключен. Повторите попытку позднее!");
                Environment.Exit(0);
            }

            listBox1.Items.Add("Отправлено: " + textBox1.Text);
            textBox1.Clear();
        }

        private void sendFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                byte[] fileBytes = File.ReadAllBytes(ofd.FileName);
                string fileName = Path.GetFileName(ofd.FileName);
                byte[] fileNameBytes = Encoding.UTF8.GetBytes(fileName);
                byte[] fileNameLengthBytes = BitConverter.GetBytes(fileNameBytes.Length);

                byte[] data = new byte[1 + fileNameLengthBytes.Length + fileNameBytes.Length + fileBytes.Length];
                data[0] = 1; 
                Array.Copy(fileNameLengthBytes, 0, data, 1, 4);
                Array.Copy(fileNameBytes, 0, data, 5, fileNameBytes.Length);
                Array.Copy(fileBytes, 0, data, 5 + fileNameBytes.Length, fileBytes.Length);

                try
                {
                    stream.Write(data, 0, data.Length);
                }
                catch
                {
                    MessageBox.Show("Сервер скорее всего выключен. Повторите попытку позднее!");
                    Environment.Exit(0);
                }

                listBox1.Items.Add("Отправлено: Файл (" + fileName + ")");
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            isRunning = false;
            receiveThread?.Join();
            stream?.Close();
            client?.Close();
            base.OnFormClosing(e);
        }
    }
}
