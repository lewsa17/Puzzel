namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 182; }
        public static int Build { get => 593; }
        public static string Hash { get => "4c8e52f7"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-09-27 11:50:25 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
