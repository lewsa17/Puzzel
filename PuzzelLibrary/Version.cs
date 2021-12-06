namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 191; }
        public static int Build { get => 639; }
        public static string Hash { get => "7e8c5c86"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-12-06 13:53:32 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
