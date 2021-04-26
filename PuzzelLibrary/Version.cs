namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 153; }
        public static int Build { get => 402; }
        public static string Hash { get => "dd4c84e7"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-04-26 15:48:59 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
