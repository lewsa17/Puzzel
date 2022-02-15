namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 199; }
        public static int Build { get => 657; }
        public static string Hash { get => "e495ce66"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2022-01-03 16:19:33 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
