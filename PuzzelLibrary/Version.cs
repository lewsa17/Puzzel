namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 159; }
        public static int Build { get => 470; }
        public static string Hash { get => "6fd432aa"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-12 14:04:41 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
