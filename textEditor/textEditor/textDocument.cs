using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Forms;

namespace textEditor
{
    public class textDocument
    {
        public string currentFile = null;
        public object dataFormats;
        public string fileString;
        public string rangeString;

        //THIS SHOULD WORK BUT FOR SOME REASON THE REFERENCES TO THE TEXTBOX 
        //AND THE OTHER OBJECT CALLED "TEXT" CREATED IN XAML.CS CAUSES THE 
        //PROGRAM TO BUILD SUCCESSFULLY WITHOUT EVER RUNNING
        MainWindow yuh = new MainWindow();
       

       

        public void saveTextAs()
        {
            System.Windows.Forms.SaveFileDialog save = new System.Windows.Forms.SaveFileDialog();
            save.Filter = "Regular Text File (*.txt|*.txt";
            save.FileName = "myText.txt";

            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamWriter stream = new System.IO.StreamWriter(save.FileName);
                stream.Write(yuh.textBox1.Text);
                stream.Close();
            }

        }

        public void saveText()
        {
            System.Windows.Forms.SaveFileDialog save = new System.Windows.Forms.SaveFileDialog();
            save.Filter = "Regular Text File (*.txt|*.txt";
            save.FileName = "myText.txt";

            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamWriter stream = new System.IO.StreamWriter(save.FileName);
                stream.Write(yuh.textBox1.Text);
                stream.Close();
            }
        }

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
                saveTextAs();
            }


            TextRange range;
            System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Regular Text File (*.txt|*.txt";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader stream = new System.IO.StreamReader(dlg.FileName);
                yuh.textBox1.Text = stream.ReadToEnd();
                stream.Close();
            }


        }
    }
}
