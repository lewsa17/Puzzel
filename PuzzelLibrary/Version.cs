namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 133; }
        public static int Build { get => 237; }
        public static string Hash { get => "c1cc36b4"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2020-11-12 21:04:46 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
