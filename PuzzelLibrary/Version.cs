using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 128; }
        public static int Build { get => 0; }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
