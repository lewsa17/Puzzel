namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 144; }
        public static int Build { get => 318; }
        public static string Hash { get => "5991623c"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2020-12-28 16:23:25 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
