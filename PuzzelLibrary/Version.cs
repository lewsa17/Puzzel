namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 182; }
        public static int Build { get => 592; }
        public static string Hash { get => "2c77b6ce"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-09-10 10:20:05 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
