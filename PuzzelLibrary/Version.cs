namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 135; }
        public static int Build { get => 260; }
        public static string Hash { get => "8d56c34e"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2020-11-14 18:59:05 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
