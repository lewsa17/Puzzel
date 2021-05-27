namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 167; }
        public static int Build { get => 545; }
        public static string Hash { get => "ae4d7da0"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-27 08:59:07 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
