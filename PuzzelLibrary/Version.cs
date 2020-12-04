namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 141; }
        public static int Build { get => 300; }
        public static string Hash { get => "631490ad"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2020-12-04 20:19:09 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
