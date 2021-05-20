namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 165; }
        public static int Build { get => 529; }
        public static string Hash { get => "6cde0758"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-20 21:15:27 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
