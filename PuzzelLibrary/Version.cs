namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 134; }
        public static int Build { get => 246; }
        public static string Hash { get => "93fe9cb6"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2020-11-13 23:38:43 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
