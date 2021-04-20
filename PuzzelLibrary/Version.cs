namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 149; }
        public static int Build { get => 364; }
        public static string Hash { get => "3d898230"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-04-21 01:30:14 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
