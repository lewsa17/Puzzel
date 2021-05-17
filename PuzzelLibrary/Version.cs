namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 162; }
        public static int Build { get => 512; }
        public static string Hash { get => "f5ae0741"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-17 15:57:12 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
