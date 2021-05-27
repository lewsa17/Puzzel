namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 167; }
        public static int Build { get => 544; }
        public static string Hash { get => "b96eab56"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-25 08:41:41 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
