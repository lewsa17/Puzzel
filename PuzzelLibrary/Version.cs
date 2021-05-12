namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 159; }
        public static int Build { get => 472; }
        public static string Hash { get => "c3eac767"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-12 14:58:58 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
