namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 193; }
        public static int Build { get => 646; }
        public static string Hash { get => "cd2176fd"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-12-08 13:11:03 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
