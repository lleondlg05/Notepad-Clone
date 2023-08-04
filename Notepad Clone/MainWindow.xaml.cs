using Microsoft.Win32;
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
using System.IO;

namespace Notepad_Clone
{
    /// <summary>
    /// Open the OpenFileDialog
    /// </summary>
    public partial class MainWindow : Window
    {
        bool match = true;

        string filePath;
        string titleName;
        string documentContent;

        private bool Match
        {
            get => match; 
            set => match = value; 
        }

        private string FilePath
        {
            get => filePath; 
            set => filePath = value;
        }

        private string TitleName
        {
            get => titleName;
            set => titleName = value;
        }

        private string DocumentContent 
        {
            get => documentContent;
            set => documentContent = value;
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Open_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Open_FileDialog();
        }

        private void Save_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            SaveDocument();
        }

        private void Open_FileDialog()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //Open the dialog
            ofd.ShowDialog();

            //Make sure that the ofd has the value selected
            try
            {
                if (ofd.FileName != null && ofd.CheckPathExists)
                {
                    //Path to document
                    FilePath = ofd.FileName;
                    //Document name
                    TitleName = ofd.SafeFileName;
                    //if the document matches the textbox
                    Match = true;

                    //Stream reader to read the content of the document 
                    StreamReader FileReader = new StreamReader(FilePath);
                    //Add the content of the document to the DocumentContent
                    DocumentContent = FileReader.ReadToEnd();
                    //Add the document content to the TextArea
                    TextArea.Text = DocumentContent;
                    //Close the stream
                    FileReader.Close();
                }
            }catch
            {
                
            }
        }

        private void SaveDocument()
        {
            if(FilePath != "") 
            {
                //SaveFileStream
                StreamWriter SaveFileStream = new StreamWriter(FilePath);
                //Assigns the textbox content to the documentContent
                DocumentContent = TextArea.Text;
                //Writes the documentContent to the file
                SaveFileStream.Write(DocumentContent);
                //Close the stream
                SaveFileStream.Close();
            }
            else
            {
                SaveAs();
            }
        }

        private void SaveAs()
        {

        }
    }
}
