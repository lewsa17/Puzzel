namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 179; }
        public static int Build { get => 585; }
        public static string Hash { get => "94b8cc04"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-09-02 16:02:51 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
