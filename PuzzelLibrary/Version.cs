namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 197; }
        public static int Build { get => 648; }
        public static string Hash { get => "2e6f0caa"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-12-16 11:47:01 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
