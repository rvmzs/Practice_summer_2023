using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Praktika_Lavrentev_Abdrahmanov
{
    internal static class HelpMethods
    {
        public static SolidColorBrush getHexBrush(string hexNum)
        {
            return new SolidColorBrush((Color)ColorConverter.ConvertFromString(hexNum));
        }
    }
}
