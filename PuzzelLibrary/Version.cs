namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 192; }
        public static int Build { get => 642; }
        public static string Hash { get => "8e4faca0"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-12-06 16:05:08 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
