using System;

namespace FolderSizeView.FolderSelection
{
    public interface INotifyPathChanged
    {
        string Path { get; set; }

        event EventHandler PathChanged;
    }
}
