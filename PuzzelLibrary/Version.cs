namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 170; }
        public static int Build { get => 553; }
        public static string Hash { get => "37a52658"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-06-01 16:29:56 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
