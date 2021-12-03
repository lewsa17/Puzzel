namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 190; }
        public static int Build { get => 637; }
        public static string Hash { get => "a772a37e"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-12-03 16:13:44 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
