namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 160; }
        public static int Build { get => 479; }
        public static string Hash { get => "f67b41fb"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-13 13:14:32 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
