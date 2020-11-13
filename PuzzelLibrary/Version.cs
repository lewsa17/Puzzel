namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 134; }
        public static int Build { get => 248; }
        public static string Hash { get => "2d534213"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2020-11-14 00:42:38 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
