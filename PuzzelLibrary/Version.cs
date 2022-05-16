namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 203; }
        public static int Build { get => 671; }
        public static string Hash { get => "4317d619"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2022-05-11 16:03:12 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
