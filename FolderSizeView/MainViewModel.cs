using System;
using Alsolos.Commons.Wpf.Mvvm;
using FolderSizeView.FolderSelection;
using FolderSizeView.SizeTree;

namespace FolderSizeView
{
    public class MainViewModel : ViewModel
    {
        public MainViewModel()
        {
            FolderSelectorViewModel.PathChanged += OnFolderSelectorViewModelPathChanged;
        }

        private void OnFolderSelectorViewModelPathChanged(object sender, EventArgs e)
        {
            SizeTreeViewModel.SetPath(FolderSelectorViewModel.Path);
        }

        public FolderSelectorViewModel FolderSelectorViewModel => BackingFields.GetValue(() => new FolderSelectorViewModel());

        public SizeTreeViewModel SizeTreeViewModel => BackingFields.GetValue(() => new SizeTreeViewModel());
    }
}
