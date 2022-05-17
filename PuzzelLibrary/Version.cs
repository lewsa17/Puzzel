namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 204; }
        public static int Build { get => 678; }
        public static string Hash { get => "523659a1"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2022-05-16 15:53:32 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
