using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
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

namespace LauncherV1._0
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AllFilesLabel.Content = "";

            test();

        }
        public void test()
        {
            //string path = @"C:\LMAO";
            //var y = Directory.GetDirectories(Directory.GetParent(path).ToString());

            var dir = new DirectoryInfo(@"C:\Users\vanca\source\repos");
            FileInfo[] files = dir.GetFiles();
            //Debug.WriteLine();

            DirectoryInfo[] dirs = dir.GetDirectories();
            //!String.IsNullOrEmpty(propenetrovano)
            //DirectoryInfo[] naProjeti = dirs;
            ObservableCollection<String> filesCol = new ObservableCollection<String>();
            foreach (var item in dir.GetFiles("*.sln", SearchOption.AllDirectories))
            {
                var dir2 = new DirectoryInfo(@item.DirectoryName);
                //DirectoryInfo[] dirs2 = dir2.GetDirectories();
                foreach (var item2 in dir2.GetFiles("*.exe", SearchOption.AllDirectories))
                {
                    if (System.IO.Path.GetFileNameWithoutExtension(item.Name) == System.IO.Path.GetFileNameWithoutExtension(item2.Name))
                    {
                        //AllFilesLabel.Content += item2.FullName + "\n";
                        //AllFilesLabel.Content += item2.Directory;
                        string smtn = Directory.GetParent(item2.DirectoryName).ToString();
                        //string smtn2 = Directory.GetParent(smtn).ToString();
                        string fldr = smtn.Substring(smtn.Length - 3);
                        //AllFilesLabel.Content += smtn+"\n";
                        if (!(fldr == "obj"))
                        {
                            filesCol.Add(item2.FullName);
                            //AllFilesLabel.Content += (item2.FullName)+"\n";
                        }
                    }
                }
                //AllFilesLabel.Content += item.Name + "\n";

            }
            VypisVsech.ItemsSource = filesCol;



            var carMake = files
            .Where(item => item.Extension == ".exe")
            .Select(item => item);
            foreach (var item in carMake)
            {
                //AllFilesLabel.Content += System.IO.Path.GetFileNameWithoutExtension(item.FullName)+"\n";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AllFilesLabel.Content = VypisVsech.SelectedItems[0];
            Process.Start(VypisVsech.SelectedItems[0].ToString());
        }
    }
}
