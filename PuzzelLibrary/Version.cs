namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 161; }
        public static int Build { get => 486; }
        public static string Hash { get => "ca06a9a5"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-13 17:39:00 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
