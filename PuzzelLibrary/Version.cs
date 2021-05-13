namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 161; }
        public static int Build { get => 488; }
        public static string Hash { get => "a99492ad"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-13 17:56:31 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
