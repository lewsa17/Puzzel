namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 154; }
        public static int Build { get => 412; }
        public static string Hash { get => "c738b54b"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-04-29 21:05:01 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
