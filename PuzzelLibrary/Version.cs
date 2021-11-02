namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 184; }
        public static int Build { get => 606; }
        public static string Hash { get => "21dfb754"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-09-30 11:48:33 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
