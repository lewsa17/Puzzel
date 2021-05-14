namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 161; }
        public static int Build { get => 492; }
        public static string Hash { get => "f048202a"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-14 11:02:27 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
