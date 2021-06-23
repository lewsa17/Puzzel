namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 175; }
        public static int Build { get => 568; }
        public static string Hash { get => "d90a0e2e"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-06-15 16:03:15 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
