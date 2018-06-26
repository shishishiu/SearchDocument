using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SearchDocument
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TextBoxFileName.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            String filename = TextBoxFileName.Text;
            String path = Properties.Settings.Default.SearchPath + filename + ".PDF";

            if (filename.Equals(""))
            {
                MessageBox.Show("Ingresa nombre de archivo");
                TextBoxFileName.Focus();
                return;
            }
            if (!System.IO.File.Exists(path))
            {
                MessageBox.Show("No existe el archivo " + path);
                return;
            }



            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = Properties.Settings.Default.BatFilePath;
            processStartInfo.CreateNoWindow = true;
            processStartInfo.UseShellExecute = false;
            processStartInfo.Arguments = "\"" + path + "\"";

            Process.Start(processStartInfo);

            //WindowShowDocument winShowDoc = new WindowShowDocument();


            //winShowDoc.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //winShowDoc.Height = System.Windows.SystemParameters.WorkArea.Height - 50;
            //winShowDoc.Width = System.Windows.SystemParameters.WorkArea.Width - 50;

            //winShowDoc.WebBrowserShowDocument.Navigate(path);
            //winShowDoc.Show();
        }
    }
}
