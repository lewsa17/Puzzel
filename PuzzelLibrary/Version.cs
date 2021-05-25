namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 167; }
        public static int Build { get => 543; }
        public static string Hash { get => "1374e578"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-24 10:14:33 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
