namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 166; }
        public static int Build { get => 542; }
        public static string Hash { get => "ffe54fab"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-21 15:57:14 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
