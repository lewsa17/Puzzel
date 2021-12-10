namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 194; }
        public static int Build { get => 649; }
        public static string Hash { get => "3c2bef29"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-12-10 13:09:29 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
