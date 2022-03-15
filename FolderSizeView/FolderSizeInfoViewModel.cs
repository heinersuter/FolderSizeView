using System.Collections.Generic;
using System.Diagnostics;
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

        public string Name => _folderSizeInfo.DirectoryInfo.Name;

        public string Size => FileSizeFormatter.FormatSize(_folderSizeInfo.Size);

        public int NumberOfFiles => _folderSizeInfo.NumberOfFiles;

        public string SizePercentage => $"{_folderSizeInfo.SizePercentage:P1}";

        public IEnumerable<FolderSizeInfoViewModel> Children { get; }

        public DelegateCommand OpenFolderCommand => BackingFields.GetCommand(OpenFolder);

        private void OpenFolder()
        {
            Process.Start(_folderSizeInfo.DirectoryInfo.FullName);
        }
    }
}
