namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 140; }
        public static int Build { get => 294; }
        public static string Hash { get => "aeefa677"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2020-12-01 19:33:01 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
