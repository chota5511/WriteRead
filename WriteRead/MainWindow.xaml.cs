using System;
using System.Collections.Generic;
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

namespace WriteRead
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Student student;

        public MainWindow()
        {
            InitializeComponent();
        }

        //Click Event
        private void BtBrowse_Click(object sender, RoutedEventArgs e)
        {
            string tmpPath = Functions.getPath();
            if(tmpPath != "" && tmpPath != null)
            {
                tbPath.Text = tmpPath;
            }
        }

        private void BtRead_Click(object sender, RoutedEventArgs e)
        {
            if(tbPath.Text != "" && tbPath.Text != null)
            {
                string tmp = Functions.ReadFile(tbPath.Text);
                if (tmp != "" && tmp != null)
                {
                    try
                    {
                        student = new Student(tmp);
                        tbID.Text = student.ID.ToString();
                        tbName.Text = student.Name;
                        tbDoB.Text = student.DateOfBirth;
                        tbEnglish.Text = student.English.ToString();
                        tbMath.Text = student.Math.ToString();
                        tbAvg.Text = student.Average().ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error!!!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi đọc file!!!", "Error!!!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn dường dẫn cho tệp cần đọc!!!", "Error!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtWrite_Click(object sender, RoutedEventArgs e)
        {
            if (tbID.Text != ""
                && tbName.Text != ""
                && tbDoB.Text != ""
                && tbMath.Text != ""
                && tbEnglish.Text != ""
                && tbID.Text != null
                && tbName.Text != null
                && tbDoB.Text != null
                && tbMath.Text != null
                && tbEnglish.Text != null)
            {
                try
                {
                    student = new Student(int.Parse(tbID.Text), tbName.Text, tbDoB.Text, float.Parse(tbEnglish.Text), float.Parse(tbMath.Text));
                    if (tbPath.Text != "" && tbPath.Text != null)
                    {
                        if (Functions.WriteFile(tbPath.Text, student.toString()) == true)
                        {
                            tbAvg.Text = student.Average().ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Chưa chọn dường dẫn cho tệp cần lưu!!!", "Error!!!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!!!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Chưa nhập đủ thông tin", "Error!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
