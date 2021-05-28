namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 169; }
        public static int Build { get => 548; }
        public static string Hash { get => "abe9d41c"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-28 10:51:05 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
