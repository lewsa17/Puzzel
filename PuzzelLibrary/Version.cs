namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 135; }
        public static int Build { get => 256; }
        public static string Hash { get => "960f4ba0"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2020-11-14 02:50:08 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
