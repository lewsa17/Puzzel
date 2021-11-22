namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 186; }
        public static int Build { get => 615; }
        public static string Hash { get => "dfd91bc7"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-11-03 14:41:31 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
