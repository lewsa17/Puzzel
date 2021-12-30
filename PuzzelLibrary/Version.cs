namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 197; }
        public static int Build { get => 651; }
        public static string Hash { get => "670179cd"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-12-17 14:10:03 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
