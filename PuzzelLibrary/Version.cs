namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 133; }
        public static int Build { get => 231; }
        public static string Hash { get => "4bb6460a"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2020-11-08 17:02:20 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
