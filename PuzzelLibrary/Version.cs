namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 164; }
        public static int Build { get => 519; }
        public static string Hash { get => "43d4a83a"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-19 21:00:15 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
