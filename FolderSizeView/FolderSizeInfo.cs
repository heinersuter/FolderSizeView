using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FolderSizeView
{
    public class FolderSizeInfo
    {
        public FolderSizeInfo(DirectoryInfo directoryInfo)
        {
            DirectoryInfo = directoryInfo;

            try
            {
                Children = DirectoryInfo.GetDirectories()
                    .Select(info => new FolderSizeInfo(info))
                    .OrderByDescending(info => info.Size)
                    .ToList();

                Size = directoryInfo.GetFiles().Sum(file => file.Length) + Children.Sum(folder => folder.Size);
            }
            catch
            {
                Children = Enumerable.Empty<FolderSizeInfo>();
                Size = 0;
            }
        }

        public DirectoryInfo DirectoryInfo { get; }

        public long Size { get; }

        public IEnumerable<FolderSizeInfo> Children { get; }
    }
}
