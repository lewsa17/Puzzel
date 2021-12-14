namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 196; }
        public static int Build { get => 654; }
        public static string Hash { get => "719bcb2a"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-12-13 16:11:56 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
