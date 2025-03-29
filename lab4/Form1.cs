namespace lab4
{
    public partial class Form1 : Form
    {
        private List<Thread> childThreads = new List<Thread>();
        private volatile bool isRunning = false;
        private volatile bool isPaused = false;
        private double[] results = new double[3];
        private double input = 1;

        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
            this.priorityCombo1.SelectedIndex = 0;
            this.priorityCombo2.SelectedIndex = 0;
            this.priorityCombo3.SelectedIndex = 0;
        }

        private void ChildThread1Method()
        {
            Random rand = new Random();
            while (isRunning)
            {
                try
                {
                    if (!isPaused)
                    {
                        double r1, r2;
                        r1 = results[1];
                        r2 = results[2];

                        double newResult = Math.Sin(rand.NextDouble() + input * (Math.Pow(r2, 2) + Math.Sin(r1)));

                        results[0] = newResult;

                        this.Invoke((MethodInvoker)delegate
                        {
                            resultLabel1.Text = $"Поток 1: {results[0]:F6}";
                        });
                    }
                    Thread.Sleep(1);
                }
                catch (ThreadInterruptedException)
                {
                    break;
                }
            }
        }

        private void ChildThread2Method()
        {
            Random rand = new Random();
            while (isRunning)
            {
                try
                {
                    if (!isPaused)
                    {
                        double r0, r2;
                        r0 = results[0];
                        r2 = results[2];

                        double newResult = Math.Sin(rand.NextDouble() + input * (Math.Pow(r2, 2) + Math.Sin(r0)));

                        results[1] = newResult;

                        this.Invoke((MethodInvoker)delegate
                        {
                            resultLabel2.Text = $"Поток 2: {results[1]:F6}";
                        });
                    }
                    Thread.Sleep(1);
                }
                catch (ThreadInterruptedException)
                {
                    break;
                }
            }
        }

        private void ChildThread3Method()
        {
            Random rand = new Random();
            while (isRunning)
            {
                try
                {
                    if (!isPaused)
                    {
                        double r0, r1;
                        r0 = results[0];
                        r1 = results[1];

                        double newResult = Math.Sin(rand.NextDouble() + input * (Math.Pow(r1, 2) + Math.Sin(r0)));

                        results[2] = newResult;

                        this.Invoke((MethodInvoker)delegate
                        {
                            resultLabel3.Text = $"Поток 3: {results[2]:F6}";
                        });
                    }
                    Thread.Sleep(1);
                }
                catch (ThreadInterruptedException)
                {
                    break;
                }
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                isRunning = true;
                isPaused = false;
                childThreads.Clear();
                results[0] = 1.0;
                results[1] = 1.0;
                results[2] = 1.0;

                childThreads.Add(new Thread(ChildThread1Method));
                childThreads.Add(new Thread(ChildThread2Method));
                childThreads.Add(new Thread(ChildThread3Method));

                childThreads[0].Priority = (ThreadPriority)priorityCombo1.SelectedItem;
                childThreads[1].Priority = (ThreadPriority)priorityCombo2.SelectedItem;
                childThreads[2].Priority = (ThreadPriority)priorityCombo3.SelectedItem;

                Parallel.ForEach(childThreads, thread => thread.Start());

                startButton.Enabled = false;
            }
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                isPaused = !isPaused;
                pauseButton.Text = isPaused ? "Возобновить" : "Пауза";
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                isRunning = false;
                isPaused = false;
                foreach (var thread in childThreads)
                {
                    thread?.Interrupt();
                    thread?.Join();
                }
                childThreads.Clear();
                startButton.Enabled = true;
                pauseButton.Text = "Пауза";
                resultLabel1.Text = "Поток 1: ";
                resultLabel2.Text = "Поток 2: ";
                resultLabel3.Text = "Поток 3: ";
            }
        }

        private void PriorityCombo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isRunning && childThreads.Count > 0 && childThreads[0].IsAlive)
            {
                childThreads[0].Priority = (ThreadPriority)priorityCombo1.SelectedItem;
            }
        }

        private void PriorityCombo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isRunning && childThreads.Count > 0 && childThreads[1].IsAlive)
            {
                childThreads[1].Priority = (ThreadPriority)priorityCombo2.SelectedItem;
            }
        }

        private void PriorityCombo3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isRunning && childThreads.Count > 0 && childThreads[2].IsAlive)
            {
                childThreads[2].Priority = (ThreadPriority)priorityCombo3.SelectedItem;
            }
        }

        private void inputTextBox_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(inputTextBox.Text, out double newInput))
            {
                input = newInput;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isRunning)
            {
                isRunning = false;
                isPaused = false;
                foreach (var thread in childThreads)
                {
                    thread?.Interrupt();
                }
            }
        }
    }
}