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
using System.Diagnostics;

namespace Notepad_Clone
{
    /// <summary>
    /// Open the OpenFileDialog
    /// </summary>
    public partial class MainWindow : Window
    {
        bool match = true;

        string filePath = "";
        string titleName = "Untitled";
        string documentContent = "";

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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TitleManager();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!match)
            {
                e.Cancel = true;
                if (MessageBox.Show("You have not saved the document. Would you like save the changes now?",
                    "Save document", MessageBoxButton.YesNo,
                    MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    SaveDocument();
                    Environment.Exit(0);
                }
                else
                {
                    Environment.Exit(0);
                }

            }
        }

        private void NewWindow_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                Process.Start(Process.GetCurrentProcess().MainModule.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to do that." + ex.Message);
            }
        }

        private void Open_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Open_FileDialog();
        }

        private void Save_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            SaveDocument();
        }

        private void SaveAs_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            SaveAs();
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

                Match = true;
            }
            else
            {
                SaveAs();
            }

            TitleManager();
        }

        private void SaveAs()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();

            if(sfd.FileName != "")
            {
                FilePath = sfd.FileName;
                TitleName= sfd.SafeFileName;
                StreamWriter sw = new StreamWriter(FilePath);
                DocumentContent = TextArea.Text;
                sw.Write(DocumentContent);
                sw.Close();

                Match = true;
            }
            TitleManager();
        }

        private void PageSetupMenuItem_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            pd.ShowDialog();
        }

        private void TextArea_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextArea.Text != DocumentContent)
            {
                //Add an asterix on the beginning of our tittle
                match = false;
            }
            else
            {
                match = true;
            }

            TitleManager();
        }

        private void TitleManager()
        {
            if (match)
            {
                Title = TitleName + " - " + "Notepad Clone";
            }
            else
            {
                Title = "*" + TitleName + " - " + "Notepad Clone";
            }
        }

        private void NewDocument()
        {
            if (!Match)
            {
                FilePath = "";
                TitleName = "Untitled";
                DocumentContent = "";
                Match = true;
                TextArea.Text = DocumentContent;
            }
        }

        private void NewTab_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (!match)
            {
                if (MessageBox.Show("You have not saved the document. Would you like save the changes now?",
                    "Save document", MessageBoxButton.YesNo,
                    MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    SaveDocument();
                    NewDocument();
                }
                else
                {
                    NewDocument();
                }

            }
            else
            {
                NewDocument();
            }
        }

    }
}
