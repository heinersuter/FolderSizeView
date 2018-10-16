using System.Collections.Generic;
using System.Linq;
using Alsolos.Commons.Wpf.Mvvm;

namespace FolderSizeView
{
    public class FolderSizeInfoViewModel : ViewModel
    {
        private readonly FolderSizeInfo _folderSizeInfo;

        public FolderSizeInfoViewModel(FolderSizeInfo folderSizeInfo)
        {
            _folderSizeInfo = folderSizeInfo;
            Children = folderSizeInfo.Children.Select(info => new FolderSizeInfoViewModel(info));
        }

        public IEnumerable<FolderSizeInfoViewModel> Children { get; }

        public string DisplayName => $"{_folderSizeInfo.DirectoryInfo.Name} ({FileSizeFormatter.FormatSize(_folderSizeInfo.Size)})";
    }
}
