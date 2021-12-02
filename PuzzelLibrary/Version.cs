namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 190; }
        public static int Build { get => 634; }
        public static string Hash { get => "8f2c6ddd"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-12-02 15:51:46 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
