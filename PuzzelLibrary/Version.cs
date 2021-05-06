namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 157; }
        public static int Build { get => 452; }
        public static string Hash { get => "a6983d94"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-06 19:19:21 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
