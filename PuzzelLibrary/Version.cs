namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 161; }
        public static int Build { get => 489; }
        public static string Hash { get => "c0545483"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-13 18:22:01 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
