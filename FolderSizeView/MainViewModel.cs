using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Alsolos.Commons.Wpf.Controls.Progress;
using FolderSizeView.FolderSelection;

namespace FolderSizeView
{
    public class MainViewModel : BusyViewModel
    {
        public MainViewModel()
        {
            FolderSelectorViewModel.PathChanged += OnFolderSelectorViewModelPathChanged;
        }

        private async void OnFolderSelectorViewModelPathChanged(object sender, EventArgs e)
        {
            using (BusyHelper.Enter("Calculating folder size."))
            {
                if (Directory.Exists(FolderSelectorViewModel.Path))
                {
                    var folderSizeInfo = await GetFolderSizeInfoAsync(FolderSelectorViewModel.Path);

                    Items = new[]
                    {
                        new FolderSizeInfoViewModel(folderSizeInfo)
                    };
                }
                else
                {
                    Items = null;
                }
            }
        }

        public FolderSelectorViewModel FolderSelectorViewModel => BackingFields.GetValue(() => new FolderSelectorViewModel());

        public IEnumerable<FolderSizeInfoViewModel> Items
        {
            get => BackingFields.GetValue<IEnumerable<FolderSizeInfoViewModel>>();
            set => BackingFields.SetValue(value);
        }

        public string SelectedItem
        {
            get => BackingFields.GetValue<string>();
            set => BackingFields.SetValue(value);
        }

        private static Task<FolderSizeInfo> GetFolderSizeInfoAsync(string folder)
        {
            return Task.Run(() => new FolderSizeInfo(new DirectoryInfo(folder)));
        }
    }
}
