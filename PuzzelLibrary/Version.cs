namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 132; }
        public static int Build { get => 229; }
        public static string Hash { get => "651c6782"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2020-11-08 02:28:19 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
