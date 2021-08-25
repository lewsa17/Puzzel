namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 178; }
        public static int Build { get => 581; }
        public static string Hash { get => "cdfc8e1a"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-08-25 10:25:32 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
