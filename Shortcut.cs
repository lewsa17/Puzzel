using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzel
{
    public static class ShortCut
    {
        private static string[] KeyCombination = Array.Empty<string>();
        public static void SetKeyCode(string value)
        {
            Array.Resize(ref KeyCombination, KeyCombination.Length + 1);
            KeyCombination.SetValue(value, KeyCombination.Length-1);
        }
        public static string[] GetUsedKeyCode()
        {
            return KeyCombination;
        }
    }
}
