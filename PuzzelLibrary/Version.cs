namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 188; }
        public static int Build { get => 624; }
        public static string Hash { get => "9ab4ab7d"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-11-30 11:23:22 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
