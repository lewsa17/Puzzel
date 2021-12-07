namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 193; }
        public static int Build { get => 644; }
        public static string Hash { get => "ee4ca385"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-12-07 13:41:16 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
