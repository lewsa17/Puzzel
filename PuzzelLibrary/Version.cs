namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 160; }
        public static int Build { get => 476; }
        public static string Hash { get => "c9018446"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-13 08:47:54 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
