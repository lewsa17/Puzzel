namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 175; }
        public static int Build { get => 572; }
        public static string Hash { get => "de996263"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-06-23 18:20:51 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
