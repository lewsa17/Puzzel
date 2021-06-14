namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 172; }
        public static int Build { get => 561; }
        public static string Hash { get => "797ce1d7"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-06-10 11:05:44 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
