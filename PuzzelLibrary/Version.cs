namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 162; }
        public static int Build { get => 502; }
        public static string Hash { get => "677431ec"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-14 15:51:04 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
