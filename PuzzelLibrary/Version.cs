namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 200; }
        public static int Build { get => 658; }
        public static string Hash { get => "8bb4dceb"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2022-02-15 15:05:42 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
