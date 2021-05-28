namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 168; }
        public static int Build { get => 547; }
        public static string Hash { get => "17e297bd"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-27 13:28:37 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
