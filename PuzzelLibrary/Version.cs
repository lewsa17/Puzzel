namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 133; }
        public static int Build { get => 238; }
        public static string Hash { get => "a9dd43ac"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2020-11-12 21:25:09 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
