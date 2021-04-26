namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 151; }
        public static int Build { get => 381; }
        public static string Hash { get => "4c682cdd"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-04-22 19:12:29 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
