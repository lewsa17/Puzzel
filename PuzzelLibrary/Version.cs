namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 159; }
        public static int Build { get => 471; }
        public static string Hash { get => "48e8525f"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-12 14:12:58 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
