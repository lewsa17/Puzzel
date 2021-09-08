namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 180; }
        public static int Build { get => 586; }
        public static string Hash { get => "7455c454"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-09-08 17:09:32 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
