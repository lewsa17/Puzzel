namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 189; }
        public static int Build { get => 632; }
        public static string Hash { get => "e4b592de"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-12-02 15:02:39 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
