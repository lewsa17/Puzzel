namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 200; }
        public static int Build { get => 659; }
        public static string Hash { get => "a76c71c6"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2022-02-17 14:37:10 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
