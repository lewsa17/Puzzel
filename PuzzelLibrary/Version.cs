namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 176; }
        public static int Build { get => 576; }
        public static string Hash { get => "bb4c3127"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-08-10 11:22:41 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
