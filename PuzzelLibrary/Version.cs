namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 164; }
        public static int Build { get => 520; }
        public static string Hash { get => "e1e424cd"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-19 21:34:41 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
