namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 190; }
        public static int Build { get => 635; }
        public static string Hash { get => "e662cab1"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-12-02 15:53:05 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
