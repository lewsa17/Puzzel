namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 139; }
        public static int Build { get => 290; }
        public static string Hash { get => "861005fb"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2020-11-27 22:07:46 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
