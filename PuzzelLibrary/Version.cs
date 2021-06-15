namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 174; }
        public static int Build { get => 567; }
        public static string Hash { get => "045bc36d"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-06-15 16:02:27 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
