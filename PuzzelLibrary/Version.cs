namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 150; }
        public static int Build { get => 372; }
        public static string Hash { get => "d0a8f7ce"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-04-21 17:26:53 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
