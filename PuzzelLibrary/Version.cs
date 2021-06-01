namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 169; }
        public static int Build { get => 551; }
        public static string Hash { get => "37c13ea1"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-06-01 16:27:37 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
