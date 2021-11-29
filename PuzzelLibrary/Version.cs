namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 187; }
        public static int Build { get => 620; }
        public static string Hash { get => "b7988d41"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-11-22 15:23:18 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
