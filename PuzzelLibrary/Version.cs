namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 205; }
        public static int Build { get => 680; }
        public static string Hash { get => "f106decd"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2022-05-17 08:09:52 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
