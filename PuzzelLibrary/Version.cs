namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 179; }
        public static int Build { get => 584; }
        public static string Hash { get => "e07afd8e"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-09-02 16:02:05 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
