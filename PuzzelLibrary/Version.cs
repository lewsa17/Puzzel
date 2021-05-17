namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 162; }
        public static int Build { get => 511; }
        public static string Hash { get => "925fde52"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-17 15:51:08 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
