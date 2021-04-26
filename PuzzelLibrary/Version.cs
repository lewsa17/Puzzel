namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 153; }
        public static int Build { get => 407; }
        public static string Hash { get => "de4c6e1a"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-04-26 23:13:35 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
