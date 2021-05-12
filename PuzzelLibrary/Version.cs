namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 160; }
        public static int Build { get => 473; }
        public static string Hash { get => "692e3653"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-12 16:57:51 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
