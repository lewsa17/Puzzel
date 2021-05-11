namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 159; }
        public static int Build { get => 468; }
        public static string Hash { get => "e43be1a6"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-11 16:06:09 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
