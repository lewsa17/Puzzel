namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 160; }
        public static int Build { get => 478; }
        public static string Hash { get => "5a9f9947"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-13 12:44:52 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
