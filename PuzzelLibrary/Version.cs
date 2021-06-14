namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 173; }
        public static int Build { get => 563; }
        public static string Hash { get => "72aba1bd"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-06-14 12:13:32 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
