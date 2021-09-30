namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 183; }
        public static int Build { get => 596; }
        public static string Hash { get => "5cc2ea2b"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-09-27 18:05:11 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
