namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 186; }
        public static int Build { get => 612; }
        public static string Hash { get => "8f3ad516"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-11-03 13:26:46 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
