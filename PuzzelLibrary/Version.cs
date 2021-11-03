namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 185; }
        public static int Build { get => 611; }
        public static string Hash { get => "633ff679"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-11-03 12:29:45 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
