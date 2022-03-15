using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Alsolos.Commons.Wpf.Controls.Progress;

namespace FolderSizeView.SizeTree
{
    public class SizeTreeViewModel : BusyViewModel
    {
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

        public async void SetPath(string path)
        {
            using (BusyHelper.Enter("Calculating folder size."))
            {
                if (Directory.Exists(path))
                {
                    var folderSizeInfo = await GetFolderSizeInfoAsync(path);

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
