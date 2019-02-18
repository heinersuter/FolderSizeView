using System;
using System.IO;
using System.Windows.Forms;
using Alsolos.Commons.Wpf.Mvvm;

namespace FolderSizeView.FolderSelection
{
    public class FolderSelectorViewModel : ViewModel, INotifyPathChanged
    {
        public event EventHandler PathChanged = delegate { };

        public string Path
        {
            get => BackingFields.GetValue<string>();
            set => BackingFields.SetValue(value, OnPathChanged);
        }

        public DelegateCommand OpenBrowserCommand => BackingFields.GetCommand(OpenBrowser);

        private void OpenBrowser()
        {
            var openFileDialog = new FolderBrowserDialog();
            if (Directory.Exists(Path))
            {
                openFileDialog.SelectedPath = Path;
            }
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Path = openFileDialog.SelectedPath;
            }
        }

        private void OnPathChanged(string value)
        {
            if (Directory.Exists(Path))
            {
                PathChanged.Invoke(this, EventArgs.Empty);
            }
        }

    }
}
