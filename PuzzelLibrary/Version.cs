namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 138; }
        public static int Build { get => 284; }
        public static string Hash { get => "2e83e467"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2020-11-27 20:35:36 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
