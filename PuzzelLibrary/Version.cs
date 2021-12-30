namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 198; }
        public static int Build { get => 653; }
        public static string Hash { get => "2cb48369"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-12-30 13:31:29 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
