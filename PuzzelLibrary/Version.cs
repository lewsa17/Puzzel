namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 158; }
        public static int Build { get => 455; }
        public static string Hash { get => "666e94ae"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-07 16:24:20 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
