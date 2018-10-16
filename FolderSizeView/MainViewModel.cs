using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Alsolos.Commons.Wpf.Controls.Progress;

namespace FolderSizeView
{
    public class MainViewModel : BusyViewModel
    {
        public string Folder
        {
            get => BackingFields.GetValue<string>();
            set => BackingFields.SetValue(value, directory => UpdateItems());
        }

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

        private async void UpdateItems()
        {
            using (BusyHelper.Enter("Calculating folder size."))
            {
                if (Directory.Exists(Folder))
                {
                    var folderSizeInfo = await GetFolderSizeInfoAsync(Folder);

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

        private static Task<FolderSizeInfo> GetFolderSizeInfoAsync(string folder)
        {
            return Task.Run(() => new FolderSizeInfo(new DirectoryInfo(folder)));
        }
    }
}
