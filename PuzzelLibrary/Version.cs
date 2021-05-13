namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 161; }
        public static int Build { get => 484; }
        public static string Hash { get => "4ca9c33e"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-13 16:32:57 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
