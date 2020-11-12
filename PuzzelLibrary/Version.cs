namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 133; }
        public static int Build { get => 234; }
        public static string Hash { get => "ef42c59a"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2020-11-12 20:48:53 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
