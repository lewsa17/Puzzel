namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 166; }
        public static int Build { get => 538; }
        public static string Hash { get => "d1eaeb96"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-21 12:20:20 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
