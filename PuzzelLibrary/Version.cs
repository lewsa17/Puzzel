namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 164; }
        public static int Build { get => 518; }
        public static string Hash { get => "fc3b2aeb"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-19 20:58:20 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
