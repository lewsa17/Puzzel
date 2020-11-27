namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 139; }
        public static int Build { get => 289; }
        public static string Hash { get => "a846c2f4"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2020-11-27 21:57:04 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
