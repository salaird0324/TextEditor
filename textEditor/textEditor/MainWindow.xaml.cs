//using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

using System.Windows.Forms;

using System.Runtime.Serialization.Formatters.Binary;


namespace textEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //CREATING OBJECTS FROM THE OTHER CLASS DID NOT WORK HERE
  
        private string currentFile = null;
        private object dataFormats;
        private string fileString;
        private string rangeString;
        public string test = "";
       // textDocument text = new textDocument();

        public MainWindow()
        {
            InitializeComponent();
           
        }

        public void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        public void MenuItem_ClickNew(object sender, RoutedEventArgs e)
        {
            //WOULD USE OBJECT TO ACCESS THIS IN THE textDocument.cs CLASS
           
            newText();
           
        }

        public void MenuItem_ClickOpen(object sender, RoutedEventArgs e)
        {
            //WOULD USE OBJECT TO ACCESS THIS IN THE textDocument.cs CLASS
            // text.SetText();
            SetText();
           
        }

        public void MenuItem_ClickSave(object sender, RoutedEventArgs e)
        {
            //WOULD USE OBJECT TO ACCESS THIS IN THE textDocument.cs CLASS
            //text.saveText();
            saveText();
        }

        public void MenuItem_ClickSaveAs(object sender, RoutedEventArgs e)
        {
            //WOULD USE OBJECT TO ACCESS THIS IN THE textDocument.cs CLASS
            //text.saveTextAs;
            saveTextAs();
        }

        public void MenuItem_ClickExit(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        //THIS FUNCTION SHOULD BE IN THE textDocument.cs CLASS
        public void SetText()
        {
           
            string message = "Do you want to exit without saving?";
            string caption = "exit";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Question;
            DialogResult result;

            result = System.Windows.Forms.MessageBox.Show(message, caption, buttons, icon);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //SHOULD BE CALLING THE FUNCTION saveTextAs() IN THE textDocument.cs CLASS 
                clear();
            }
            if (result == System.Windows.Forms.DialogResult.No)
            {
                //WOULD CALL CLEAR FUNCTION THAT WOULD BE IN textDocument.cs
                saveTextAs();

            }


            TextRange range;
                System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
                dlg.DefaultExt = ".txt";
                dlg.Filter = "Regular Text File (*.txt|*.txt";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                System.IO.StreamReader stream = new System.IO.StreamReader(dlg.FileName);
                textBox1.Text = stream.ReadToEnd();
                stream.Close();
            }
 
         
        }

        public void newText() {

            string message = "Do you want to exit without saving?";
            string caption = "exit";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Question;
            DialogResult result;

            result = System.Windows.Forms.MessageBox.Show(message, caption, buttons, icon);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //SHOULD BE CALLING THE FUNCTION saveTextAs() IN THE textDocument.cs CLASS 
                clear();
            }
            if (result == System.Windows.Forms.DialogResult.No) {
                //WOULD CALL CLEAR FUNCTION THAT WOULD BE IN textDocument.cs
                saveTextAs();
                
            }
            if (!String.IsNullOrEmpty(currentFile))
            {
                this.currentFile = null;
            }
          
        }

        public void clear() {
            textBox1.Clear();
        }


        //THIS FUNCTION SHOULD BE IN THE textDocument.cs CLASS
        public void saveTextAs() {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Regular Text File (*.txt|*.txt";
            save.FileName = "myText.txt";

            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                System.IO.StreamWriter stream = new System.IO.StreamWriter(save.FileName);
                stream.Write(textBox1.Text);
                stream.Close();
            }

        }


        //THIS FUNCTION SHOULD BE IN THE textDocument.cs CLASS
        public void saveText() {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Regular Text File (*.txt|*.txt";
            save.FileName = "myText.txt";

            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamWriter stream = new System.IO.StreamWriter(save.FileName);
                stream.Write(textBox1.Text);
                stream.Close();
            }
        }


        //THIS FUNCTION CAN STAY AS IT IS ONLY REFERENCING THE VIEW
        public void about() {
            MessageBoxResult message = System.Windows.MessageBox.Show("This program was made by Spencer Laird");
            if (message == MessageBoxResult.Yes)
            {
                
            }
        }

        private void MenuItem_Click_About(object sender, RoutedEventArgs e)
        {
            about();
        }
    }
}
