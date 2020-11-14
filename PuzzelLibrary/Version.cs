namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 135; }
        public static int Build { get => 257; }
        public static string Hash { get => "a3e3d5ba"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2020-11-14 02:52:50 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
