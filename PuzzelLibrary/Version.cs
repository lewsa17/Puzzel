namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 159; }
        public static int Build { get => 469; }
        public static string Hash { get => "dd1a4e6f"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-11 18:32:55 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
