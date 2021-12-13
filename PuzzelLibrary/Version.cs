namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 195; }
        public static int Build { get => 652; }
        public static string Hash { get => "8c8924f0"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-12-10 15:55:19 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
