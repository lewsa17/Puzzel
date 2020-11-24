namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 138; }
        public static int Build { get => 278; }
        public static string Hash { get => "ef7550f4"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2020-11-24 19:11:51 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
