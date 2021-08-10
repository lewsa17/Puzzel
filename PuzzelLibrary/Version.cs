namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 177; }
        public static int Build { get => 579; }
        public static string Hash { get => "db17a37e"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-08-10 12:27:59 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
