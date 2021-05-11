namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 158; }
        public static int Build { get => 459; }
        public static string Hash { get => "8b5641ac"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-11 12:23:45 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
