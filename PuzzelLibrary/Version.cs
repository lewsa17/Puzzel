namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 176; }
        public static int Build { get => 573; }
        public static string Hash { get => "09eac811"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-06-28 15:51:44 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
