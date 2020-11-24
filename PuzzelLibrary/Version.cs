namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 138; }
        public static int Build { get => 277; }
        public static string Hash { get => "3a336dda"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2020-11-24 19:10:02 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
