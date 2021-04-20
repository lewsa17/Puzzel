namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 146; }
        public static int Build { get => 334; }
        public static string Hash { get => "d646178f"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-04-21 00:26:23 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
