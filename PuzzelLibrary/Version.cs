namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 198; }
        public static int Build { get => 655; }
        public static string Hash { get => "7487539d"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2022-01-03 11:45:57 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
