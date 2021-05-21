namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 166; }
        public static int Build { get => 536; }
        public static string Hash { get => "908e0db1"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-21 11:55:37 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
