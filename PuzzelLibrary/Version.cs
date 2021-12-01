namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 189; }
        public static int Build { get => 630; }
        public static string Hash { get => "0e8defd6"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-12-01 16:06:00 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
