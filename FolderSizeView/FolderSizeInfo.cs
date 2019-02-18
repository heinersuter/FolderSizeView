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

                foreach (var child in Children)
                {
                    child.SizePercentage = 1.0 / Size * child.Size;
                }
            }
            catch
            {
                Children = Enumerable.Empty<FolderSizeInfo>();
                Size = 0;
            }
        }

        public DirectoryInfo DirectoryInfo { get; }

        public long Size { get; }

        public double SizePercentage { get; private set; } = 1.0;

        public IEnumerable<FolderSizeInfo> Children { get; }
    }
}
