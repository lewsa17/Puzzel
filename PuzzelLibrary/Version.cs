namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 160; }
        public static int Build { get => 482; }
        public static string Hash { get => "570fdb9b"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-13 16:17:39 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
