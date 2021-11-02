namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 185; }
        public static int Build { get => 608; }
        public static string Hash { get => "bcecb45c"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-11-02 16:23:07 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
