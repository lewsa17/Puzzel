namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 132; }
        public static int Build { get => 227; }
        public static string Hash { get => "959e4c9f"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2020-11-07 21:47:59 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
