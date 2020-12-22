namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 143; }
        public static int Build { get => 305; }
        public static string Hash { get => "7a284411"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2020-12-22 14:44:46 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
