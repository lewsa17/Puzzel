namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 188; }
        public static int Build { get => 628; }
        public static string Hash { get => "6c34ae70"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-12-01 10:17:25 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
