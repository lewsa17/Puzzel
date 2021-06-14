namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 173; }
        public static int Build { get => 565; }
        public static string Hash { get => "cc478cc3"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-06-14 15:02:16 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
