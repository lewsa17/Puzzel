namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 142; }
        public static int Build { get => 303; }
        public static string Hash { get => "8be4a27f"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2020-12-08 16:38:40 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
