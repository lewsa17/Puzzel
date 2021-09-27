namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 182; }
        public static int Build { get => 594; }
        public static string Hash { get => "c2d52e2d"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-09-27 12:15:09 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
