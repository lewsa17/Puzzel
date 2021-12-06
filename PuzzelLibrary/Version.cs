namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 191; }
        public static int Build { get => 641; }
        public static string Hash { get => "7ae120dd"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-12-06 14:09:01 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
