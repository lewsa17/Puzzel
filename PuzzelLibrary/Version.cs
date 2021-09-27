namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 183; }
        public static int Build { get => 595; }
        public static string Hash { get => "e8876e15"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-09-27 12:16:48 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
