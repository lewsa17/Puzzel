namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 164; }
        public static int Build { get => 521; }
        public static string Hash { get => "f4d2868e"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-19 21:56:05 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
