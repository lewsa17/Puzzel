namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 185; }
        public static int Build { get => 609; }
        public static string Hash { get => "99b6f0cd"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-11-02 16:24:02 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
