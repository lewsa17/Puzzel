namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 182; }
        public static int Build { get => 590; }
        public static string Hash { get => "6fd3888b"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-09-10 08:03:41 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
