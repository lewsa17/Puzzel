namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 181; }
        public static int Build { get => 588; }
        public static string Hash { get => "86b42bb0"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-09-09 16:11:23 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
