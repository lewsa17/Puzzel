namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 175; }
        public static int Build { get => 570; }
        public static string Hash { get => "7047f0b8"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-06-23 15:59:04 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
