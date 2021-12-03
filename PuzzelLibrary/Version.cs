namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 190; }
        public static int Build { get => 636; }
        public static string Hash { get => "3f3ecb42"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-12-03 15:41:37 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
