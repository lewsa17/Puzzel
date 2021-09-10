namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 182; }
        public static int Build { get => 591; }
        public static string Hash { get => "a3769814"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-09-10 08:04:34 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
