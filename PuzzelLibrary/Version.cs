namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 191; }
        public static int Build { get => 638; }
        public static string Hash { get => "1f4fd310"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-12-03 16:14:29 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
