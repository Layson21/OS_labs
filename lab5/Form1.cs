using System.Reflection;

namespace lab5
{
    public partial class Lab5Form : Form
    {
        public Lab5Form()
        {
            InitializeComponent();
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            string dllPath = @"C:\Program Files\BrowserLibrary\bin\Debug\net7.0\BrowserLibrary.dll";
            Assembly assembly = Assembly.LoadFrom(dllPath);
            Type type = assembly.GetType("BrowserLibrary.BrowserOpener");
            MethodInfo method = type.GetMethod("Search", BindingFlags.Public | BindingFlags.Static);
            method.Invoke(null, new object[] { UrlTextBox.Text });
        }
    }
}