using System;

namespace FolderSizeView
{
    public static class FileSizeFormatter
    {
        public static string FormatSize(long size)
        {
            if (size == 0)
            {
                return "Empty";
            }

            var divided = DivideBy1024Power(size, 4);
            if (divided >= 1)
            {
                return $"{divided:N3} TB";
            }

            divided = DivideBy1024Power(size, 3);
            if (divided >= 1)
            {
                return $"{divided:N3} GB";
            }

            divided = DivideBy1024Power(size, 2);
            if (divided >= 1)
            {
                return $"{divided:N3} MB";
            }

            divided = DivideBy1024Power(size, 1);
            if (divided >= 1)
            {
                return $"{divided:N3} KB";
            }

            return $"{size:N3} Bytes";
        }

        private static double DivideBy1024Power(long size, int power)
        {
            return size / Math.Pow(1024.0, power);
        }
    }
}