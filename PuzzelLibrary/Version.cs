namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 173; }
        public static int Build { get => 566; }
        public static string Hash { get => "cb3d2ff4"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-06-14 16:13:27 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
