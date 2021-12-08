namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 194; }
        public static int Build { get => 647; }
        public static string Hash { get => "6031757a"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-12-08 15:59:28 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
