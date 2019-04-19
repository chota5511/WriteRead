using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WriteRead
{
    static class Functions
    {
        //Get file path Function
        public static string getPath()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.Title = "Chọn tệp để save";
            fileDialog.RestoreDirectory = true;

            if(fileDialog.ShowDialog() == true)
            {
                return fileDialog.FileName;
            }
            return "";
        }

        //Get file content in string
        public static string ReadFile(string _path)
        {
            string content = "";

            FileStream file = new FileStream(_path,FileMode.OpenOrCreate);
            BinaryFormatter formatter = new BinaryFormatter();

            try
            {
                content = formatter.Deserialize(file).ToString();
                MessageBox.Show(content, "Complete!!!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (SerializationException e)
            {
                MessageBox.Show(e.Message, "Error!!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                file.Close();
            }

            return content;
        }

        //Write content to file
        public static bool WriteFile(string _path, string _content)
        {
            FileStream file = new FileStream(_path, FileMode.OpenOrCreate);
            BinaryFormatter formatter = new BinaryFormatter();
            bool result = false;

            try
            {
                formatter.Serialize(file, _content);
                MessageBox.Show("'" + _content + "' is writed!", "Complete!!!", MessageBoxButton.OK, MessageBoxImage.Information);
                result = true;
            }
            catch (SerializationException e)
            {
                MessageBox.Show(e.Message, "Error!!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                file.Close();
            }

            return result;
        }
    }
}
