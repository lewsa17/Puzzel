namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 192; }
        public static int Build { get => 643; }
        public static string Hash { get => "5fd717dc"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-12-07 10:14:32 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
