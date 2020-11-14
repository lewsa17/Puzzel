namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 135; }
        public static int Build { get => 255; }
        public static string Hash { get => "edd1b389"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2020-11-14 02:47:52 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
