namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 204; }
        public static int Build { get => 674; }
        public static string Hash { get => "41b0bc2a"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2022-05-16 12:15:29 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
