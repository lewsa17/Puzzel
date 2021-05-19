namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 164; }
        public static int Build { get => 517; }
        public static string Hash { get => "68e1b8ff"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-19 15:51:49 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
