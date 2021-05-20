namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 164; }
        public static int Build { get => 525; }
        public static string Hash { get => "8b2a6d20"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-20 18:15:45 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
