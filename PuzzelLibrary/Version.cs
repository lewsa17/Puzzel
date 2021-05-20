namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 164; }
        public static int Build { get => 522; }
        public static string Hash { get => "1787e581"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-19 22:05:07 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
