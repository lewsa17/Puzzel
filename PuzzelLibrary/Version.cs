namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 146; }
        public static int Build { get => 329; }
        public static string Hash { get => "9a2da357"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-02-02 00:45:28 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
