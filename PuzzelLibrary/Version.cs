namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 194; }
        public static int Build { get => 648; }
        public static string Hash { get => "8fb3ee2a"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-12-08 16:00:19 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
