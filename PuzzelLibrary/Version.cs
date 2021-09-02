namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 178; }
        public static int Build { get => 583; }
        public static string Hash { get => "077036c1"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-09-02 15:45:16 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
