namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 160; }
        public static int Build { get => 481; }
        public static string Hash { get => "63451e69"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-13 13:26:43 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
