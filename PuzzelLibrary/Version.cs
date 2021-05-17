namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 162; }
        public static int Build { get => 503; }
        public static string Hash { get => "28a31e0b"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-14 16:01:25 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
