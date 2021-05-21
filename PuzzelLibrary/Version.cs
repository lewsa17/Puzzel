namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 165; }
        public static int Build { get => 531; }
        public static string Hash { get => "edd82280"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-21 09:20:29 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
