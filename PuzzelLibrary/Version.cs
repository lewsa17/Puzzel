namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 135; }
        public static int Build { get => 262; }
        public static string Hash { get => "15f42da1"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2020-11-14 23:04:27 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
