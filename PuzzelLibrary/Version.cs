namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 177; }
        public static int Build { get => 578; }
        public static string Hash { get => "532ceb9f"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-08-10 11:30:33 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
