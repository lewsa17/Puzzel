namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 173; }
        public static int Build { get => 564; }
        public static string Hash { get => "db826298"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-06-14 13:08:26 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
