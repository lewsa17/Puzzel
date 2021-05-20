namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 164; }
        public static int Build { get => 524; }
        public static string Hash { get => "6bacd460"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-20 14:50:15 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
