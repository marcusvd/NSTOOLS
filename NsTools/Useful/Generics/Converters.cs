using System;
using System.Collections.Generic;
using System.Text;

namespace NsTools.Useful.Generics
{
    public class Converters
    {
        public String ConvertSize(double size)
        {
            String[] units = new String[] { "B", "KB", "MB", "GB", "TB", "PB" };

            double mod = 1024;

            int i = 0;

            while (size >= mod)
            {
                size /= mod;
                i++;
            }
            return Math.Round(size, 2) + " " + units[i];//with 2 decimals
        }
    }
}
