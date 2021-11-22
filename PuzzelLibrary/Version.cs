namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 187; }
        public static int Build { get => 618; }
        public static string Hash { get => "06ada509"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-11-22 10:22:51 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
