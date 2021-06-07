namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 171; }
        public static int Build { get => 555; }
        public static string Hash { get => "1dcd186d"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-06-07 12:27:03 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
