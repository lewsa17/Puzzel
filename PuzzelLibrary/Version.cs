namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 188; }
        public static int Build { get => 622; }
        public static string Hash { get => "1a34cc7d"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-11-29 16:10:37 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
