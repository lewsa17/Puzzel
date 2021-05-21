namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 166; }
        public static int Build { get => 537; }
        public static string Hash { get => "5a52dda0"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-21 12:04:08 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
