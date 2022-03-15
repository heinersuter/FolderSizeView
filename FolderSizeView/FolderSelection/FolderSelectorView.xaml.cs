using System.IO;
using System.Windows;

namespace FolderSizeView.FolderSelection
{
    public partial class FolderSelectorView
    {
        public FolderSelectorView()
        {
            InitializeComponent();
        }

        private void OnDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var filenames = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (filenames != null && filenames.Length == 1)
                {
                    e.Effects = DragDropEffects.All;
                    e.Handled = true;
                    return;
                }
            }

            e.Handled = true;
        }

        private void OnDrop(object sender, DragEventArgs e)
        {
            var filenames = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (filenames != null && filenames.Length == 1)
            {
                if (File.Exists(filenames[0]))
                {
                    FolderTextBox.Text = Path.GetDirectoryName(filenames[0]);

                }
                else
                {
                    FolderTextBox.Text = filenames[0];
                }
            }
        }

        private void OnPreviewDragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Move;
            e.Handled = true;
        }
    }
}
