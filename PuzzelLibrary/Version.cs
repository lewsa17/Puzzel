namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 164; }
        public static int Build { get => 526; }
        public static string Hash { get => "40981508"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-20 18:39:38 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
