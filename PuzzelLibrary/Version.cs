namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 196; }
        public static int Build { get => 647; }
        public static string Hash { get => "a327dfc1"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-12-14 09:33:45 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
