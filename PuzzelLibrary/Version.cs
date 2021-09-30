namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 184; }
        public static int Build { get => 597; }
        public static string Hash { get => "817dc6d9"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-09-30 10:40:41 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
