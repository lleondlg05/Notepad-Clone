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
using System.Security.Cryptography;

namespace Notepad_Clone
{
    //TODO: Set line and columns
    //TODO: Create the shortcuts
    //TODO: Initialize the Carriage Returns
    //TODO: Initialize the Unicode
    //TODO: Create a popup to change the font settings
    //TODO: Save the font changes and load them at the app startup

    public partial class MainWindow : Window
    {
        private double zoomScale = 1;
        private double incrementation = 0.1;
        private double defaultZoomScale = 1;
        private double defaultFontSize = 16;

        bool showStatusBar = true;
        bool wordWrap = true;

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

        private void Exit_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Undo_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (TextArea.CanUndo)
                TextArea.Undo();
        }

        private void Cut_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            TextArea.Cut();
        }

        private void Copy_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            TextArea.Copy();
        }

        private void Paste_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            TextArea.Paste();
        }

        private void Delete_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            TextArea.Text = TextArea.Text.Remove(TextArea.SelectionStart, TextArea.SelectionLength);
        }

        //TODO: Create a pop up window to set the text to replace
        private void Replace_MenuItem_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void PageSetupMenuItem_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            pd.ShowDialog();
        }

        private void SelectAll_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            TextArea.SelectAll();
        }

        private void TimeDate_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            TextArea.Text = TextArea.Text.Insert(TextArea.CaretIndex, DateTime.Now.ToString());
        }
        
        private void ZoomIn_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            zoomScale += incrementation;
            TextArea.FontSize = defaultFontSize * zoomScale;
            ZoomTextBlock.Text = $"Zoom {zoomScale * 100}%";
        }

        private void ZoomOut_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            zoomScale -= incrementation;
            TextArea.FontSize = defaultFontSize * zoomScale;
            ZoomTextBlock.Text = $"Zoom {zoomScale * 100}%";
        }

        private void RestoreDefaultZoom_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            zoomScale = defaultZoomScale;
            TextArea.FontSize = defaultFontSize * zoomScale;
            ZoomTextBlock.Text = $"Zoom {zoomScale * 100}%";
        }

        private void StatusBar_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            StatusBarManager();
        }

        private void WordWrap_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            WordWrapManager();
        }

        private void Open_FileDialog()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            ofd.FilterIndex = 1;
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
            sfd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            sfd.FilterIndex = 1;
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

        private void StatusBarManager()
        {
            if(showStatusBar)
                showStatusBar = false;
            else
                showStatusBar = true;

            if(showStatusBar)
                statusBar.Visibility = Visibility.Visible;
            else
                statusBar.Visibility = Visibility.Collapsed;
        }

        private void WordWrapManager()
        {
            if(wordWrap)
                wordWrap = false;
            else
                wordWrap = true;

            if (wordWrap)
                TextArea.TextWrapping = TextWrapping.Wrap;
            else
                TextArea.TextWrapping = TextWrapping.NoWrap;
        }

        private void TextArea_SelectionChanged(object sender, RoutedEventArgs e)
        {
            int lineIdx = 0;
            int columnIdx = 0;
            int caretIdx = TextArea.CaretIndex;
            string content = TextArea.Text;

            columnIdx = caretIdx;

            for (int i = 0; i < caretIdx; i++)
            {
                if (content[i] == '\n')
                {
                    lineIdx++;
                    columnIdx = caretIdx - (i + 1);
                }
                
            }

            LineIndexText.Text = lineIdx.ToString();
            ColumnIndexText.Text = columnIdx.ToString();
        }
    }
}
