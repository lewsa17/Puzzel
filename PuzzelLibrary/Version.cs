namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 152; }
        public static int Build { get => 399; }
        public static string Hash { get => "ae085bb7"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-04-23 19:57:22 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
